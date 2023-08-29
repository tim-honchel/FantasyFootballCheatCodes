using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ICsvStartersLogic
    {
        string Get(List<Player> playersToDisplay);
    }
}
