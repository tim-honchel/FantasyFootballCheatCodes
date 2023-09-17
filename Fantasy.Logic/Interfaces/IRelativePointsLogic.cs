using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IRelativePointsLogic
    {
        RelativePointsResponse Get(RelativePointsRequest request);
    }
}
