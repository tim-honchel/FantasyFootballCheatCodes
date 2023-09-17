using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class TagsResponseObject : BaseResponseObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
