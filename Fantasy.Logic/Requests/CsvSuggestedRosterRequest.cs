using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class CsvSuggestedRosterRequest
    {
        public List<DraftBoard> DraftBoards { get; set; } = new();
    }
}
