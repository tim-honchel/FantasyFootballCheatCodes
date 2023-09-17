using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class StrongerRosterResponseObject : BaseResponseObject
    {
        public RosterViewModel Roster { get; set; } = new();
    }
}
