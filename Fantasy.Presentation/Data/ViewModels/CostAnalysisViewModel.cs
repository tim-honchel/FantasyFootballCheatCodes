namespace Fantasy.Presentation.Data.ViewModels
{
    public class CostAnalysisViewModel
    {
        public Dictionary<string, double> PositionCostBase { get; set; } = new();
        public Dictionary<string, double> PositionCostMultiplier { get; set; } = new();
        public Dictionary<string, double> PositionCostErrorMargin { get; set; } = new();
    }
}
