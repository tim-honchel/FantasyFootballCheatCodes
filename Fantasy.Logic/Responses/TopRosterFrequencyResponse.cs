
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Responses
{
    public class TopRosterFrequencyResponse : BaseResponse
    {
        public CountByID Frequency { get; set; } = new();
    }
}
