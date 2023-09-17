using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ITopRosterPercentLogic
    {
        TopRosterPercentResponse Get(TopRosterPercentRequest request);
    }
}
