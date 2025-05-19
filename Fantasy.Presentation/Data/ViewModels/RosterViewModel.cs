namespace Fantasy.Presentation.Data.ViewModels
{
    public class RosterViewModel
    {
        public double TotalPoints { get; set; } = 0;
        public int Cost { get; set; } = 0;
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
