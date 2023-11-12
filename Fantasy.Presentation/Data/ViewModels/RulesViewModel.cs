namespace Fantasy.Presentation.Data.ViewModels
{
    public class RulesViewModel
    {
            public int LeagueID { get; set; } = 0;
            public Positions Positions { get; set; } = new Positions();
            public Settings Settings { get; set; } = new Settings();
            public Size Size { get; set; } = new Size();
            public Status Status { get; set; } = new Status();

        }

        public class Positions
        {
            public int[] Quarterbacks { get; set; } = new int[2];
            public int[] RunningBacks { get; set; } = new int[2];
            public int[] WideReceivers { get; set; } = new int[2];
            public int[] TightEnds { get; set; } = new int[2];
            public int FLEX { get; set; } = 0;
            public int[] TeamDefenses { get; set; } = new int[2];
            public int[] Kickers { get; set; } = new int[2];
            public int Bench { get; set; } = 0;
            public int InjuredReserve { get; set; } = 0;
            public int[] TeamQuarterbacks { get; set; } = new int[2];
            public int BacksAndReceivers { get; set; } = 0;
            public int ReceiversAndEnds { get; set; } = 0;
            public int OffensivePlayerUtilities { get; set; } = 0;
            public int[] DefensiveTackles { get; set; } = new int[2];
            public int[] DefensiveEnds { get; set; } = new int[2];
            public int[] Linebackers { get; set; } = new int[2];
            public int DefensiveLinemen { get; set; } = 0;
            public int[] Cornerbacks { get; set; } = new int[2];
            public int[] Safeties { get; set; } = new int[2];
            public int DefensiveBacks { get; set; } = 0;
            public int DefensivePlayerUtilities { get; set; } = 0;
            public int[] Punters { get; set; } = new int[2];
            public int[] Coaches { get; set; } = new int[2];
        }
        public class Settings
        {
            public DraftType DraftType { get; set; }
            public DraftOrderType DraftOrderType { get; set; }
            public int DraftPick { get; set; } = 0;
            public bool IsTradingEnabled { get; set; } = false;
            public bool Keeper { get; set; } = false;
            public int SalaryCap { get; set; } = 0;
            public ScoringType ScoringType { get; set; }
        }
        public class Size
        {
            public int Teams { get; set; } = 0;
            public int PlayoffTeams { get; set; } = 0;
        }
        public class Status
        {
            public bool DraftComplete { get; set; } = false;
            public bool DraftInProgress { get; set; } = false;
            public int Season { get; set; } = 0;
            public bool IsActive { get; set; } = false;
        }

        public enum DraftType
        {
            Auction,
            Snake,
            Other
        }

        public enum DraftOrderType
        {
            Automatic,
            Manual,
            None,
            Other
        }

        public enum ScoringType
        {
            HeadToHead,
            Points,
            Other
        }
    }



