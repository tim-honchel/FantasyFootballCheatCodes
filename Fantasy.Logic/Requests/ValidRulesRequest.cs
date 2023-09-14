
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class ValidRulesRequest
    {
        public Rules Rules { get; set; } = new();
        public List<Player> Players { get; set; } = new();
    }
}
