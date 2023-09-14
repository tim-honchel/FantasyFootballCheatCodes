using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Presentation.Services.Interfaces
{
    public interface IApiCallService
    {
        CostAnalysisViewModel CostAnalysis(CostAnalysisRequestObject request);
        FileContentResult CsvStarters(CsvStartersRequestObject request);
        FileContentResult CsvSuggestedRosters(SuggestedRostersRequestObject request);
        List<PlayerViewModel> ExpectedValue(ExpectedValueRequestObject request);
        Task<List<PlayerESPNViewModel>> EspnPlayers(EspnPlayersRequestObject request);
        Task<RulesESPNViewModel> EspnRules(EspnRulesRequestObject request);
        RulesViewModel LeagueRules(LeagueRulesRequestObject request);
        List<PlayerViewModel> PlayerProjections(PlayerProjectionsRequestObject request);
        PointAveragesViewModel PointAverages(PointAveragesRequestObject request);
        List<RosterViewModel> PossibleRosters(PossibleRostersRequestObject request);
        List<PlayerViewModel> RelativePoints(RelativePointsRequestObject request);
        RosterViewModel StrongerRoster(StrongerRosterRequestObject request);
        RosterViewModel StrongRoster(StrongRosterRequestObject request);
        List<DraftBoardViewModel> SuggestedRosters(SuggestedRostersRequestObject request);
        List<PlayerViewModel> Tags(TagsRequestObject request);
        CountByIDViewModel TopRosterFrequency(TopRosterFrequencyRequestObject request);
        List<PlayerViewModel> TopRosterPercent(TopRosterPercentRequestObject request);
        List<int> TopRosterPlayers(TopRosterPlayersRequestObject request);
        RuleValidityViewModel ValidRules(ValidRulesRequestObject request);

    }
}
