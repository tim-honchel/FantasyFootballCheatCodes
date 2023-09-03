namespace Fantasy.Logic.Models
{
    public class RulesESPN
    {
        public int LeagueID { get; set; } = 0;
        public bool DraftComplete { get; set; } = false;
        public bool DraftInProgress { get; set; } = false;
        public int Season { get; set; } = 0;
        public string DraftType { get; set; } = string.Empty;
        public string LeagueSubType { get; set; } = string.Empty;
        public string DraftOrderType { get; set; } = string.Empty;
        public int AuctionBudget { get; set; } = 0;
        public bool IsTradingEnabled { get; set; } = false;
        public int KeeperCount { get; set; } = 0;
        public Dictionary<string, int> PositionSlotCounts { get; set; } = new();
        public Dictionary<string, int> PositionLimits { get; set; } = new();
        public int MatchupPeriods { get; set; } = 0;
        public int MatchupPeriodLength { get; set; } = 0;
        public int PlayoffMatchupPeriodLength { get; set; } = 0;
        public string PlayoffSeedingRule { get; set; } = string.Empty;
        public int Teams { get; set; } = 0;
        public int PlayoffTeams { get; set; } = 0;
        public string ScoringType { get; set; } = string.Empty;
        public bool IsActive { get; set; } = false;

    }
}
