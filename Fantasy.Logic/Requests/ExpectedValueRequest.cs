using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class ExpectedValueRequest
    {
        CostAnalysis CostAnalysis { get; set; }
        List<Player> Players { get; set; }
    }
}
