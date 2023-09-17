using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IEspnPlayersLogic
    {
        Task<EspnPlayersResponse> Get(EspnPlayersRequest request);
    }
}
