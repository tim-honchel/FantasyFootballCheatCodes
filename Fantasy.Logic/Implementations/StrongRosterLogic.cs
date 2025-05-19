using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;

namespace Fantasy.Logic.Implementations
{
    public class StrongRosterLogic : IStrongRosterLogic
    {
        public StrongRosterResponse Get(StrongRosterRequest request)
        {
            List<string> startingPositions = GetStartingPositions(request.Rules.Positions);
            var availablePlayers = request.Players;

            List<Player> players = GetStrongestRoster(startingPositions, availablePlayers);

            int cost = players.Sum(p => p.Cost);
            int salaryCapForStarters = request.Rules.Settings.SalaryCap - request.Rules.Positions.Bench;

            while (cost > salaryCapForStarters)
            {
                ReplaceOnePlayerToReduceSalary(startingPositions, players, availablePlayers, cost, salaryCapForStarters);
                cost = players.Sum(p => p.Cost);
            }

            var roster = new Roster();
            roster.Players = players;
            roster.Cost = roster.Players.Sum(p => p.Cost);
            roster.TotalPoints = roster.Players.Sum(p => p.WeeklyPoints);

            StrongRosterResponse response = new()
            {
                Roster = roster,
                Success = true
            };

            return response;
        }

        public List<Player> GetStrongestRoster(List<string> startingPositions, List<Player> availablePlayers)
        {
            var players = new List<Player>();

            foreach (string position in startingPositions)
            {
                Player playerToAdd = availablePlayers.Where(p => p.RelativePoints.ContainsKey(position)).OrderByDescending(p => p.WeeklyPoints).First();
                playerToAdd.DraftPosition = position;
                players.Add(playerToAdd);
                availablePlayers.Remove(playerToAdd);
            }

            return players;

        }

        public List<string> GetStartingPositions(Positions positions)
        {
            List<string> startingPositions = new();
            List<string> basePositions = PositionListService.GetListOfBasePositions();
            List<string> comboPositions = new();
            
            Dictionary<string, int> starterSlotsByPosition = PositionDictionaryService.GetStarterSlotsByPosition(positions);
            foreach (KeyValuePair<string, int> position in starterSlotsByPosition)
            {
                for (int i = 1; i <= position.Value; i++)
                {
                    if (basePositions.Contains(position.Key))
                    {
                        startingPositions.Add($"{position.Key}{i}");
                    }
                    else
                    {
                        comboPositions.Add($"{position.Key}{i}");
                    }
                }
            }

            startingPositions.AddRange(comboPositions);

            return startingPositions;
        }

        private void ReplaceOnePlayerToReduceSalary(List<string> startingPositions, List<Player> players, List<Player> availablePlayers, int cost, int salaryCap)
        {
            double maxCostSlope = 0;
            string positionToReplace = "";
            foreach (var position in startingPositions)
            {
                double costSlope = GetCostSlope(position, players, availablePlayers);
                if (costSlope > maxCostSlope) 
                {
                    maxCostSlope = costSlope;
                    positionToReplace = position;
                }
            }
            var playerToRemove = players.Where(p => p.DraftPosition == positionToReplace).First();
            players.Remove(playerToRemove);
            var playerToAdd = availablePlayers.Where(p => p.RelativePoints.ContainsKey(positionToReplace)).OrderByDescending(p => p.WeeklyPoints).First();
            playerToAdd.DraftPosition = positionToReplace;
            players.Add(playerToAdd);
            availablePlayers.Remove(playerToAdd);
        }

        private double GetCostSlope(string position, List<Player> players, List<Player> availablePlayers)
        {
            double slope = 0;
            var currentPlayer = players.Where(p => p.DraftPosition == position).FirstOrDefault();
            var nextBestPlayer = availablePlayers.Where(p => p.RelativePoints.ContainsKey(position)).OrderByDescending(p => p.WeeklyPoints).FirstOrDefault();
            if (currentPlayer != null && nextBestPlayer != null)
            {
                slope = (currentPlayer.Cost - nextBestPlayer.Cost)/(currentPlayer.WeeklyPoints - nextBestPlayer.WeeklyPoints);
            }
            return slope;
        }
    }

}
