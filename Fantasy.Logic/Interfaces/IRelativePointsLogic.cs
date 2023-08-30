using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;

namespace Fantasy.Logic.Interfaces
{
    public interface IRelativePointsLogic
    {
        List<Player> Get(PointAverages averages, List<Player> players);
    }
}
