using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class ExpectedValueRequest
    {
        public CostAnalysis CostAnalysis { get; set; } = new();
        public List<Player> Players { get; set; } = new();
    }
}
