using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Fantasy.Logic.Implementations
{
    public class EspnPlayersLogic : IEspnPlayersLogic
    {
        public readonly IConfiguration _configuration;
        string _url = string.Empty;
        public EspnPlayersLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<EspnPlayersResponse> Get(EspnPlayersRequest request)
        {
            HttpClient client = SetupClient(request.LeagueID, request.espn_s2, request.swid);
            
            Dictionary<string, int> positionLimits = CalculateLimits(request.Rules.Positions, request.Rules.Size.Teams);

            List<string> responses = await CallEspnApiForEachPosition(client, request, positionLimits);

            List<PlayerESPN> players = ParseAllPlayers(responses, request.LeagueID);

            EspnPlayersResponse response = new()
            {
                Success = true,
                Players = players
            };

            return response;
        }

        public Dictionary<string, int> CalculateLimits(Positions positions, int teams)
        {
            double multiplier = 1.2;
            
            Dictionary<string, double> shareOPU = new()
            {
                {BasePositionConstants.Quarterback, 0.6}, {BasePositionConstants.RunningBack, 0.4}, {BasePositionConstants.WideReceiver, 0.2}, {BasePositionConstants.TightEnd, 0.1}
            };

            Dictionary<string, double> shareFLEX = new()
            {
                {BasePositionConstants.RunningBack, 0.9}, {BasePositionConstants.WideReceiver, 0.3}, {BasePositionConstants.TightEnd, 0.1}
            };

            Dictionary<string, double> shareRBWR = new()
            {
                {BasePositionConstants.RunningBack, 0.9}, {BasePositionConstants.WideReceiver, 0.4 }
            };

            Dictionary<string, double> shareWRTE = new()
            {
                {BasePositionConstants.WideReceiver, 1}, {BasePositionConstants.TightEnd, 0.3}
            };

            Dictionary<string, double> shareDPU = new()
            {
                {BasePositionConstants.DefensiveTackle, 0.3}, {BasePositionConstants.DefensiveEnd, 0.3}, {BasePositionConstants.Linebacker, 0.3}, {BasePositionConstants.Cornerback, 0.3}, {BasePositionConstants.Safety, 0.3}
            };

            Dictionary<string, double> shareDL = new()
            {
                {BasePositionConstants.DefensiveTackle, 0.5}, {BasePositionConstants.DefensiveEnd, 0.8}
            };

            Dictionary<string, double> shareDB = new()
            {
                {BasePositionConstants.Cornerback, 0.7}, {BasePositionConstants.Safety, 0.6}
            };

            Dictionary<string, int> limits = new();

            limits[BasePositionConstants.Quarterback] = (int)((multiplier * teams) * (positions.Quarterbacks[0] + positions.OffensivePlayerUtilities * shareOPU[BasePositionConstants.Quarterback]));

            limits[BasePositionConstants.RunningBack] = (int)((multiplier * teams) * (positions.RunningBacks[0] + positions.FLEX * shareFLEX[BasePositionConstants.RunningBack] + positions.BacksAndReceivers * shareRBWR[BasePositionConstants.RunningBack] + positions.OffensivePlayerUtilities * shareOPU[BasePositionConstants.RunningBack]));

            limits[BasePositionConstants.WideReceiver] = (int)((multiplier * teams) * (positions.WideReceivers[0] + positions.FLEX * shareFLEX[BasePositionConstants.WideReceiver] + positions.BacksAndReceivers * shareFLEX[BasePositionConstants.WideReceiver] + positions.ReceiversAndEnds * shareWRTE[BasePositionConstants.WideReceiver] + positions.OffensivePlayerUtilities * shareOPU[BasePositionConstants.WideReceiver]));

            limits[BasePositionConstants.TightEnd] = (int)((multiplier * teams) * (positions.TightEnds[0] + positions.FLEX * shareFLEX["TE"] + positions.ReceiversAndEnds * shareWRTE[BasePositionConstants.TightEnd] + positions.OffensivePlayerUtilities * shareOPU[BasePositionConstants.TightEnd]));

            limits[BasePositionConstants.Kicker] = (int) ((multiplier * teams) * (positions.Kickers[0]));

            limits[BasePositionConstants.TeamDefense] = (int)((multiplier * teams) * (positions.TeamDefenses[0]));

            limits[BasePositionConstants.TeamQuarterback] = (int)((multiplier * teams) * (positions.TeamQuarterbacks[0]));

            limits[BasePositionConstants.Punter] = (int)((multiplier * teams) * (positions.Punters[0]));

            limits[BasePositionConstants.Coach] = (int)((multiplier * teams) * (positions.Coaches[0]));

            limits[BasePositionConstants.DefensiveTackle] = (int)((multiplier * teams) * (positions.DefensiveTackles[0] + positions.DefensivePlayerUtilities * shareDPU[BasePositionConstants.DefensiveTackle] + positions.DefensiveLinemen * shareDL[BasePositionConstants.DefensiveTackle]));

            limits[BasePositionConstants.DefensiveEnd] = (int)((multiplier * teams) * (positions.DefensiveEnds[0] + positions.DefensivePlayerUtilities * shareDPU[BasePositionConstants.DefensiveEnd] + positions.DefensiveLinemen * shareDL[BasePositionConstants.DefensiveEnd]));

            limits[BasePositionConstants.Linebacker] = (int)((multiplier * teams) * (positions.Linebackers[0] + positions.DefensivePlayerUtilities * shareDPU[BasePositionConstants.Linebacker]));

            limits[BasePositionConstants.Cornerback] = (int)((multiplier * teams) * (positions.Cornerbacks[0] + positions.DefensivePlayerUtilities * shareDPU[BasePositionConstants.Cornerback] + positions.DefensiveBacks * shareDB[BasePositionConstants.Cornerback]));

            limits[BasePositionConstants.Safety] = (int)((multiplier * teams) * (positions.Safeties[0] + positions.DefensivePlayerUtilities * shareDPU[BasePositionConstants.Safety] + positions.DefensiveBacks * shareDB[BasePositionConstants.Safety]));

            return limits;
        }

        public async Task<string> CallEspnApi(HttpClient client, string position, int limit)
        {
            string filter = _configuration["ESPNFantasyFilter"].Replace("[limit]", limit.ToString()).Replace("[positions]", position).Replace("thisyear", DateTime.Now.Year.ToString()).Replace("lastyear", (DateTime.Now.Year - 1).ToString());
            client.DefaultRequestHeaders.Remove("X-Fantasy-Filter");
            client.DefaultRequestHeaders.Add("X-Fantasy-Filter", filter);

            string espnResponse = "";

            HttpResponseMessage response = await client.GetAsync(_url);
            if (response.IsSuccessStatusCode)
            {
                espnResponse = await response.Content.ReadAsStringAsync();
            }


            return espnResponse;
        }

        public async Task<List<string>> CallEspnApiForEachPosition(HttpClient client, EspnPlayersRequest request, Dictionary<string, int> positionLimits)
        {
            int teams = request.Rules.Size.Teams;
            Positions positions = request.Rules.Positions;
            Dictionary<string, string> espnPositions = new()
            {
                {"QB", "[0]" }, {"RB", "[2]" }, {"WR", "[4]" }, {"TE", "[6]" }, {"K", "[17]" }, {"DEF", "[16]" }, {"TQB", "[0]" }, {"HC", "[19]" }, {"P", "[18]" }, {"DT", "[8]" }, {"DE", "[9]" }, {"LB", "[10]" }, {"CB", "[12]" }, {"S", "[13]" }
            };

            List<string> responses = new();

            foreach (KeyValuePair<string,string> pair in espnPositions)
            {
                if (positionLimits[pair.Key] > 0)
                {
                    string espnResponse = await CallEspnApi(client, espnPositions[pair.Key], positionLimits[pair.Key]);
                    responses.Add(espnResponse);
                }
            }

            return responses;
        }

        public List<PlayerESPN> ParseAllPlayers(List<string> espnResponses, string leagueID)
        {
            List<PlayerESPN> players = new();

            foreach(string response in espnResponses)
            {
                if (!string.IsNullOrEmpty(response))
                {
                    var rawPlayers = JObject.Parse(response).GetValue("players");

                    foreach (JObject rawPlayer in rawPlayers)
                    {
                        PlayerESPN player = ParsePlayer(rawPlayer.ToString());
                        players.Add(player);
                    }
                }
            }

            return players;
        }

        public PlayerESPN ParsePlayer(string rawPlayer)
        {
            string playerDetail = JObject.Parse(rawPlayer).GetValue("player").ToString();
            var stats = JObject.Parse(playerDetail).GetValue("stats");
            string previousStats = stats.Count() > 1 ? stats[0].ToString() : "";
            string currentStats = stats.Count() > 1 ? stats[1].ToString(): stats[0].ToString();
            string ownership = JObject.Parse(playerDetail).GetValue("ownership").ToString();

            int id = Convert.ToInt32(JObject.Parse(rawPlayer).GetValue("id").ToString());
            int positionID = Convert.ToInt16(JObject.Parse(playerDetail).GetValue("defaultPositionId").ToString());
            int draftAuctionValue = Convert.ToInt16(JObject.Parse(rawPlayer).GetValue("draftAuctionValue").ToString());
            int keeperValue = Convert.ToInt16(JObject.Parse(rawPlayer).GetValue("keeperValue").ToString());
            string eligibleSlots = JObject.Parse(playerDetail).GetValue("eligibleSlots").ToString();
            string firstName = JObject.Parse(playerDetail).GetValue("firstName").ToString();
            string lastName = JObject.Parse(playerDetail).GetValue("lastName").ToString();
            bool active = Convert.ToBoolean(JObject.Parse(playerDetail).GetValue("active").ToString());
            bool injured = Convert.ToBoolean(JObject.Parse(playerDetail).GetValue("injured").ToString());
            string injuryStatus = positionID != 16? JObject.Parse(playerDetail).GetValue("injuryStatus").ToString() : "N/A";
            double averageDraftPosition = Math.Round(Convert.ToDouble(JObject.Parse(ownership).GetValue("averageDraftPosition").ToString()), 1);
            double percentOwned = Math.Round(Convert.ToDouble(JObject.Parse(ownership).GetValue("percentOwned").ToString()), 1);
            double percentStarted = Math.Round(Convert.ToDouble(JObject.Parse(ownership).GetValue("percentStarted").ToString()), 1);
            int teamID = Convert.ToInt16(JObject.Parse(playerDetail).GetValue("proTeamId").ToString());
            double appliedAverage = Math.Round(Convert.ToDouble(JObject.Parse(currentStats).GetValue("appliedAverage").ToString()), 2);
            double lastYearAppliedAverage = string.IsNullOrEmpty(previousStats)? 0 : Math.Round(Convert.ToDouble(JObject.Parse(previousStats).GetValue("appliedAverage").ToString()), 2);

            PlayerESPN player = new()
            {
                ID = id,
                DraftAuctionValue = draftAuctionValue,
                KeeperValue = keeperValue,
                DefaultPositionID = positionID,
                EligibleSlots = eligibleSlots,
                FirstName = firstName,
                LastName = lastName,
                Active = active,
                Injured = injured,
                InjuryStatus = injuryStatus,
                AverageDraftPosition = averageDraftPosition,
                PercentOwned = percentOwned,
                PercentStarted = percentStarted,
                ProTeamID = teamID,
                LastYearAveragePointsPerWeek = lastYearAppliedAverage,
                ThisYearProjectedPointsPerWeek = appliedAverage
            };

            return player;
        }

public HttpClient SetupClient(string leagueID, string espn_s2, string swid)
        {
            _url = _configuration["ESPNProjectionsURL"].Replace("[year]", DateTime.Now.Year.ToString()).Replace("[leagueID]", leagueID.ToString());
            
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_url);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Cookie", espn_s2 + swid);
            client.DefaultRequestHeaders.Add("Accept","application/json");
            client.DefaultRequestHeaders.Add("X-Fantasy-Filter", "");
            return client;
        }

    }
}
