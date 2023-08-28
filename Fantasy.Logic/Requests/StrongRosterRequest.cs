using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class StrongRosterRequest
    {
        Rules Rules { get; set; }
        List<Player> Players { get; set; }
    }
}
