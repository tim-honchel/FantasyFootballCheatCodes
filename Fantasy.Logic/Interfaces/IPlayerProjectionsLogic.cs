using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IPlayerProjectionsLogic
    {
        List<Player> Get(List<PlayerESPN> espnPlayers);
    }
}
