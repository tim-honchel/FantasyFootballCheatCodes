using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class EditProjectionsRequestObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
