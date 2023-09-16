using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
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
            CostAnalysis analysis = _costAnalysisLogic.Get(request.Players);
            return new OkObjectResult(analysis);
        }

        [HttpPost("csvStarters")]
        public IActionResult CsvStarters([FromBody] CsvStartersRequest request)
        {
            string csv = _csvStartersLogic.Get(request.Players);
            var fileBytes = Encoding.UTF8.GetBytes(csv);
            return File(fileBytes, "text/csv", "FantasyStarters.csv");
        }

        [HttpPost("csvSuggestedRosters")]
        public IActionResult CsvSuggestedRosters(CsvSuggestedRosterRequest request)
        {
            string csv = _csvSuggestedRostersLogic.Get(request.DraftBoards);
            var fileBytes = Encoding.UTF8.GetBytes(csv);
            return File(fileBytes, "text/csv", "FantasySuggestedRosters.csv");
        }

        [HttpPut("editProjections")]
        public IActionResult EditProjections([FromBody] List<Player> editedPlayers)
        {
            List<Player> players = _editProjectionsLogic.Get(editedPlayers);
            return new OkObjectResult(players);
        }

        [HttpPut("expectedValue")]
        public IActionResult ExpectedValue([FromBody] ExpectedValueRequest request)
        {
            List<Player> updatedPlayers = _expectedValueLogic.Get(request.CostAnalysis, request.Players);
            return new OkObjectResult(updatedPlayers);
        }

        [HttpPost("espnPlayers")]
        public async Task<IActionResult> EspnPlayers([FromBody]EspnPlayersRequest request)
        {
            List<PlayerESPN> players = await _espnPlayersLogic.Get(request.LeagueID, request.espn_s2, request.swid);
            return new OkObjectResult(players);
        }

        [HttpPost("espnRules")]
        public async Task<IActionResult> EspnRules([FromBody] EspnRulesRequest request)
        {
            RulesESPN rules = await _espnRulesLogic.Get(request.LeagueID, request.espn_s2, request.swid);
            return new OkObjectResult(rules);
        }

        [HttpPost("leagueRules")]
        public IActionResult LeagueRules([FromBody] LeagueRulesRequest request)
        {
            Rules parsedRules = _leagueRulesLogic.Get(request.Rules);
            return new OkObjectResult(parsedRules);
        }

        [HttpPost("playerProjections")]
        public IActionResult PlayerProjections([FromBody] PlayerProjectionsRequest request)
        {
            List<Player> parsedPlayers = _playerProjectionsLogic.Get(request.Players);
            return new OkObjectResult(parsedPlayers);
        }

        [HttpPost("pointAverages")]
        public IActionResult PointAverages([FromBody] PointAveragesRequest request)
        {
            PointAverages averages = _pointAveragesLogic.Get(request.Players, request.Rules);
            return new OkObjectResult(averages);
        }

        [HttpPost("possibleRosters")]
        public IActionResult PossibleRosters([FromBody] PossibleRostersRequest request)
        {
            List<Roster> rosters = _possibleRostersLogic.Get(request.Roster, request.Players, request.Rules);
            return new OkObjectResult(rosters);
        }

        [HttpPost("relativePoints")]
        public IActionResult RelativePoints([FromBody] RelativePointsRequest request)
        {
            List<Player> players = _relativePointsLogic.Get(request.PointAverages, request.Players);
            return new OkObjectResult(players);
        }

        [HttpPost("simplifiedDraftPool")]
        public IActionResult SimplifiedDraftPool([FromBody] SimplifiedDraftPoolRequest request)
        {
            List<Player> players = _simplifiedDraftPoolLogic.Get(request.Players, request.PointAverages);
            return new OkObjectResult(players);
        }

        [HttpPut("strongerRoster")]
        public IActionResult StrongerRoster([FromBody] StrongerRosterRequest request)
        {
            Roster roster = _strongerRosterLogic.Get(request.Roster, request.Players, request.Rules);
            return new OkObjectResult(roster);
        }

        [HttpPost("strongRoster")]
        public IActionResult StrongRoster([FromBody] StrongRosterRequest request)
        {
            Roster roster = _strongRosterLogic.Get(request.Players, request.Rules);
            return new OkObjectResult(roster);
        }

        [HttpPost("suggestedRosters")]
        public IActionResult SuggestedRosters([FromBody] SuggestedRostersRequest request)
        {
            List<DraftBoard> draftBoard = _suggestedRostersLogic.Get(request.Players, request.Rosters, request.PlayerIDs);
            return new OkObjectResult(draftBoard);
        }

        [HttpPut("tags")]
        public IActionResult Tags([FromBody] TagsRequest request)
        {
            List<Player> taggedPlayers = _tagsLogic.Get(request.Players);
            return new OkObjectResult(taggedPlayers);
        }

        [HttpPost("topRosterFrequency")]
        public IActionResult TopRosterFrequency([FromBody] TopRosterFrequencyRequest request)
        {
            CountByID frequency = _topRosterFrequencyLogic.Get(request.Rosters);
            return new OkObjectResult(frequency);
        }

        [HttpPost("topRosterPercent")]
        public IActionResult TopRosterPercent([FromBody] TopRosterPercentRequest request)
        {
            List<Player> players = _topRosterPercentLogic.Get(request.Players, request.Frequency);
            return new OkObjectResult(players);
        }

        [HttpPost("topRosterPlayers")]
        public IActionResult TopRosterPlayers([FromBody] TopRosterPlayersRequest request)
        {
            List<int> playerIDs = _topRosterPlayersLogic.Get(request.Players, request.Rules);
            return new OkObjectResult(playerIDs);
        }

        [HttpPost("validRules")]
        public IActionResult ValidRules([FromBody] ValidRulesRequest request)
        {
            RuleValidity response = _validRulesLogic.Get(request.Rules, request.Players);
            return new OkObjectResult(response);
        }

    }  
}