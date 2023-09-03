namespace Fantasy.Presentation.Data.ViewModels
{
    public class PlayerESPNViewModel
    {
        public int ID { get; set; } = 0;
        public int DraftAuctionValue { get; set; } = 0;
        public int KeeperValue { get; set; } = 0;
        public int DefaultPositionID { get; set; } = 0;
        public List<int> EligibleSlots { get; set; } = new();
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public bool Active { get; set; } = false;
        public bool Injured { get; set; } = false;
        public string InjuryStatus { get; set; } = string.Empty;
        public double AverageDraftPosition { get; set; } = 0;
        public double PercentOwned { get; set; } = 0;
        public double PercentStarted { get; set; } = 0;
        public int ProTeamID { get; set; } = 0;
        public double LastYearAveragePointsPerWeek { get; set; } = 0;
        public double ThisYearProjectedPointsPerWeek { get; set; } = 0;


    }
}
