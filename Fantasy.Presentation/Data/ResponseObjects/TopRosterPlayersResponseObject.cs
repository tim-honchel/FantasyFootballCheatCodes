using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class TopRosterPlayersResponseObject : BaseResponseObject
    {
       public List<int> PlayerIDs { get; set; } = new();
    }
}
