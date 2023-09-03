using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Fantasy.Presentation.Services.Interfaces
{
    public interface IApiCallService
    {
        Task<CostAnalysisViewModel> CostAnalysis(CostAnalysisRequestObject request);
        Task<FileContentResult> CsvStarters(CsvStartersRequestObject request);
        Task<FileContentResult> CsvSuggestedRosters(SuggestedRostersRequestObject request);
        Task<List<PlayerViewModel>> ExpectedValue(ExpectedValueRequestObject request);
        Task<List<PlayerESPNViewModel>> EspnPlayers(EspnPlayersRequestObject request);
        Task<RulesESPNViewModel> EspnRules(EspnRulesRequestObject request);
        Task<RulesViewModel> LeagueRules(LeagueRulesRequestObject request);
        Task<List<PlayerViewModel>> PlayerProjections(PlayerProjectionsRequestObject request);
        Task<PointAveragesViewModel> PointAverages(PointAveragesRequestObject request);
        Task<List<RosterViewModel>> PossibleRosters(PossibleRostersRequestObject request);
        Task<List<PlayerViewModel>> RelativePoints(RelativePointsRequestObject request);
        Task<RosterViewModel> StrongerRoster(StrongerRosterRequestObject request);
        Task<RosterViewModel> StrongRoster(StrongRosterRequestObject request);
        Task<List<DraftBoardViewModel>> SuggestedRosters(SuggestedRostersRequestObject request);
        Task<List<PlayerViewModel>> Tags(TagsRequestObject request);
        Task<CountByIDViewModel> TopRosterFrequency(TopRosterFrequencyRequestObject request);
        Task<List<PlayerViewModel>> TopRosterPercent(TopRosterPercentRequestObject request);
        Task<List<int>> TopRosterPlayers(TopRosterPlayersRequestObject request);
        

    }
}
