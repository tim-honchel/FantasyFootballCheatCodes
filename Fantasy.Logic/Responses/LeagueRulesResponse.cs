
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class LeagueRulesResponse : BaseResponse
    {
        public Rules Rules { get; set; } = new();
    }
}
