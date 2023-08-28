using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface ILeagueRulesLogic
    {
        Rules Get(RulesESPN espnRules);
    }
}
