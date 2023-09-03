using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class PossibleRostersRequestObject
    {
        public RulesViewModel Rules { get; set; } = new();
        public RosterViewModel Roster { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
