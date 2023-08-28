using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class StrongerRosterRequest
    {
        Rules Rules { get; set; }
        Roster Roster { get; set; }
        List<Player> Players { get; set; }
    }
}
