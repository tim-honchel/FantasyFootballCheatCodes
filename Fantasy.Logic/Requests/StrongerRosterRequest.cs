using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class StrongerRosterRequest
    {
        public Rules Rules { get; set; } = new();
        public Roster Roster { get; set; } = new();
        public List<Player> Players { get; set; } = new();
    }
}
