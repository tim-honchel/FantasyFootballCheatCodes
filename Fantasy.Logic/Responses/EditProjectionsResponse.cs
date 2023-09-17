
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class EditProjectionsResponse : BaseResponse
    {
        public List<Player> Players { get; set; } = new();
    }
}
