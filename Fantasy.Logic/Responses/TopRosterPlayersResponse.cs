
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class TopRosterPlayersResponse : BaseResponse
    {
       public List<int> PlayerIDs { get; set; } = new();
    }
}
