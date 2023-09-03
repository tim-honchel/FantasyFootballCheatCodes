using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class LeagueRulesRequest
    {
        public RulesESPN Rules { get; set; } = new();
    }
}
