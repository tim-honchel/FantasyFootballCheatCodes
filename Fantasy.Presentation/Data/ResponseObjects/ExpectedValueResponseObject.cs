using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class ExpectedValueResponseObject : BaseResponseObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
