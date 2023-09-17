
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class CostAnalysisResponse : BaseResponse
    {
        public CostAnalysis Analysis { get; set; } = new();
    }
}
