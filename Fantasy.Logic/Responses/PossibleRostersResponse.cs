
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class PossibleRostersResponse : BaseResponse
    {
        public List<Roster> Rosters { get; set; } = new();
    }
}
