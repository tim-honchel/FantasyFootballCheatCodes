
using Fantasy.API.Controllers;
using Fantasy.Logic.Implementations;
using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Moq;

namespace Fantasy.API.Tests
{
    public static class ControllerHelper
    {
        public static MainController GetControllerWithMockedDependencies(Endpoint endpoint, ReturnType returnType)
        {
            Mock<ICostAnalysisLogic> costAnalysisLogic = new();
            Mock<ICsvStartersLogic> csvStartersLogic = new();
            Mock<ICsvSuggestedRostersLogic> csvSuggestedRostersLogic = new();
            Mock<IEspnPlayersLogic> espnPlayersLogic = new();
            Mock<IEspnRulesLogic> espnRulesLogic = new();
            Mock<IExpectedValueLogic> expectedValueLogic = new();
            Mock<ILeagueRulesLogic> leagueRulesLogic = new();
            Mock<IPlayerProjectionsLogic> playerProjectionsLogic = new();
            Mock<IPointAveragesLogic> pointAveragesLogic = new();
            Mock<IPossibleRostersLogic> possibleRostersLogic = new();
            Mock<IRelativePointsLogic> relativePointsLogic = new();
            Mock<ISimplifiedDraftPoolLogic> simplifiedDraftPoolLogic = new();
            Mock<IStrongRosterLogic> strongRosterLogic = new();
            Mock<IStrongerRosterLogic> strongerRosterLogic = new();
            Mock<ISuggestedRostersLogic> suggestedRostersLogic = new();
            Mock<ITagsLogic> tagsLogic = new();
            Mock<ITopRosterFrequencyLogic> topRosterFrequencyLogic = new();
            Mock<ITopRosterPercentLogic> topRosterPercentLogic = new();
            Mock<ITopRosterPlayersLogic> topRosterPlayersLogic = new();
            Mock<IValidRulesLogic> validRulesLogic = new();

            if (endpoint == Endpoint.espnRules)
            {
                EspnRulesResponse response = new();
                espnRulesLogic.Setup(logic => logic.Get(It.IsAny<EspnRulesRequest>())).ReturnsAsync(response);
            }
            else if (endpoint == Endpoint.espnPlayers)
            {
                EspnPlayersResponse response = new();
                espnPlayersLogic.Setup(logic => logic.Get(It.IsAny<EspnPlayersRequest>())).ReturnsAsync(response);
            }

            MainController controller = new(costAnalysisLogic.Object, csvStartersLogic.Object, csvSuggestedRostersLogic.Object, espnPlayersLogic.Object, espnRulesLogic.Object, expectedValueLogic.Object, leagueRulesLogic.Object, playerProjectionsLogic.Object, pointAveragesLogic.Object, possibleRostersLogic.Object, relativePointsLogic.Object, simplifiedDraftPoolLogic.Object, strongRosterLogic.Object, strongerRosterLogic.Object, suggestedRostersLogic.Object, tagsLogic.Object, topRosterFrequencyLogic.Object,topRosterPercentLogic.Object, topRosterPlayersLogic.Object, validRulesLogic.Object);

            return controller;
        }

        public enum Endpoint
        {
            costAnalysis,
            csvStarters,
            csvSuggestedRosters,
            editProjections,
            espnPlayers,
            espnRules,
            expectedValue,
            leagueRules,
            playerProjections,
            pointAverages,
            possibleRosters,
            relativePoints,
            simplifiedDraftPool,
            strongRoster,
            strongerRoster,
            suggestedRosters,
            tagsLogic,
            topRosterFrequency,
            topRosterPercent,
            topRosterPlayers,
            validRules
        }

        public enum ReturnType
        {
            Default
        }
    }
}
