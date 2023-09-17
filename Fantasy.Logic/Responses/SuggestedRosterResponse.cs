
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class SuggestedRostersResponse : BaseResponse
    {
        public List<DraftBoard> DraftBoard { get; set; } = new();
    }
}
