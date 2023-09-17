using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IStrongerRosterLogic
    {
        StrongerRosterResponse Get(StrongerRosterRequest request);
    }
}
