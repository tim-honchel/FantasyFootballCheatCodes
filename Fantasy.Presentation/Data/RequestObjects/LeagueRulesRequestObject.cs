using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class LeagueRulesRequestObject
    {
        public RulesESPNViewModel Rules { get; set; } = new();
    }
}
