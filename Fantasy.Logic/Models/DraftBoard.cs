namespace Fantasy.Logic.Models
{
    public class DraftBoard
    {
        public double Points { get; set; } = 0;
        public int Cost { get; set; } = 0;
        public string QB { get; set; } = string.Empty;
        public string RB1 { get; set; } = string.Empty;
        public string RB2 { get; set; } = string.Empty;
        public string WR1 { get; set; } = string.Empty;
        public string WR2 { get; set; } = string.Empty;
        public string TE { get; set; } = string.Empty;
        public string FLEX { get; set; } = string.Empty;
        public string DEF { get; set; } = string.Empty;
        public string K { get; set; } = string.Empty;
    }
}
