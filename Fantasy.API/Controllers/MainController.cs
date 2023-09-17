using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Fantasy.API.Controllers
{
    [ApiController]
    [Route("")]
    public class MainController : ControllerBase
    {
        public ICostAnalysisLogic _costAnalysisLogic;
        public ICsvStartersLogic _csvStartersLogic;
        public ICsvSuggestedRostersLogic _csvSuggestedRostersLogic;
        public IEditProjectionsLogic _editProjectionsLogic;
        public IEspnPlayersLogic _espnPlayersLogic;
        public IEspnRulesLogic _espnRulesLogic;
        public IExpectedValueLogic _expectedValueLogic;
        public ILeagueRulesLogic _leagueRulesLogic;
        public IPlayerProjectionsLogic _playerProjectionsLogic;
        public IPointAveragesLogic _pointAveragesLogic;
        public IPossibleRostersLogic _possibleRostersLogic;
        public IRelativePointsLogic _relativePointsLogic;
        public ISimplifiedDraftPoolLogic _simplifiedDraftPoolLogic;
        public IStrongRosterLogic _strongRosterLogic;
        public IStrongerRosterLogic _strongerRosterLogic;
        public ISuggestedRostersLogic _suggestedRostersLogic;
        public ITagsLogic _tagsLogic;
        public ITopRosterFrequencyLogic _topRosterFrequencyLogic;
        public ITopRosterPercentLogic _topRosterPercentLogic;
        public ITopRosterPlayersLogic _topRosterPlayersLogic;
        public IValidRulesLogic _validRulesLogic;

        public MainController(ICostAnalysisLogic costAnalysisLogic, ICsvStartersLogic csvStartersLogic, ICsvSuggestedRostersLogic csvSuggestedRostersLogic, IEditProjectionsLogic editProjectionsLogic, IEspnPlayersLogic espnPlayersLogic, IEspnRulesLogic espnRulesLogic, IExpectedValueLogic expectedValueLogic, ILeagueRulesLogic leagueRulesLogic, IPlayerProjectionsLogic playerProjectionsLogic, IPointAveragesLogic pointAveragesLogic, IPossibleRostersLogic possibleRostersLogic, IRelativePointsLogic relativePointsLogic, ISimplifiedDraftPoolLogic simplifiedDraftPoolLogic, IStrongRosterLogic strongRosterLogic, IStrongerRosterLogic strongerRosterLogic, ISuggestedRostersLogic suggestedRostersLogic, ITagsLogic tagsLogic, ITopRosterFrequencyLogic topRosterFrequencyLogic, ITopRosterPercentLogic topRosterPercentLogic, ITopRosterPlayersLogic topRosterPlayersLogic, IValidRulesLogic validRulesLogic)
        {
            _costAnalysisLogic = costAnalysisLogic;
            _csvStartersLogic = csvStartersLogic;
            _csvSuggestedRostersLogic = csvSuggestedRostersLogic;
            _editProjectionsLogic = editProjectionsLogic;
            _espnPlayersLogic = espnPlayersLogic;
            _espnRulesLogic = espnRulesLogic;
            _expectedValueLogic = expectedValueLogic;
            _leagueRulesLogic = leagueRulesLogic;
            _playerProjectionsLogic = playerProjectionsLogic;
            _pointAveragesLogic = pointAveragesLogic;
            _possibleRostersLogic = possibleRostersLogic;
            _relativePointsLogic = relativePointsLogic;
            _simplifiedDraftPoolLogic = simplifiedDraftPoolLogic;
            _strongRosterLogic = strongRosterLogic;
            _strongerRosterLogic = strongerRosterLogic;
            _suggestedRostersLogic = suggestedRostersLogic;
            _tagsLogic = tagsLogic;
            _topRosterFrequencyLogic = topRosterFrequencyLogic;
            _topRosterPercentLogic = topRosterPercentLogic;
            _topRosterPlayersLogic = topRosterPlayersLogic;
            _validRulesLogic = validRulesLogic;
        }

        [HttpPost("costAnalysis")]
        public IActionResult CostAnalysis([FromBody] CostAnalysisRequest request)
        {
            CostAnalysisResponse response = _costAnalysisLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("csvStarters")]
        public IActionResult CsvStarters([FromBody] CsvStartersRequest request)
        {
            string csv = _csvStartersLogic.Get(request);
            var fileBytes = Encoding.UTF8.GetBytes(csv);
            return File(fileBytes, "text/csv", "FantasyStarters.csv");
        }

        [HttpPost("csvSuggestedRosters")]
        public IActionResult CsvSuggestedRosters(CsvSuggestedRosterRequest request)
        {
            string csv = _csvSuggestedRostersLogic.Get(request);
            var fileBytes = Encoding.UTF8.GetBytes(csv);
            return File(fileBytes, "text/csv", "FantasySuggestedRosters.csv");
        }

        [HttpPut("editProjections")]
        public IActionResult EditProjections([FromBody] EditProjectionsRequest request)
        {
            EditProjectionsResponse response = _editProjectionsLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("espnPlayers")]
        public async Task<IActionResult> EspnPlayers([FromBody]EspnPlayersRequest request)
        {
            EspnPlayersResponse response = await _espnPlayersLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("espnRules")]
        public async Task<IActionResult> EspnRules([FromBody] EspnRulesRequest request)
        {
            EspnRulesResponse response = await _espnRulesLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPut("expectedValue")]
        public IActionResult ExpectedValue([FromBody] ExpectedValueRequest request)
        {
            ExpectedValueResponse response = _expectedValueLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("leagueRules")]
        public IActionResult LeagueRules([FromBody] LeagueRulesRequest request)
        {
            LeagueRulesResponse response = _leagueRulesLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("playerProjections")]
        public IActionResult PlayerProjections([FromBody] PlayerProjectionsRequest request)
        {
            PlayerProjectionsResponse response = _playerProjectionsLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("pointAverages")]
        public IActionResult PointAverages([FromBody] PointAveragesRequest request)
        {
            PointAveragesResponse response = _pointAveragesLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("possibleRosters")]
        public IActionResult PossibleRosters([FromBody] PossibleRostersRequest request)
        {
            PossibleRostersResponse response = _possibleRostersLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("relativePoints")]
        public IActionResult RelativePoints([FromBody] RelativePointsRequest request)
        {
             RelativePointsResponse response = _relativePointsLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("simplifiedDraftPool")]
        public IActionResult SimplifiedDraftPool([FromBody] SimplifiedDraftPoolRequest request)
        {
            SimplifiedDraftPoolResponse response = _simplifiedDraftPoolLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPut("strongerRoster")]
        public IActionResult StrongerRoster([FromBody] StrongerRosterRequest request)
        {
            StrongerRosterResponse response = _strongerRosterLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("strongRoster")]
        public IActionResult StrongRoster([FromBody] StrongRosterRequest request)
        {
            StrongRosterResponse response = _strongRosterLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("suggestedRosters")]
        public IActionResult SuggestedRosters([FromBody] SuggestedRostersRequest request)
        {
            SuggestedRostersResponse response = _suggestedRostersLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPut("tags")]
        public IActionResult Tags([FromBody] TagsRequest request)
        {
            TagsResponse response = _tagsLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("topRosterFrequency")]
        public IActionResult TopRosterFrequency([FromBody] TopRosterFrequencyRequest request)
        {
            TopRosterFrequencyResponse response = _topRosterFrequencyLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("topRosterPercent")]
        public IActionResult TopRosterPercent([FromBody] TopRosterPercentRequest request)
        {
            TopRosterPercentResponse response = _topRosterPercentLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("topRosterPlayers")]
        public IActionResult TopRosterPlayers([FromBody] TopRosterPlayersRequest request)
        {
            TopRosterPlayersResponse response = _topRosterPlayersLogic.Get(request);
            return new OkObjectResult(response);
        }

        [HttpPost("validRules")]
        public IActionResult ValidRules([FromBody] ValidRulesRequest request)
        {
            ValidRulesResponse response = _validRulesLogic.Get(request);
            return new OkObjectResult(response);
        }

    }  
}