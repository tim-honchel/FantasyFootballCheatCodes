using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IStrongRosterLogic
    {
        StrongRosterResponse Get(StrongRosterRequest request);
    }

}
