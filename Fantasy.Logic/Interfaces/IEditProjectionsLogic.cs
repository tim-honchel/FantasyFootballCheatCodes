using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IEditProjectionsLogic
    {
        List<Player> Get(List<Player> editedPlayers);
    }
}
