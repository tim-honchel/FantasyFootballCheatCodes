using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class SimplifiedDraftPoolRequest
    {
        public PointAverages PointAverages { get; set; } = new();
        public List<Player> Players { get; set; } = new();
    }
}
