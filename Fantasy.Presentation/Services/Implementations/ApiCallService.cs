using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Fantasy.Presentation.Services.Implementations
{
    public class ApiCallService : IApiCallService
    {
        HttpClient _client;

        public ApiCallService()
        {
            _client = new HttpClient();
            string url = "https://localhost:7164/";
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Clear();
        }

        public ApiCallService(HttpMessageHandler handler) // for unit testing, to allow mocking
        {
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri("https://testing/");
            _client.DefaultRequestHeaders.Clear();
        }

        public CostAnalysisViewModel CostAnalysis(CostAnalysisRequestObject request)
        {
            throw new NotImplementedException();
        }

        public FileContentResult CsvStarters(CsvStartersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public FileContentResult CsvSuggestedRosters(SuggestedRostersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerESPNViewModel>> EspnPlayers(EspnPlayersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public async Task<RulesESPNViewModel> EspnRules(EspnRulesRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("espnRules", request);
            RulesESPNViewModel rules = await response.Content.ReadFromJsonAsync<RulesESPNViewModel>();
            return rules;
        }

        public List<PlayerViewModel> ExpectedValue(ExpectedValueRequestObject request)
        {
            throw new NotImplementedException();
        }

        public RulesViewModel LeagueRules(LeagueRulesRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<PlayerViewModel> PlayerProjections(PlayerProjectionsRequestObject request)
        {
            throw new NotImplementedException();
        }

        public PointAveragesViewModel PointAverages(PointAveragesRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<RosterViewModel> PossibleRosters(PossibleRostersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<PlayerViewModel> RelativePoints(RelativePointsRequestObject request)
        {
            throw new NotImplementedException();
        }

        public RosterViewModel StrongerRoster(StrongerRosterRequestObject request)
        {
            throw new NotImplementedException();
        }

        public RosterViewModel StrongRoster(StrongRosterRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<DraftBoardViewModel> SuggestedRosters(SuggestedRostersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<PlayerViewModel> Tags(TagsRequestObject request)
        {
            throw new NotImplementedException();
        }

        public CountByIDViewModel TopRosterFrequency(TopRosterFrequencyRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<PlayerViewModel> TopRosterPercent(TopRosterPercentRequestObject request)
        {
            throw new NotImplementedException();
        }

        public List<int> TopRosterPlayers(TopRosterPlayersRequestObject request)
        {
            throw new NotImplementedException();
        }
        public RuleValidityViewModel ValidRules(ValidRulesRequestObject request)
        {
            throw new NotImplementedException();
        }
    }
}
