
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class StrongerRosterResponse : BaseResponse
    {
        public Roster Roster { get; set; } = new();
    }
}
