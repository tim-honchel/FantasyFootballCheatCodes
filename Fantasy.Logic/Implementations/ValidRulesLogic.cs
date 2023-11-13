
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

        public Dictionary<string, int> GetMaximumStartersByPosition()
        {
            List<string> basePositions = PositionListService.GetListOfBasePositions();
            List<string> comboPositions = PositionListService.GetListOfComboPositions();
            
            Dictionary<string, int> maximumStartersByPosition = new();

            foreach (string position in basePositions)
            {
                maximumStartersByPosition[position] = Convert.ToInt16(_configuration[$"ValidMaximumStarters{position}"]);
            }

            foreach (string position in comboPositions)
            {
                maximumStartersByPosition[position] = Convert.ToInt16(_configuration[$"ValidMaximumStarters{position}"]);
            }

            return maximumStartersByPosition;
        }

        public int GetMinimumNumberOfPlayers(Positions positions, int teams)
        {
            Dictionary<string, int> startersByPosition = PositionDictionaryService.GetStarterSlotsByPosition(positions);
            int starters = startersByPosition.Sum(s => s.Value);

            int minimumNumberOfPlayers = teams * (startersByPosition.Sum(s => s.Value) + positions.Bench);
            return minimumNumberOfPlayers;
        }

        public Dictionary<string,int> GetPlayersByPosition(List<Player> players)
        {
            List<string> basePositions = PositionListService.GetListOfBasePositions();

            Dictionary<string, int> playersByPosition = new();

            foreach (string position in basePositions)
            {
                playersByPosition.Add(position, players.Where(p => p.Position == position).Count());
            }

            return playersByPosition;
        }

        public void ValidateRules(ValidRulesResponse response, Rules rules)
        {
            if (rules == null)
            {
                response.ValidationErrors.Add("League rules were empty or missing.");
                return;
            }

            if (rules.LeagueID == 0 && rules.Status.Season == 0 && rules.Size.Teams == 0 && rules.Positions.Quarterbacks[0] == 0 && rules.Settings.DraftPick == 0)
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
            int minimumPlayers = GetMinimumNumberOfPlayers(rules.Positions, rules.Size.Teams);


            if (players == null || players.Count == 0)
            {
                response.ValidationErrors.Add("List of players was empty or missing.");
                return;
            }
            else if (players.Count < minimumPlayers)
            {
                response.ValidationErrors.Add($"Number of players ({players.Count}) is less than the number required by league rules ({minimumPlayers}).");
                return;
            }

            List<string> basePositions = PositionListService.GetListOfBasePositions();
            List<string> comboPositions = PositionListService.GetListOfComboPositions();
            Dictionary<string, int> playersByPosition = GetPlayersByPosition(players);
            Dictionary<string, int> remainingPlayersByPosition = GetPlayersByPosition(players);
            Dictionary<string, int> startersByPosition = PositionDictionaryService.GetStarterSlotsByPosition(rules.Positions);
            Dictionary<string, List<string>> comboPositionsAndTheirBasePositions = PositionDictionaryService.GetComboPositionsAndTheirBasePositions();

            foreach (KeyValuePair<string,int> position in startersByPosition)
            {
                startersByPosition[position.Key] = position.Value * rules.Size.Teams;
            }

            foreach (string position in basePositions)
            {
                if (playersByPosition[position] < startersByPosition[position])
                {
                    response.ValidationErrors.Add($"Number of {position} ({playersByPosition[position]}) is less than the necessary starters ({startersByPosition[position]})");
                    remainingPlayersByPosition[position] = 0;
                }
                else
                {
                    remainingPlayersByPosition[position] = remainingPlayersByPosition[position] - startersByPosition[position];
                }
            }

            foreach (string position in comboPositions)
            {
                int eligiblePlayers = remainingPlayersByPosition.Where(r => comboPositionsAndTheirBasePositions[position].Contains(r.Key)).Sum(r => r.Value);

                if (eligiblePlayers < startersByPosition[position])
                {
                    response.ValidationErrors.Add($"Number of {position} ({eligiblePlayers}) is less than the necessary starters ({startersByPosition[position]})");
                }
            }
        }


        public void ValidatePositions(ValidRulesResponse response, Positions positions)
        {
            Dictionary<string, int> starterSlotsByPosition = PositionDictionaryService.GetStarterSlotsByPosition(positions);

            if (starterSlotsByPosition.Sum(s => s.Value) < Convert.ToInt16(_configuration["ValidMinimumStarters"]))
            {
                response.ValidationErrors.Add($"Number of starters ({starterSlotsByPosition.Sum(s => s.Value).ToString()}) is below the valid minimum ({_configuration["ValidMinimumStarters"]}).");
            }

            Dictionary<string, int> maximumStartersByPosition = GetMaximumStartersByPosition();
            Dictionary<string, int> maximumPlayersByPosition = PositionDictionaryService.GetMaximumPlayersPerPosition(positions);

            foreach (KeyValuePair<string, int> position in starterSlotsByPosition)
            {
                if (position.Value > 0 && position.Value > maximumStartersByPosition[position.Key])
                {
                    response.ValidationErrors.Add($"Number of {position.Key} starters ({position.Value}) exceeds the valid maximum");
                }
                if (maximumPlayersByPosition.ContainsKey(position.Key) && maximumPlayersByPosition[position.Key] < starterSlotsByPosition[position.Key])
                {
                    response.ValidationErrors.Add($"Maximum number of {position.Key} players ({maximumPlayersByPosition[position.Key]}) is less than the number of {position.Key} starters ({starterSlotsByPosition[position.Key]})");
                }
            }
        }

        public void ValidateSettings(ValidRulesResponse response, Settings settings)
        {
            if (!_configuration["ValidDraftTypes"].ToString().Contains(settings.DraftType.ToString()))
            {
                response.ValidationErrors.Add($"Invalid draft type ({settings.DraftType.ToString()})");
            }

            if (!_configuration["ValidDraftOrderTypes"].ToString().Contains(settings.DraftOrderType.ToString()))
            {
                response.ValidationErrors.Add($"Invalid draft order type ({settings.DraftOrderType.ToString()})");
            }

            if (!_configuration["ValidKeeper"].ToString().Contains(settings.Keeper.ToString()))
            {
                response.ValidationErrors.Add($"Invalid keeper value ({settings.Keeper.ToString()})");
            }

            if (!_configuration["ValidScoringTypes"].ToString().Contains(settings.ScoringType.ToString()))
            {
                response.ValidationErrors.Add($"Invalid scoring type ({settings.ScoringType})");
            }

            if (settings.DraftType == DraftType.Auction && settings.SalaryCap < Convert.ToInt32(_configuration["ValidMinimumSalaryCap"]))
            {
                response.ValidationErrors.Add($"Salary cap ({settings.SalaryCap}) is below the valid minimum ({_configuration["ValidMinimumSalaryCap"]})");
            }

        }

        public void ValidateSize(ValidRulesResponse response, Size size)
        {
            if (size.Teams < Convert.ToInt32(_configuration["ValidMinimumTeams"]))
            {
                response.ValidationErrors.Add($"Number of teams ({size.Teams}) is below the valid minimum ({_configuration["ValidMinimumTeams"]})");
            }

            if (size.Teams > Convert.ToInt32(_configuration["ValidMaximumTeams"]))
            {
                response.ValidationErrors.Add($"Number of teams ({size.Teams}) exceeds the valid maximum ({_configuration["ValidMaximumTeams"]})");
            }
        }

        public void ValidateStatus(ValidRulesResponse response, Status status)
        {
            if (status.IsActive == false)
            {
                response.ValidationErrors.Add("League is inactive.");
            }

            if (status.DraftComplete == true)
            {
                response.ValidationErrors.Add("Draft is already complete.");
            }

            if (status.Season != DateTime.Now.Year)
            {
                response.ValidationErrors.Add($"League season ({status.Season}) is not current.");
            }
        }
    }
}
