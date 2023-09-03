using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class ExpectedValueRequestObject
    {
        public CostAnalysisViewModel CostAnalysis { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
