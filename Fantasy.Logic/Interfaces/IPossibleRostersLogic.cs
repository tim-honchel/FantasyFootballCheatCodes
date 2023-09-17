using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IPossibleRostersLogic
    {
        PossibleRostersResponse Get(PossibleRostersRequest request);
    }
}
