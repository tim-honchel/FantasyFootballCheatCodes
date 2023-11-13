using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.State;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Interfaces;

namespace Fantasy.Presentation.Services.Implementations
{
    public class StrategyService :IStrategyService
    {
        IApiCallService _callService;
        UserData _userData;

        public StrategyService(IApiCallService callService, UserData userData)
        {
            _callService = callService;
            _userData = userData;
        }
        public async Task<bool> EvaluatePlayers()
        {
            try
            {
                PointAveragesRequestObject pointAveragesRequest = new PointAveragesRequestObject() { Players = _userData.Players, Rules = _userData.Rules };
                PointAveragesViewModel pointAverages = await _callService.PointAverages(pointAveragesRequest);

                RelativePointsRequestObject relativePointsRequest = new RelativePointsRequestObject() { Players = _userData.Players, PointAverages = pointAverages };
                _userData.Players = await _callService.RelativePoints(relativePointsRequest);

                CostAnalysisRequestObject costAnalysisRequest = new CostAnalysisRequestObject() { Players = _userData.Players};
                CostAnalysisViewModel costAnalysis = await _callService.CostAnalysis(costAnalysisRequest);

                ExpectedValueRequestObject expectedValueRequest = new ExpectedValueRequestObject() { CostAnalysis = costAnalysis, Players = _userData.Players};
                _userData.Players = await _callService.ExpectedValue(expectedValueRequest);
            
                SimplifiedDraftPoolRequestObject simplifiedDraftPoolRequest = new SimplifiedDraftPoolRequestObject() { Players = _userData.Players };
                List<PlayerViewModel> simplifiedDraftPool = await _callService.SimplifiedDraftPool(simplifiedDraftPoolRequest);

                StrongRosterRequestObject strongRosterRequest = new StrongRosterRequestObject() { Players = simplifiedDraftPool, Rules = _userData.Rules };
                RosterViewModel strongRoster = await _callService.StrongRoster(strongRosterRequest);

                StrongerRosterRequestObject strongerRosterRequest = new StrongerRosterRequestObject() { Players = _userData.Players, Roster = strongRoster, Rules = _userData.Rules };
                RosterViewModel strongerRoster = await _callService.StrongerRoster(strongerRosterRequest);

                PossibleRostersRequestObject possibleRostersRequest = new PossibleRostersRequestObject() { Players = _userData.Players, Roster = strongerRoster, Rules = _userData.Rules };
                List<RosterViewModel> possibleRosters = await _callService.PossibleRosters(possibleRostersRequest);

                TopRosterFrequencyRequestObject topRosterFrequencyRequest = new TopRosterFrequencyRequestObject() { Rosters = possibleRosters };
                CountByIDViewModel countByID = await _callService.TopRosterFrequency(topRosterFrequencyRequest);

                TopRosterPercentRequestObject topRosterPercentRequest = new TopRosterPercentRequestObject() { Frequency = countByID, Players = _userData.Players };
                _userData.Players = await _callService.TopRosterPercent(topRosterPercentRequest);

                TagsRequestObject tagsRequest = new TagsRequestObject() { Players = _userData.Players };
                _userData.Players = await _callService.Tags(tagsRequest);

                return true;
            }
            catch (NotImplementedException e)
            {
                return false;
            }
        }
    }
}
