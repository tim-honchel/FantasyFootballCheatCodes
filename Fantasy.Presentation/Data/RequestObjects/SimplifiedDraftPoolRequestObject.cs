using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class SimplifiedDraftPoolRequestObject
    {
        public PointAveragesViewModel PointAverages { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
