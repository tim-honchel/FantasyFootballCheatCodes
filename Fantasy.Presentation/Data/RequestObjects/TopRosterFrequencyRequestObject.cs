using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class TopRosterFrequencyRequestObject
    {
        public List<RosterViewModel> Rosters { get; set; } = new();
    }
}
