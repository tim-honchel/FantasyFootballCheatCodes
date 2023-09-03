
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class TopRosterFrequencyRequest
    {
        public List<Roster> Rosters { get; set; } = new();
    }
}
