using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class SuggestedRostersRequestObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
        public List<RosterViewModel> Rosters { get; set; } = new();
        public List<int> PlayerIDs { get; set; } = new();
    }
}
