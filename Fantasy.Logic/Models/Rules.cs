namespace Fantasy.Logic.Models
{
    public class Rules
    {
        public int LeagueID { get; set; }
        public int Teams { get; set; }
        public int PlayoffTeams { get; set; }
        public int SalaryCap { get; set; }
        public int QB { get; set; }
        public int RB { get; set; }
        public int WR { get; set; }
        public int TE { get; set; }
        public int FLEX { get; set; }
        public int DEF { get; set; }
        public int K { get; set; }
        public int Bench { get; set; }
        public int MaxRB { get; set; }
        public bool Supported { get; set; }
        public List<string> ReasonsNotSupported { get; set; } = new List<string>();

    }
}
