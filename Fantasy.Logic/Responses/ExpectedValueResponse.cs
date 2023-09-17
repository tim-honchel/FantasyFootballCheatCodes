
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class ExpectedValueResponse : BaseResponse
    {
        public List<Player> Players { get; set; } = new();
    }
}
