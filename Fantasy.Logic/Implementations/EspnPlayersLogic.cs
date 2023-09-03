using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;

namespace Fantasy.Logic.Implementations
{
    public class EspnPlayersLogic : IEspnPlayersLogic
    {
        public Task<List<PlayerESPN>> Get(string leagueID, string espn_s2, string swid)
        {
            throw new NotImplementedException();
        }
    }
}
