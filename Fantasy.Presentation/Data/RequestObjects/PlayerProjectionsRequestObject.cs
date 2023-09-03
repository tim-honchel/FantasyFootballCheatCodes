using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class PlayerProjectionsRequestObject
    {
        public List<PlayerESPNViewModel> Players { get; set; } = new();
    }
}
