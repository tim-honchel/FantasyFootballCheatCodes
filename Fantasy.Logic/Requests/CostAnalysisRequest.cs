using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class CostAnalysisRequest
    {
        public List<Player> Players { get; set; } = new();
        public DraftType DraftType { get; set; }
    }
}
