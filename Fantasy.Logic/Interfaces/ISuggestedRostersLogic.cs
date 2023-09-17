using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ISuggestedRostersLogic
    {
        SuggestedRostersResponse Get(SuggestedRostersRequest request);
    }
}
