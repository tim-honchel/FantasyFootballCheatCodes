
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class ValidRulesResponse : BaseResponse
    {
        public List<string> ValidationErrors { get; set; } = new();
    }
}
