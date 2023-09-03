using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class CsvStartersRequestObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
