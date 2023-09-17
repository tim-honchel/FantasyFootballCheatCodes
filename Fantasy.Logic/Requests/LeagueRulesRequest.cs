using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class LeagueRulesRequest
    {
        public Provider Provider { get; set; }
        public RulesESPN EspnRules { get; set; } = new();
    }

    public enum Provider
    {
        ESPN
    }
}
