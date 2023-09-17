using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IPlayerProjectionsLogic
    {
        PlayerProjectionsResponse Get(PlayerProjectionsRequest request);
    }
}
