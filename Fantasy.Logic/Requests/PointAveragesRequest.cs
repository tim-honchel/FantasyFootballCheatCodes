using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class PointAveragesRequest
    {
        public Rules Rules { get; set; }
        public List<Player> Players { get; set; }
    }
}
