using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class SuggestedRostersResponse : BaseResponseObject
    {
        public List<DraftBoardViewModel> DraftBoard { get; set; } = new();
    }
}
