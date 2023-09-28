using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.State
{
    public class UserData
    {
        public RulesViewModel Rules { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
        public List<DraftBoardViewModel> DraftBoards { get; set; } = new();
    }
}
