namespace Fantasy.Logic.Models
{
    public class RulesViewModel
    {
        public int LeagueID { get; set; } = 0;
        public int Teams { get; set; } = 0;
        public int PlayoffTeams { get; set; } = 0;
        public int SalaryCap { get; set; } = 0;
        public int QB { get; set; } = 0;
        public int RB { get; set; } = 0;
        public int WR { get; set; } = 0;
        public int TE { get; set; } = 0;
        public int FLEX { get; set; } = 0;
        public int DEF { get; set; } = 0;
        public int K { get; set; } = 0;
        public int Bench { get; set; } = 0;
        public int MaxRB { get; set; } = 0;
        public bool Supported { get; set; } = false;
        public List<string> ReasonsNotSupported { get; set; } = new();

    }
}
