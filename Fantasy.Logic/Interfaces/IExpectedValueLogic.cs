using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;

namespace Fantasy.Logic.Interfaces
{
    public interface IExpectedValueLogic
    {
        List<Player> Get(ExpectedValueRequest request);
    }
}
