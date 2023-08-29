

using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ITopRosterFrequencyLogic
    {
        CountByID Get(List<Roster> topRosters);
    }
}
