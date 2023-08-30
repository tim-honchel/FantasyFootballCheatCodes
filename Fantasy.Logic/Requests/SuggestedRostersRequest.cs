using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class SuggestedRostersRequest
    {
        public List<Player> Players { get; set; }
        public List<Roster> Rosters { get; set; }
        public List<int> PlayerIDs { get; set; }
    }
}
