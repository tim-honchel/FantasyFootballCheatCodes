
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class EspnPlayersResponse : BaseResponse
    {
        public List<PlayerESPN> Players { get; set; } = new();
    }
}
