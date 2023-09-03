using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
    public class CostAnalysisRequestObject
    {
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
