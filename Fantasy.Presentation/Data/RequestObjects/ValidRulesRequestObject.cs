using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class ValidRulesRequestObject
    {
        public RulesViewModel Rules { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
