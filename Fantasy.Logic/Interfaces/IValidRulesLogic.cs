using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IValidRulesLogic
    {
        ValidRulesResponse Get(ValidRulesRequest request);
    }
}
