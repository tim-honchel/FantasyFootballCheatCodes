using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class PlayerProjectionsResponseObject : BaseResponseObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
