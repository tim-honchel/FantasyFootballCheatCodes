using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;

namespace Fantasy.Logic.Implementations
{
    public class PointAveragesLogic : IPointAveragesLogic
    {
        public PointAveragesResponse Get(PointAveragesRequest request)
        {
            PointAverages averages = new();

            List<Player> players = request.Players;
            int teams = request.Rules.Size.Teams;
            Positions positions = request.Rules.Positions;

            Dictionary<string, int> starterSlotsByPosition = PositionDictionaryService.GetStarterSlotsByPosition(positions);
            List<string> basePositions = PositionListService.GetListOfBasePositions();
            Dictionary<string, List<string>> comboPositions = PositionDictionaryService.GetComboPositionsAndTheirBasePositions();

            foreach (string position in basePositions)
            {
                MockDraftBasePosition(averages, players, starterSlotsByPosition, teams, position);
            }

            foreach (KeyValuePair<string, List<string>> position in comboPositions)
            {
                MockDraftComboPosition(averages, players, starterSlotsByPosition, teams, position);
            }

            Dictionary<string, int> benchSlotsByPosition = new();

            if (request.Rules.Settings.DraftType == DraftType.Auction)
            {
                benchSlotsByPosition = GetBenchSlotsByPositionForAuction(players, basePositions, starterSlotsByPosition, teams);
            }

            foreach (string position in basePositions)
            {
                MockDraftBenchPosition(averages, players, benchSlotsByPosition, position);
            }

            foreach (string position in basePositions)
            {
                IdentifyTopFreeAgent(averages, players, starterSlotsByPosition, position);
            }

            PointAveragesResponse response = new()
            {
                Averages = averages,
                Success = true
            };

            return response;
        }

        public Dictionary<string, int> GetBenchSlotsByPositionForAuction(List<Player> players, List<string> basePositions, Dictionary<string, int> starterSlotsByPosition, int teams)
        {
            Dictionary<string, int> benchSlotsByPosition = new();

            foreach (string position in basePositions)
            {
                int totalProjectedDrafteesAtPosition = players.Where(p => p.Position == position && p.Cost > 0).Count();
                int alreadyDraftedAtPosition = players.Where(p => p.Position == position && p.DraftPosition != position).Count();
                if (totalProjectedDrafteesAtPosition > 0)
                {
                    benchSlotsByPosition[position] = Math.Max(0, totalProjectedDrafteesAtPosition - alreadyDraftedAtPosition);
                }
            }

            return benchSlotsByPosition;
        }

        public void IdentifyTopFreeAgent(PointAverages averages, List<Player> players, Dictionary<string, int> startersByPosition, string position)
        {
            if (startersByPosition[position] > 0)
            {
                double topFreeAgent = players.OrderByDescending(p => p.WeeklyPoints).Where(p => p.DraftPosition == position).First().WeeklyPoints;
                SaveAverage(averages, position, "FA", topFreeAgent);
            }
        }

        public void MockDraftBasePosition(PointAverages averages, List<Player> players, Dictionary<string, int> startersByPosition, int teams, string position)
        {
            for (int round = 1; round <= startersByPosition[position]; round++)
            {
                players.Where(p => p.DraftPosition == position).OrderByDescending(p => p.WeeklyPoints).Take(teams).ToList().ForEach(p => p.DraftPosition = position + round.ToString());
                SaveAverage(averages, position, round.ToString(), players.Where(p=>p.DraftPosition == position + round.ToString()).Average(p => p.WeeklyPoints));
            }
        }

        public void MockDraftBenchPosition(PointAverages averages, List<Player> players, Dictionary<string,int> benchSlotsByPosition, string position)
        {
            if (benchSlotsByPosition.ContainsKey(position))
            {
                players.Where(p => p.DraftPosition == position).OrderByDescending(p => p.WeeklyPoints).Take(benchSlotsByPosition[position]).ToList().ForEach(p => p.DraftPosition = position + "-bench");
            }        
        }

        public void MockDraftComboPosition(PointAverages averages, List<Player> players, Dictionary<string, int> startersByPosition, int teams, KeyValuePair<string, List<string>> position)
        {
            for (int round = 1; round <= startersByPosition[position.Key]; round++)
            {
                players.Where(p => position.Value.Contains(p.DraftPosition)).OrderByDescending(p => p.WeeklyPoints).Take(teams).ToList().ForEach(p => p.DraftPosition = position.Key + round.ToString());
                SaveAverage(averages, position.Key, round.ToString(), players.Where(p => p.DraftPosition == position.Key + round.ToString()).Average(p => p.WeeklyPoints));
            }
        }

        public void SaveAverage(PointAverages averages, string position, string number, double points)
        {
            string role = position + number;
            points = Math.Round(points, 2);
            averages.AverageByPosition[role] = points;
        }
    }
}
