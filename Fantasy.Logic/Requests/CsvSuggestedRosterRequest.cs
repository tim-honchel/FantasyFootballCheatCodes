using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class CsvSuggestedRosterRequest
    {
        public DraftBoard DraftBoard { get; set; } = new();
    }
}
