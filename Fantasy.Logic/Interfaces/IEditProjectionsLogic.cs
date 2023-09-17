using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IEditProjectionsLogic
    {
        EditProjectionsResponse Get(EditProjectionsRequest request);
    }
}
