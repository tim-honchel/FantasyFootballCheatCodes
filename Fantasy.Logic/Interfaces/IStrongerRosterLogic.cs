

using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IStrongerRosterLogic
    {
        Roster Get(Roster strongRoster, List<Player> allPlayers, Rules rules);
    }
}
