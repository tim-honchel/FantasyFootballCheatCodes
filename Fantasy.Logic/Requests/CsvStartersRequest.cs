

using Fantasy.Logic.Models;

namespace Fantasy.Logic.Requests
{
    public class CsvStartersRequest
    {
        public List<Player> Players { get; set; } = new();
    }
}
