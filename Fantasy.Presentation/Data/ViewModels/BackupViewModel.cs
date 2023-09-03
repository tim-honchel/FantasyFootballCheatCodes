namespace Fantasy.Logic.Models
{
    public class BackupViewModel
    {
        public int PlayerID { get; set; } = 0;
        public string LastName { get; set; } = string.Empty;
        public string FirstInitial { get; set; } = string.Empty;
        public string Position { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public int Cost { get; set; } = 0;
        public int WeeklyPoints { get; set; } = 0;
        public int FloorPoints { get; set; } = 0;
        public int CurrentRolePoints { get; set; } = 0;
        public int StarterPoints { get; set; } = 0;
        public int CeilingPoints { get; set; } = 0;
        public int FloorProbability { get; set; } = 0;
        public int CurrentRoleProbability { get; set; } = 0;
        public int StarterProbability { get; set; } = 0;
        public int CeilingProbability { get; set; } = 0;
        public int WeightedPoints { get; set; } = 0;
        public int WeightedValue { get; set; } = 0;

    }
}
