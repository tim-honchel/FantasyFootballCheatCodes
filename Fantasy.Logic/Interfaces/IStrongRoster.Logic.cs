using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IStrongRosterLogic
    {
        Roster Get(List<Player> playerShortList, Rules rules);
    }

}
