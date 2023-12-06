using Fantasy.Presentation.Data.Exceptions;
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.Responses;
using Fantasy.Presentation.Data.State;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Fantasy.Presentation.Services.Implementations
{
    public class ApiCallService : IApiCallService
    {
        HttpClient _client;
        UserData _userData;

        public ApiCallService(UserData userData)
        {
            _client = new HttpClient();
            string url = "https://localhost:7164/";
            _client.BaseAddress = new Uri(url);
            _client.DefaultRequestHeaders.Clear();
            _userData = userData;
        }

        public ApiCallService(UserData userData, HttpMessageHandler handler) // for unit testing, to allow mocking
        {
            _client = new HttpClient(handler);
            _client.BaseAddress = new Uri("https://testing/");
            _client.DefaultRequestHeaders.Clear();
            _userData = userData;
        }

        public async Task<CostAnalysisViewModel> CostAnalysis(CostAnalysisRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("costAnalysis", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            CostAnalysisResponseObject? result = await response.Content.ReadFromJsonAsync<CostAnalysisResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            CostAnalysisViewModel analysis = result.Analysis;

            return analysis;
        }
    

        public Task<FileContentResult> CsvStarters(CsvStartersRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'csvStarters' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<FileContentResult> CsvSuggestedRosters(SuggestedRostersRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'csvSuggestedRosters' endpoint is not yet implemented.");
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

        public async Task<List<PlayerViewModel>> ExpectedValue(ExpectedValueRequestObject request)
        {
            HttpResponseMessage response = await _client.PutAsJsonAsync("expectedValue", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            ExpectedValueResponseObject? result = await response.Content.ReadFromJsonAsync<ExpectedValueResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            List<PlayerViewModel> players = result.Players;

            return players;
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

        public async Task<PointAveragesViewModel> PointAverages(PointAveragesRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("pointAverages", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            PointAveragesResponseObject? result = await response.Content.ReadFromJsonAsync<PointAveragesResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            PointAveragesViewModel averages = result.Averages;

            return averages;
        }

        public Task<List<RosterViewModel>> PossibleRosters(PossibleRostersRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'possibleRosters' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public async Task<List<PlayerViewModel>> RelativePoints(RelativePointsRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("relativePoints", request);
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

        public async Task<List<PlayerViewModel>> SimplifiedDraftPool(SimplifiedDraftPoolRequestObject request)
        {
            HttpResponseMessage response = await _client.PostAsJsonAsync("simplifiedDraftPool", request);
            if (!response.IsSuccessStatusCode)
            {
                throw new ServerErrorException();
            }

            SimplifiedDraftPoolResponseObject? result = await response.Content.ReadFromJsonAsync<SimplifiedDraftPoolResponseObject>();
            if (result == null)
            {
                throw new NullContentException();
            }

            List<PlayerViewModel> players = result.Players;

            return players;
        }

        public Task<RosterViewModel> StrongerRoster(StrongerRosterRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'strongerRoster' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<RosterViewModel> StrongRoster(StrongRosterRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'strongRoster' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<List<DraftBoardViewModel>> SuggestedRosters(SuggestedRostersRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'suggestedRosters' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<List<PlayerViewModel>> Tags(TagsRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'tags' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<CountByIDViewModel> TopRosterFrequency(TopRosterFrequencyRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'topRosterFrequency' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<List<PlayerViewModel>> TopRosterPercent(TopRosterPercentRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'topRosterPercent' endpoint is not yet implemented.");
            throw new NotImplementedException();
        }

        public Task<List<int>> TopRosterPlayers(TopRosterPlayersRequestObject request)
        {
            _userData.ErrorMessages.Add("The 'topRosterPlayers' endpoint is not yet implemented.");
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
