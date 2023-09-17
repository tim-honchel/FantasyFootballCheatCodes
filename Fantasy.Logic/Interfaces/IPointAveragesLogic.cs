using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface IPointAveragesLogic
    {
        PointAveragesResponse Get(PointAveragesRequest request);
    }
}
