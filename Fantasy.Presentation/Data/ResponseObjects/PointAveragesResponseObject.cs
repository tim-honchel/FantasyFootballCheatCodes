using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class PointAveragesResponseObject : BaseResponseObject
    {
        public PointAveragesViewModel Averages { get; set; } = new();
    }
}
