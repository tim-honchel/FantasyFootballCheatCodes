using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class TagsRequestObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
