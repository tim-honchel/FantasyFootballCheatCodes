namespace Fantasy.Logic.Models
{
    public class Roster
    {
        public double TotalPoints { get; set; } = 0;
        public int Cost { get; set; } = 0;
        public List<Player> Players { get; set; } = new();
    }
}
