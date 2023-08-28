

using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IEspnRulesLogic
    {
        Task<RulesESPN> Get(string leagueID, string espn_s2, string swid);
    }
}
