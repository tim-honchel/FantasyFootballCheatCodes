﻿namespace Fantasy.Logic.Models
{
    public class DraftBoard
    {
        public double Points { get; set; }
        public int Cost { get; set; }
        public string QB { get; set; } = "";
        public string RB1 { get; set; } = "";
        public string RB2 { get; set; } = "";
        public string WR1 { get; set; } = "";
        public string WR2 { get; set; } = "";
        public string TE { get; set; } = "";
        public string FLEX { get; set; } = "";
        public string DEF { get; set; } = "";
        public string K { get; set; } = "";
    }
}
