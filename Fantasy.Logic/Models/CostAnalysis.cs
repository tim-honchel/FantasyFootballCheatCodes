namespace Fantasy.Logic.Models
{
    public class CostAnalysis
    {
        public Dictionary<string, double> PositionCostMultiplier { get; set; } = new();
        public Dictionary<string, double> PositionCostErrorMargin { get; set; } = new();

    }
}
