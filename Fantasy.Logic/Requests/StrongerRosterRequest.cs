using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class StrongerRosterRequest
    {
        public Rules Rules { get; set; }
        public Roster Roster { get; set; }
        public List<Player> Players { get; set; }
    }
}
