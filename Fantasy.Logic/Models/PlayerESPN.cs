namespace Fantasy.Logic.Models
{
    public class PlayerESPN
    {
        public int ID { get; set; }
        public int DraftAuctionValue { get; set; }
        public int KeeperValue { get; set; }
        public int DefaultPositionID { get; set; }
        public List<int> EligibleSlots { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public bool Active { get; set; }
        public bool Injured { get; set; }
        public string InjuryStatus { get; set; } = "";
        public double AverageDraftPosition { get; set; }
        public double PercentOwned { get; set; }
        public double PercentStarted { get; set; }
        public int ProTeamID { get; set; }
        public double LastYearAveragePointsPerWeek { get; set; }
        public double ThisYearProjectedPointsPerWeek { get; set; }


    }
}
