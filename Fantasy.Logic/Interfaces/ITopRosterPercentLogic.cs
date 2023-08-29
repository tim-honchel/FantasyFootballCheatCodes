using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ITopRosterPercentLogic
    {
        List<Player> Get(List<Player> allPlayers, CountByID frequency);
    }
}
