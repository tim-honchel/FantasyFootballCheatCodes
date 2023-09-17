
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class PointAveragesResponse : BaseResponse
    {
        public PointAverages Averages { get; set; } = new();
    }
}
