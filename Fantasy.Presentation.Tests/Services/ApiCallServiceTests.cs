
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.Responses;
using Fantasy.Presentation.Data.State;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Implementations;
using Moq;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Fantasy.Presentation.Tests.Services
{
    [TestFixture]
    public class ApiCallServiceTests
    {
        ContextHelper _helper = new ContextHelper();

        [Test]
        public async Task CostAnalysis_Returns_CostAnalysis_GivenSuccessfulCall()
        {
            CostAnalysisRequestObject request = new();
            CostAnalysisViewModel analysis = new();
            CostAnalysisResponseObject mockResponse = new()
            {
                Analysis = analysis,
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.costAnalysis, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            CostAnalysisViewModel response = await service.CostAnalysis(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(analysis));
        }

        [Test]
        public void CostAnalysis_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvStarters_Returns_File_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvStarters_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvSuggestedRosters_Returns_File_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvSuggestedRosters_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task EspnPlayers_Returns_Players_GivenSuccessfulCall()
        {
            EspnPlayersRequestObject request = new();
            List<PlayerESPNViewModel> players = new();
            EspnPlayersResponseObject mockResponse = new()
            {
                Players = players,
            }; 
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.espnPlayers, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            List<PlayerESPNViewModel> response = await service.EspnPlayers(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(players));
        }

        [Test]
        public void EspnPlayers_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task EspnRules_Returns_Rules_GivenSuccessfulCall()
        {
            EspnRulesRequestObject request = new();
            RulesESPNViewModel rules = new();
            EspnRulesResponseObject mockResponse = new()
            {
                Rules = rules
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.espnRules, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            RulesESPNViewModel response = await service.EspnRules(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(rules));
        }

        [Test]
        public void EspnRules_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public async Task ExpectedValue_Returns_Players_GivenSuccessfulCall()
        {
            ExpectedValueRequestObject request = new();
            List<PlayerViewModel> players = _helper.GetMockPlayers();
            ExpectedValueResponseObject mockResponse = new()
            {
                Players = players
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.expectedValue, HttpMethod.Put, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            List<PlayerViewModel> response = await service.ExpectedValue(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(players));
        }

        [Test]
        public void ExpectedValue_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task LeagueRules_Returns_Rules_GivenSuccessfulCall()
        {
            LeagueRulesRequestObject request = new();
            RulesViewModel rules = new();
            LeagueRulesResponseObject mockResponse = new()
            {
                Rules = rules
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.leagueRules, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            RulesViewModel response = await service.LeagueRules(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(rules));
        }

        [Test]
        public void LeagueRules_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task PlayerProjections_Returns_Players_GivenSuccessfulCall()
        {
            PlayerProjectionsRequestObject request = new();
            List<PlayerViewModel> players = _helper.GetMockPlayers();
            PlayerProjectionsResponseObject mockResponse = new()
            {
                Players = players
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.playerProjections, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(),handler.Object);

            List<PlayerViewModel> response = await service.PlayerProjections(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(players));
        }

        [Test]
        public void PlayerProjections_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public async Task PointAverages_Returns_PointAverages_GivenSuccessfulCall()
        {
            PointAveragesRequestObject request = new();
            PointAveragesViewModel averages = new();
            PointAveragesResponseObject mockResponse = new()
            {
                 Averages = averages
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.pointAverages, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            PointAveragesViewModel response = await service.PointAverages(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(averages));
        }

        [Test]
        public void PointAverages_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public void PossibleRosters_Returns_CostAnalysis_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void PossibleRosters_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public async Task RelativePoints_Returns_Players_GivenSuccessfulCall()
        {
            RelativePointsRequestObject request = new();
            List<PlayerViewModel> players = _helper.GetMockPlayers();
            RelativePointsResponseObject mockResponse = new()
            {
                Players = players
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.relativePoints, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            List<PlayerViewModel> response = await service.RelativePoints(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(players));
        }

        [Test]
        public void RelativePoints_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task SimplifiedDraftPool_Returns_Players_GivenSuccessfulCall()
        {
            SimplifiedDraftPoolRequestObject request = new();
            List<PlayerViewModel> players = _helper.GetMockPlayers();
            SimplifiedDraftPoolResponseObject mockResponse = new()
            {
                Players = players
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.simplifiedDraftPool, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            List<PlayerViewModel> response = await service.SimplifiedDraftPool(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(players));
        }

        [Test]
        public void SimplifiedDraftPool_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongerRoster_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongerRoster_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public void StrongRoster_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongRoster_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void SuggestedRosters_Returns_DraftBoards_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void SuggestedRosters_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void Tags_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void Tags_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterFrequency_Returns_CountByID_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterFrequency_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPercent_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPercent_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPlayers_Returns_Dictionary_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPlayers_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task ValidRules_Returns_RuleValidity_GivenSuccessfulCall()
        {

            RulesViewModel rules = new();
            List<PlayerViewModel> players = _helper.GetMockPlayers();
            ValidRulesRequestObject request = new()
            {
                Players = players,
                Rules = rules
            };
            ValidRulesResponseObject mockResponse = new()
            {
                Success = true
            };
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.validRules, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(mockResponse));
            ApiCallService service = new ApiCallService(new UserData(), handler.Object);

            RuleValidityViewModel response = await service.ValidRules(request);

            Assert.AreEqual(response.IsValid, mockResponse.Success);
        }

        [Test]
        public void ValidRules_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }
    }
}
