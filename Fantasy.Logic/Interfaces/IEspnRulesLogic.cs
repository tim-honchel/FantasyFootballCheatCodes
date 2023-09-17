using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IEspnRulesLogic
    {
        Task<EspnRulesResponse> Get(EspnRulesRequest request);
    }
}
