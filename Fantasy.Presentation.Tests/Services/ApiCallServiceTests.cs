
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.Responses;
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
        public void CostAnalysis_Returns_CostAnalysis_GivenSuccessfulCall()
        {
            Assert.Ignore();
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
            ApiCallService service = new ApiCallService(handler.Object);

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
            ApiCallService service = new ApiCallService(handler.Object);

            RulesESPNViewModel response = await service.EspnRules(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(rules));
        }

        [Test]
        public void EspnRules_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public void ExpectedValue_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
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
            Mock<HttpMessageHandler> handler = _helper.GetMockHandler();
            _helper.SetupMockHandler(handler, ContextHelper.Endpoint.leagueRules, HttpMethod.Post, HttpStatusCode.OK, JsonSerializer.Serialize(rules));
            ApiCallService service = new ApiCallService(handler.Object);

            RulesViewModel response = await service.LeagueRules(request);

            Assert.AreEqual(JsonSerializer.Serialize(response), JsonSerializer.Serialize(rules));
        }

        [Test]
        public void LeagueRules_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void PlayerProjections_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void PlayerProjections_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public void PointAverages_Returns_PointAverages_GivenSuccessfulCall()
        {
            Assert.Ignore();
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
        public void RelativePoints_Returns_Players_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void RelativePoints_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public void StrongerRoster_Returns_CostAnalysis_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongerRoster_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }


        [Test]
        public void StrongRoster_Returns_CostAnalysis_GivenSuccessfulCall()
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
        public void ValidRules_Returns_RuleValidity_GivenSuccessfulCall()
        {
            Assert.Ignore();
        }

        [Test]
        public void ValidRules_Throws_CustomException_GivenUnsuccessfulCall()
        {
            Assert.Ignore();
        }
    }
}
