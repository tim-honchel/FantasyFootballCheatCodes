using Fantasy.Presentation.Data.ViewModels;

namespace Fantasy.Presentation.Data.Responses
{
    public class TopRosterFrequencyResponseObject : BaseResponseObject
    {
        public CountByIDViewModel Frequency { get; set; } = new();
    }
}
