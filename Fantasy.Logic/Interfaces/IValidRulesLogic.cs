using Fantasy.Logic.Models;

namespace Fantasy.Logic.Interfaces
{
    public interface IValidRulesLogic
    {
        RuleValidity Get(Rules rules, List<Player> players);
    }
}
