
using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using Microsoft.Extensions.Configuration;

namespace Fantasy.Logic.Implementations
{
    public class ValidRulesLogic : IValidRulesLogic
    {
        public readonly IConfiguration _configuration;
        public ValidRulesLogic(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public ValidRulesResponse Get(ValidRulesRequest request)
        {
            ValidRulesResponse response = new ValidRulesResponse();

            ValidateRules(response, request.Rules);

            ValidatePlayers(response, request.Rules, request.Players);
            
            response.Success = response.ValidationErrors.Count == 0 ? true : false;

            return response;
        }

        public Dictionary<string, int> GetMinimumPlayersByPosition(int teams, Positions positions)
        {
            Dictionary<string, int> dictionary = new();
            return dictionary;
        }

        public void ValidateRules(ValidRulesResponse response, Rules rules)
        {
            if (rules == null)
            {
                response.ValidationErrors.Add("League rules were empty or missing.");
                return;
            }

            if (rules.Positions == null)
            {
                response.ValidationErrors.Add("League position counts were empty or missing.");
            }
            else
            {
                ValidatePositions(response, rules.Positions);
            }

            if (rules.Settings == null)
            {
                response.ValidationErrors.Add("League settings were empty or missing.");
            }
            else
            {
                ValidateSettings(response, rules.Settings);
            }

            if (rules.Size == null)
            {
                response.ValidationErrors.Add("League size information was empty or missing.");
            }
            else
            {
                ValidateSize(response, rules.Size);
            }

            if (rules.Status == null)
            {
                response.ValidationErrors.Add("League status information was empty or missing.");
            }
            else
            {
                ValidateStatus(response, rules.Status);
            }

        }

        public void ValidatePlayers(ValidRulesResponse response, Rules rules, List<Player> players)
        {
            if (players == null || players.Count == 0)
            {
                response.ValidationErrors.Add("List of players was empty or missing.");
                return;
            }

            Dictionary<string, int> minimum = GetMinimumPlayersByPosition(rules.Size.Teams, rules.Positions);

            foreach (KeyValuePair<string,int> pair in minimum)
            {
                ValidatePosition(response, pair.Key, pair.Value, players.Where(player => player.Position == pair.Key).ToList());
            }
    
        }

        public void ValidatePosition(ValidRulesResponse response, string position, int minimum, List<Player> players)
        {

        }

        public void ValidatePositions(ValidRulesResponse response, Positions positions)
        {
            //int offenseStarters = positions.Quarterbacks[0] + positions.RunningBacks[0] + +positions.TightEnds[0] + positions.WideReceivers[0];
            //int defenseStarters = positions.Cornerbacks[0] + positions.DefensiveEnds[0] + positions.DefensiveTackles[0] + positions.Linebackers[0] + positions.Safeties[0];
            //int specialTeamsStarters = positions.Kickers[0] + positions.Punters[0] + positions.Coaches[0];
            //int comboStarters = positions.BacksAndReceivers + positions.DefensivePlayerUtilities + positions.FLEX + positions.Linemen + positions.OffensivePlayerUtilities + positions.ReceiversAndEnds;
            //int teamStarters = positions.TeamDefenses[0] + positions.TeamQuarterbacks[0];
            //int starters = offenseStarters + defenseStarters + specialTeamsStarters + comboStarters + teamStarters;

            //int minimumStarters = Convert.ToInt32(_configuration["ValidMinimumStarters"]);
        }

        public void ValidateSettings(ValidRulesResponse response, Settings settings)
        {

        }

        public void ValidateSize(ValidRulesResponse response, Size size)
        {

        }

        public void ValidateStatus(ValidRulesResponse response, Status status)
        {

        }
    }
}
