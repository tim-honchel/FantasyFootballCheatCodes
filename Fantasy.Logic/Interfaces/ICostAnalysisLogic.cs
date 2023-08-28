using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ICostAnalysisLogic
    {
        CostAnalysis Get(List<Player> allPlayers);
    }
}
