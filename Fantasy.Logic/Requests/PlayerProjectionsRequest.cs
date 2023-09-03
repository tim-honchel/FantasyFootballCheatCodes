using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class PlayerProjectionsRequest
    {
        public List<PlayerESPN> Players { get; set; } = new();
    }
}
