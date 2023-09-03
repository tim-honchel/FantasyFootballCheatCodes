using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class CsvSuggestedRosterRequestObject
    {
        public DraftBoardViewModel DraftBoard { get; set; } = new();
    }
}
