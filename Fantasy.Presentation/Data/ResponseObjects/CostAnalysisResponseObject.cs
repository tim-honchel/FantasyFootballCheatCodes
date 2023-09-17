using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class CostAnalysisResponseObject : BaseResponseObject
    {
        public CostAnalysisViewModel Analysis { get; set; } = new();
    }
}
