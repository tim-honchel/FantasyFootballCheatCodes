using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class EditProjectionsResponseObject : BaseResponseObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
