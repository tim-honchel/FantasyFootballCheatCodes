

using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ITopRosterPlayersLogic
    {
        List<int> Get(List<Player> allPlayers, Rules rules);
    }
}
