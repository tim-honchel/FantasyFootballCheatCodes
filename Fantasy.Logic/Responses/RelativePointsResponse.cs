
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class RelativePointsResponse : BaseResponse
    {
        public List<Player> Players { get; set; } = new();
    }
}
