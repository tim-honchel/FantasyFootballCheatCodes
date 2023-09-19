using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class EspnPlayersRequest
    {
        public string LeagueID { get; set; } = string.Empty;
        public string espn_s2 { get; set; } = string.Empty;
        public string swid { get; set; } = string.Empty;
        public Rules Rules { get; set; } = new();
    }
}
