namespace Fantasy.Logic.Models
{
    public class Backup
    {
        public int PlayerID { get; set; }
        public string LastName { get; set; } = "";
        public string FirstInitial { get; set; } = "";
        public string Position { get; set; } = "";
        public string Team { get; set; } = "";
        public int Cost { get; set; }
        public int WeeklyPoints { get; set; }
        public int FloorPoints { get; set; }
        public int CurrentRolePoints { get; set; }
        public int StarterPoints { get; set; }
        public int CeilingPoints { get; set; }
        public int FloorProbability { get; set;}
        public int CurrentRoleProbability { get; set; }
        public int StarterProbability { get; set; }
        public int CeilingProbability { get; set; }
        public int WeightedPoints { get; set; }
        public int WeightedValue { get; set; }

    }
}
