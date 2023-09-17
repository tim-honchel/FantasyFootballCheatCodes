using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Newtonsoft.Json.Linq;
using System.Formats.Asn1;
using System.Net.Http.Headers;
using System.Security;

namespace Fantasy.Logic.Implementations
{
    public class EspnRulesLogic : IEspnRulesLogic
    {
        public async Task<EspnRulesResponse> Get(EspnRulesRequest request)
        {
            HttpClient client = SetupClient(request.LeagueID, request.espn_s2, request.swid);

            string espnResponse = await client.GetStringAsync("");

            RulesESPN rules = ParseRules(espnResponse, request.LeagueID);

            EspnRulesResponse response = new()
            {
                Success = true,
                Rules = rules
            };

            return response;

        }

        public Dictionary<int, int> GetPositionDictionary(string positions, int count)
        {
            Dictionary<int, int> positionDictionary = new();
            for (int i = 0; i <= count; i++)
            {
                positionDictionary[i] = Convert.ToInt16(JObject.Parse(positions).GetValue(i.ToString()).ToString());
            }
            return positionDictionary;
        }

        public RulesESPN ParseRules(string response, string leagueID)
        {
            string draftDetail = JObject.Parse(response).GetValue("draftDetail").ToString();
            string settings = JObject.Parse(response).GetValue("settings").ToString();
            string draftSettings = JObject.Parse(settings).GetValue("draftSettings").ToString();
            string rosterSettings = JObject.Parse(settings).GetValue("rosterSettings").ToString();
            string scheduleSettings = JObject.Parse(settings).GetValue("scheduleSettings").ToString();
            string scoringSettings = JObject.Parse(settings).GetValue("scoringSettings").ToString();
            string status = JObject.Parse(response).GetValue("status").ToString();

            bool draftComplete = Convert.ToBoolean(JObject.Parse(draftDetail).GetValue("drafted").ToString());
            bool draftInProgress = Convert.ToBoolean(JObject.Parse(draftDetail).GetValue("inProgress").ToString());
            int season = Convert.ToInt16(JObject.Parse(response).GetValue("seasonId").ToString());
            string draftType = JObject.Parse(draftSettings).GetValue("type").ToString();
            string leagueSubType = JObject.Parse(draftSettings).GetValue("leagueSubType").ToString();
            string draftOrderType = JObject.Parse(draftSettings).GetValue("orderType").ToString();
            int auctionBudget = Convert.ToInt16(JObject.Parse(draftSettings).GetValue("auctionBudget").ToString());
            bool isTradingEnabled = Convert.ToBoolean(JObject.Parse(draftSettings).GetValue("isTradingEnabled").ToString());
            int keeperCount = Convert.ToInt16(JObject.Parse(draftSettings).GetValue("keeperCount").ToString());
            string positionSlotCountsRaw = JObject.Parse(rosterSettings).GetValue("lineupSlotCounts").ToString();
            string positionLimitsRaw = JObject.Parse(rosterSettings).GetValue("positionLimits").ToString();
            int matchupPeriods = Convert.ToInt16(JObject.Parse(scheduleSettings).GetValue("matchupPeriodCount").ToString());
            int matchupPeriodLength = Convert.ToInt16(JObject.Parse(scheduleSettings).GetValue("matchupPeriodLength").ToString());
            int playoffMatchupPeriodLength = Convert.ToInt16(JObject.Parse(scheduleSettings).GetValue("playoffMatchupPeriodLength").ToString());
            string playoffSeedingRule = JObject.Parse(scheduleSettings).GetValue("playoffSeedingRule").ToString();
            int teams = Convert.ToInt16(JObject.Parse(settings).GetValue("size").ToString());
            int playoffTeams = Convert.ToInt16(JObject.Parse(scheduleSettings).GetValue("playoffTeamCount").ToString()); ;
            string scoringType = JObject.Parse(scoringSettings).GetValue("scoringType").ToString();
            bool isActive = Convert.ToBoolean(JObject.Parse(status).GetValue("isActive").ToString());

            Dictionary<int, int> positionSlotCounts = GetPositionDictionary(positionSlotCountsRaw, 24);
            Dictionary<int, int> positionLimits = GetPositionDictionary(positionLimitsRaw, 17);

            RulesESPN rules = new()
            {
                LeagueID = Convert.ToInt32(leagueID),
                DraftComplete = draftComplete,
                DraftInProgress = draftInProgress,
                Season = season,
                DraftType = draftType,
                LeagueSubType = leagueSubType,
                DraftOrderType = draftOrderType,
                AuctionBudget = auctionBudget,
                IsTradingEnabled = isTradingEnabled,
                KeeperCount = keeperCount,
                PositionSlotCounts = positionSlotCounts,
                PositionLimits = positionLimits,
                MatchupPeriods = matchupPeriods,
                MatchupPeriodLength = matchupPeriodLength,
                PlayoffMatchupPeriodLength = playoffMatchupPeriodLength,
                PlayoffSeedingRule = playoffSeedingRule,
                Teams = teams,
                PlayoffTeams = playoffTeams,
                ScoringType = scoringType,
                IsActive = isActive,
            };

            return rules;
        }

        public HttpClient SetupClient(string leagueID, string espn_s2, string swid)
        {
            HttpClient client = new HttpClient();
            string url = $"https://lm-api-reads.fantasy.espn.com/apis/v3/games/ffl/seasons/{DateTime.Now.Year.ToString()}/segments/0/leagues/{leagueID}?view=mSettings&view=mTeam&view=modular&view=mNav";
            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Cookie", espn_s2 + swid);
            return client;
        }


    }
}
