
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class StrongRosterResponse : BaseResponse
    {
        public Roster Roster { get; set; } = new();
    }
}
