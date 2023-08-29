using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class SuggestedRostersRequest
    {
        List<Player> Players { get; set; }
        List<Roster> Rosters { get; set; }
        List<int> PlayerIDs { get; set; }
    }
}
