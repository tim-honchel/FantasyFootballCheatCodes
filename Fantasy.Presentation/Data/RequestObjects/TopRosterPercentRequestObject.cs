using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.RequestObjects
{
   public class TopRosterPercentRequestObject
    {
        public CountByIDViewModel Frequency { get; set; } = new();
        public List<PlayerViewModel> Players { get; set; } = new();
    }
}
