using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ISimplifiedDraftPoolLogic
    {
        List<Player> Get(List<Player> allPlayers, PointAverages averages);
    }
}
