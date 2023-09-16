
using Fantasy.API.Controllers;
using Fantasy.Logic.Implementations;
using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
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
            Mock<IEditProjectionsLogic> editProjectionsLogic = new();
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
                RulesESPN rules = new();
                espnRulesLogic.Setup(logic => logic.Get(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).ReturnsAsync(rules);
            }

            MainController controller = new(costAnalysisLogic.Object, csvStartersLogic.Object, csvSuggestedRostersLogic.Object, editProjectionsLogic.Object, espnPlayersLogic.Object, espnRulesLogic.Object, expectedValueLogic.Object, leagueRulesLogic.Object, playerProjectionsLogic.Object, pointAveragesLogic.Object, possibleRostersLogic.Object, relativePointsLogic.Object, simplifiedDraftPoolLogic.Object, strongRosterLogic.Object, strongerRosterLogic.Object, suggestedRostersLogic.Object, tagsLogic.Object, topRosterFrequencyLogic.Object,topRosterPercentLogic.Object, topRosterPlayersLogic.Object, validRulesLogic.Object);

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
