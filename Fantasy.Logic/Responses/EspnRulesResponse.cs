
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class EspnRulesResponse : BaseResponse
    {
        public RulesESPN Rules { get; set; } = new();
    }
}
