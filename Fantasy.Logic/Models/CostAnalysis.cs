namespace Fantasy.Logic.Models
{
    public class CostAnalysis
    {
        public double QBSlope { get; set; } = 0;
        public double QBIntercept { get; set; } = 0;
        public double QBResidual { get; set; } = 0;
        public double RBSlope { get; set; } = 0;
        public double RBIntercept { get; set; } = 0;
        public double RBResidual { get; set; } = 0;
        public double RB1EffectUp { get; set; } = 0;
        public double RB1EffectDown { get; set; } = 0;
        public double WRSlope { get; set; } = 0;
        public double WRIntercept { get; set; } = 0;
        public double WRResidual { get; set; } = 0;
        public double TESlope { get; set; } = 0;
        public double TEIntercept { get; set; } = 0;
        public double TEResidual { get; set; } = 0;
    }
}
