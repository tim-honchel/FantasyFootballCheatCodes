using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class LeagueRulesRequestObject
    {
        public Provider Provider { get; set; }
        public RulesESPNViewModel EspnRules { get; set; } = new();
    }

    public enum Provider
    {
        ESPN
    }
}
