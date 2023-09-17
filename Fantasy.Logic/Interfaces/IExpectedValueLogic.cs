using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IExpectedValueLogic
    {
        ExpectedValueResponse Get(ExpectedValueRequest request);
    }
}
