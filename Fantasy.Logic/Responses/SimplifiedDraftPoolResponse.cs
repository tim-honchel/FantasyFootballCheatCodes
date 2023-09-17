
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class SimplifiedDraftPoolResponse : BaseResponse
    {
        public List<Player> Players { get; set; } = new();
    }
}
