using Fantasy.Presentation.Data.Exceptions;
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.Responses;
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

        public Task<CostAnalysisViewModel> CostAnalysis(CostAnalysisRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<FileContentResult> CsvStarters(CsvStartersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<FileContentResult> CsvSuggestedRosters(SuggestedRostersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PlayerESPNViewModel>> EspnPlayers(EspnPlayersRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("espnPlayers", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            EspnPlayersResponseObject? result = await response.Content.ReadFromJsonAsync<EspnPlayersResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            List<PlayerESPNViewModel> players = result.Players;

            return players;
        }

        public async Task<RulesESPNViewModel> EspnRules(EspnRulesRequestObject request)
        {
            request.espn_s2 = $"espn_s2={request.espn_s2};";
            request.swid = $"SWID={request.swid};";
            HttpResponseMessage response = await _client.PostAsJsonAsync("espnRules", request); 
            if(!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            EspnRulesResponseObject? result = await response.Content.ReadFromJsonAsync<EspnRulesResponseObject>();
            if(result == null)
            {
                throw new NullContentException();
            }

            RulesESPNViewModel rules = result.Rules;
            
            return rules;
        }

        public Task<List<PlayerViewModel>> ExpectedValue(ExpectedValueRequestObject request)
        {
            throw new NotImplementedException();
        }

        public async Task<RulesViewModel> LeagueRules(LeagueRulesRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("leagueRules", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            LeagueRulesResponseObject? result = await response.Content.ReadFromJsonAsync<LeagueRulesResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            RulesViewModel rules = result.Rules;

            return rules;
        }

        public async Task<List<PlayerViewModel>> PlayerProjections(PlayerProjectionsRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("playerProjections", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            PlayerProjectionsResponseObject? result = await response.Content.ReadFromJsonAsync<PlayerProjectionsResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            List<PlayerViewModel> players = result.Players;

            return players;
        }

        public Task<PointAveragesViewModel> PointAverages(PointAveragesRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<RosterViewModel>> PossibleRosters(PossibleRostersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerViewModel>> RelativePoints(RelativePointsRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<RosterViewModel> StrongerRoster(StrongerRosterRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<RosterViewModel> StrongRoster(StrongRosterRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<DraftBoardViewModel>> SuggestedRosters(SuggestedRostersRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerViewModel>> Tags(TagsRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<CountByIDViewModel> TopRosterFrequency(TopRosterFrequencyRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<PlayerViewModel>> TopRosterPercent(TopRosterPercentRequestObject request)
        {
            throw new NotImplementedException();
        }

        public Task<List<int>> TopRosterPlayers(TopRosterPlayersRequestObject request)
        {
            throw new NotImplementedException();
        }
        public async Task<RuleValidityViewModel> ValidRules(ValidRulesRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("validRules", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            ValidRulesResponseObject? result = await response.Content.ReadFromJsonAsync<ValidRulesResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            RuleValidityViewModel ruleValidity = new()
            {
                IsValid = result.Success,
                ReasonsNotSupported = result.ValidationErrors
            };

            return ruleValidity;
        }
    }
}
