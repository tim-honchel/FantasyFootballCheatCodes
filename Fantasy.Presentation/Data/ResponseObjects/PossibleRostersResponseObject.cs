using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class PossibleRostersResponseObject : BaseResponseObject
    {
        public List<RosterViewModel> Rosters { get; set; } = new();
    }
}
