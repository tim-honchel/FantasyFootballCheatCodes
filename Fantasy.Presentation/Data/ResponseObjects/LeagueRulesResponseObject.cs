using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class LeagueRulesResponseObject : BaseResponseObject
    {
        public RulesViewModel Rules { get; set; } = new();
    }
}
