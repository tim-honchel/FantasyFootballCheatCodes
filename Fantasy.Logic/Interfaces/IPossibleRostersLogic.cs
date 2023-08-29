

using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IPossibleRostersLogic
    {
        List<Roster> Get(Roster strongerRoster, List<Player> allPlayers, Rules rules);
    }
}
