namespace Fantasy.Presentation.Data.ViewModels
{
    public class PlayerViewModel
    {
        public int PlayerID { get; set; } = 0;
        public string LastName { get; set; } = string.Empty;
        public string FirstInitial { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public int Cost { get; set; } = 0;
        public double WeeklyPoints { get; set; } = 0;
        public double QB1 { get; set; } = 0;
        public double QB2 { get; set; } = 0;
        public double RB1 { get; set; } = 0;
        public double RB2 { get; set; } = 0;
        public double RB3 { get; set; } = 0;
        public double WR1 { get; set; } = 0;
        public double WR2 { get; set; } = 0;
        public double WR3 { get; set; } = 0;
        public double TE1 { get; set; } = 0;
        public double TE2 { get; set; } = 0;
        public double FLEX1 { get; set; } = 0;
        public double RBWR1 { get; set; } = 0;
        public double WRTE1 { get; set; } = 0;
        public double OPU1 { get; set; } = 0;
        public double TQB1 { get; set; } = 0;
        public double DEF1 { get; set; } = 0;
        public double DT1 { get; set; } = 0;
        public double DT2 { get; set; } = 0;
        public double DE1 { get; set; } = 0;
        public double DE2 { get; set; } = 0;
        public double LB1 { get; set; } = 0;
        public double LB2 { get; set; } = 0;
        public double CB1 { get; set; } = 0;
        public double CB2 { get; set; } = 0;
        public double S1 { get; set; } = 0;
        public double S2 { get; set; } = 0;
        public double DL1 { get; set; } = 0;
        public double DB1 { get; set; } = 0;
        public double DPU1 { get; set; } = 0;
        public double K1 { get; set; } = 0;
        public double P1 { get; set; } = 0;
        public double HC1 { get; set; } = 0;
        public double FA { get; set; } = 0;
        public double ExpectedValueLow { get; set; } = 0;
        public double ExpectedValue { get; set; } = 0;
        public double ExpectedValueHigh { get; set; } = 0;
        public double PercentOfTopRosters { get; set; } = 0;
        public List<string> Tags { get; set; } = new();
    }
}
