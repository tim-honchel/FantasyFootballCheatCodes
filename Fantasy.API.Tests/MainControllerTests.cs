using Fantasy.API.Controllers;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.API.Tests
{
    [TestFixture]
    public class MainControllerTests
    {


        [Test]
        public void CostAnalysis_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void CostAnalysis_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvStarters_Returns_File_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvStarters_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvSuggestedRosters_Returns_File_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void CsvSuggestedRosters_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void EditProjections_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void EditProjections_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void EspnPlayers_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void EspnPlayers_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public async Task EspnRules_Returns_OkObjectResult_Given_ValidResponse()
        {
            EspnRulesRequest request = new();
            MainController controller = ControllerHelper.GetControllerWithMockedDependencies(ControllerHelper.Endpoint.espnRules, ControllerHelper.ReturnType.Default);

            IActionResult response = await controller.EspnRules(request);

            Assert.True(response is OkObjectResult);
        }

        [Test]
        public async Task EspnRules_Returns_EspnRules_Given_ValidResponse()
        {
            EspnRulesRequest request = new();
            MainController controller = ControllerHelper.GetControllerWithMockedDependencies(ControllerHelper.Endpoint.espnRules, ControllerHelper.ReturnType.Default);

            IActionResult response = await controller.EspnRules(request);
            OkObjectResult result = (OkObjectResult)response;

            Assert.IsInstanceOf<RulesESPN>(result.Value);
        }

        [Test]
        public void EspnRules_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void ExpectedValues_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void ExpectedValues_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void LeagueRules_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void LeagueRules_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void PlayerProjections_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void PlayerProjections_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void PointAverages_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void PointAverages_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void PossibleRosters_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void PossibleRosters_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void RelativePoints_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void RelativePoints_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void SimplifiedDraftPool_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void SimplifiedDraftPool_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongerRoster_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongerRoster_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongRoster_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void StrongRoster_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void SuggestedRosters_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void SuggestedRosters_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void Tags_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void Tags_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterFrequency_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterFrequency_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPercent_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPercent_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPlayers_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void TopRosterPlayers_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }

        [Test]
        public void ValidRules_Returns_OkObjectResult_Given_ValidResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void ValidRules_Returns_BadRequestObjectResult_Given_CustomException()
        {
            Assert.Ignore();
        }
    }
}