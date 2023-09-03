using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects

namespace Fantasy.Logic.Requests
{
    public class RelativePointsRequestObject
    {
        public PointAveragesViewModel PointAverages { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
