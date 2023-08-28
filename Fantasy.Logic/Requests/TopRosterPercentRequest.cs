using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
   public class TopRosterPercentRequest
    {
        CountByID Frequency { get; set; }
        List<Player> Players { get; set; }
    }
}
