using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class EspnPlayersResponseObject : BaseResponseObject
    {
        public List<PlayerESPNViewModel> Players { get; set; } = new();
    }
}
