namespace Fantasy.Logic.Models
{
    public class RulesEPSN
    {
        public int LeagueID { get; set; }
        public bool DraftComplete { get; set; }
        public bool DraftInProgress { get; set; }
        public int Season { get; set; }
        public string DraftType { get; set; } = "";
        public string LeagueSubType { get; set; } = "";
        public string DraftOrderType { get; set; } = "";
        public int AuctionBudget { get; set; }
        public bool IsTradingEnabled { get; set; }
        public int KeeperCount { get; set; }
        public Dictionary<string, int> PositionSlotCounts { get; set; }
        public Dictionary<string, int> PositionLimits { get; set; }
        public int MatchupPeriods { get; set; }
        public int MatchupPeriodLength { get; set; }
        public int PlayoffMatchupPeriodLength { get; set; }
        public string PlayoffSeedingRule { get; set; } = "";
        public int Teams { get; set; }
        public int PlayoffTeams { get; set; }
        public string ScoringType { get; set; } = "";
        public bool IsActive { get; set; }

    }
}
