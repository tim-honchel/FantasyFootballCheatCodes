
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class TopRosterPercentResponse : BaseResponse
    {
        public List<Player> Players { get; set; } = new();
    }
}
