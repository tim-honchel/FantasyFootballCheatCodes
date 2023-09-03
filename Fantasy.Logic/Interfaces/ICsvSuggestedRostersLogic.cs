using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ICsvSuggestedRostersLogic
    {
        string Get(List<DraftBoard> suggestedRosters);
    }
}
