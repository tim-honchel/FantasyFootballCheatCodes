using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ISuggestedRostersLogic
    {
        List<DraftBoard> Get(List<Player> allPlayers, List<Roster> topRosters, List<int> topPlayerIDs);
    }
}
