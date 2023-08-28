using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IPointAveragesLogic
    {
        PointAverages Get(List<Player> allPlayers);
    }
}
