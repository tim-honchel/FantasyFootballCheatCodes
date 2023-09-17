using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Interfaces
{
    public interface ILeagueRulesLogic
    {
        LeagueRulesResponse Get(LeagueRulesRequest request);
    }
}
