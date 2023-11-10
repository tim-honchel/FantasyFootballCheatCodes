
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.State;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Implementations;
using Fantasy.Presentation.Services.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fantasy.Presentation.Tests.Services
{
    [TestFixture]
    public class StrategyServiceTests
    {
        [Test]
        public async Task EvaluatePlayers_Updates_UserDataPlayers()
        {
            PlayerViewModel player = new PlayerViewModel() { LastName = "test" };
            List<PlayerViewModel> players = new List<PlayerViewModel>() { player};
            UserData userData = new() { Players = players };

            Mock<IApiCallService> callService = SetupMockCallService(players);

            StrategyService service = new(callService.Object, userData);

            await service.EvaluatePlayers();

            Assert.That(userData.Players.First().QB1 != 0);
            Assert.That(userData.Players.First().ExpectedValue != 0);
            Assert.That(userData.Players.First().PercentOfTopRosters != 0);
            Assert.That(userData.Players.First().Tags.Count > 0);
        }

        public Mock<IApiCallService> SetupMockCallService(List<PlayerViewModel> players)
        {
            Mock<IApiCallService> callService = new();
            List<PlayerViewModel> mockPlayers = new();
            mockPlayers.Add(new PlayerViewModel() { LastName = players.First().LastName });

            callService.Setup(service => service.PointAverages(It.Is<PointAveragesRequestObject>(x => x.Players.Count > 0))).ReturnsAsync(new PointAveragesViewModel());

            mockPlayers.First().QB1 = 1;
            callService.Setup(service => service.RelativePoints(It.Is<RelativePointsRequestObject>(x => x.PointAverages != null))).ReturnsAsync(mockPlayers);

            callService.Setup(service => service.CostAnalysis(It.Is<CostAnalysisRequestObject>(x=>x.Players.First().QB1 == 1))).ReturnsAsync(new CostAnalysisViewModel());

            mockPlayers.First().ExpectedValue = 10;
            callService.Setup(service => service.ExpectedValue(It.Is<ExpectedValueRequestObject>(x => x.CostAnalysis != null))).ReturnsAsync(mockPlayers);
            
            callService.Setup(service => service.SimplifiedDraftPool(It.Is<SimplifiedDraftPoolRequestObject>(x => x.Players.First().ExpectedValue == 10))).ReturnsAsync(mockPlayers);

            RosterViewModel roster = new RosterViewModel();
            callService.Setup(service => service.StrongRoster(It.Is<StrongRosterRequestObject>(x => x.Players.First().ExpectedValue == 10))).ReturnsAsync(roster);

            roster.QB = 1;
            callService.Setup(service => service.StrongerRoster(It.Is<StrongerRosterRequestObject>(x => x.Roster != null))).ReturnsAsync(roster);
            
            List<RosterViewModel> rosters = new();
            rosters.Add(roster);
            callService.Setup(service => service.PossibleRosters(It.Is<PossibleRostersRequestObject>(x => x.Roster.QB == 1))).ReturnsAsync(rosters);
            
            callService.Setup(service => service.TopRosterFrequency(It.Is<TopRosterFrequencyRequestObject>(x => x.Rosters.Count > 0))).ReturnsAsync(new CountByIDViewModel());

            mockPlayers.First().PercentOfTopRosters = 0.1;
            callService.Setup(service => service.TopRosterPercent(It.Is<TopRosterPercentRequestObject>(x => x.Frequency != null))).ReturnsAsync(mockPlayers);

            mockPlayers.First().Tags.Add("test");
            callService.Setup(service => service.Tags(It.Is<TagsRequestObject>(x => x.Players.First().PercentOfTopRosters == 0.1))).ReturnsAsync(mockPlayers);

            return callService;
        }

    }
}
