using Fantasy.Logic.Requests;

namespace Fantasy.Logic.Interfaces
{
    public interface ICsvSuggestedRostersLogic
    {
        string Get(CsvSuggestedRosterRequest request);
    }
}
