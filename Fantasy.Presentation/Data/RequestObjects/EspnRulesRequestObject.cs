using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class EspnRulesRequestObject
    {
        public string LeagueID { get; set; } = string.Empty;
        public string espn_s2 { get; set; } = string.Empty;
        public string swid { get; set; } = string.Empty;
    }
}
