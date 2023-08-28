using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IEspnPlayersLogic
    {
        Task<List<PlayerESPN>> Get(string leagueID, string espn_s2, string swid);
    }
}
