

using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ITopRosterFrequencyLogic
    {
        TopRosterFrequencyResponse Get(TopRosterFrequencyRequest request);
    }
}
