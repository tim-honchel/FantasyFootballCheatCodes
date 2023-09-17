
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class TagsResponse : BaseResponse
    {
        public List<Player> Players { get; set; } = new();
    }
}
