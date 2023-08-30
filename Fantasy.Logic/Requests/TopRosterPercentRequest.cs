using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
   public class TopRosterPercentRequest
    {
        public CountByID Frequency { get; set; }
        public List<Player> Players { get; set; }
    }
}
