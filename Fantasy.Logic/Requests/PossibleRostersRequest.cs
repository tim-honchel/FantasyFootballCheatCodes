using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class PossibleRostersRequest
    {
        public Rules Rules { get; set; } = new();
        public Roster Roster { get; set; } = new();
        public List<Player> Players { get; set; } = new();
    }
}
