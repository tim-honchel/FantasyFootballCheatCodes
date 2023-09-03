using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class SuggestedRostersRequest
    {
        public List<Player> Players { get; set; } = new();
        public List<Roster> Rosters { get; set; } = new();
        public List<int> PlayerIDs { get; set; } = new();
    }
}
