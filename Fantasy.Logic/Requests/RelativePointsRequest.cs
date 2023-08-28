using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class RelativePointsRequest
    {
        PointAverages PointAverages { get; set; }
        List<Player> Players { get; set; }
    }
}
