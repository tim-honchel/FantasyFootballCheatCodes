using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class EditProjectionsRequest
    {
        public List<Player> Players { get; set; } = new();
    }
}
