namespace Fantasy.Logic.Models
{
    public class Player
    {
        public int PlayerID { get; set; } = 0;
        public string LastName { get; set; } = string.Empty;
        public string FirstInitial { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public int Cost { get; set; } = 0;
        public double WeeklyPoints { get; set; } = 0;
        public Dictionary<string, double> RelativePoints = new();
        public double FA { get; set; } = 0;
        public double ExpectedValueLow { get; set; } = 0;
        public double ExpectedValue { get; set; } = 0;
        public double ExpectedValueHigh { get; set; } = 0;
        public double PercentOfTopRosters { get; set; } = 0;
        public List<string> Tags { get; set; } = new();
    }
}
