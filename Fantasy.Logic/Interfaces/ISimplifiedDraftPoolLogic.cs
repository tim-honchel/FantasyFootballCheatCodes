using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ISimplifiedDraftPoolLogic
    {
        SimplifiedDraftPoolResponse Get(SimplifiedDraftPoolRequest request);
    }
}
