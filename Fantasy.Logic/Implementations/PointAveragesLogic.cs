using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using Newtonsoft.Json.Linq;
using System.Runtime.Intrinsics.X86;

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
            Dictionary<string, double> slopeByPosition = GetSlopeByPosition(players, basePositions, starterSlotsByPosition, teams);

            foreach (string position in basePositions)
            {
                MockDraftBasePosition(averages, players, starterSlotsByPosition, teams, position);
            }

            foreach (KeyValuePair<string, List<string>> position in comboPositions)
            {
                MockDraftComboPosition(averages, players, starterSlotsByPosition, teams, position);
            }

            Dictionary<string, int> benchSlotsByPosition = GetBenchSlotsByPosition(averages, players, basePositions, starterSlotsByPosition, slopeByPosition, teams, positions.Bench);

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

        public double CalculateSlope(List<Player> starters)
        {
            List<double> differences = new();

            for (int i=0; i < starters.Count() - 1; i++)
            {
                differences.Add(starters[i].WeeklyPoints - starters[i+1].WeeklyPoints);
            }

            double slope = Math.Round(differences.Average(),2);
            return slope;
        }

        public Dictionary<string, int> GetBenchSlotsByPosition(PointAverages averages, List<Player> players, List<string> basePositions, Dictionary<string, int> starterSlotsByPosition, Dictionary<string, double> slopeByPosition, int teams, int benchSlots)
        {
            Dictionary<string, double> benchWeight = new();

            foreach (string position in basePositions)
            {
                if (starterSlotsByPosition[position] > 0)
                {
                    double starterRatio = (double) starterSlotsByPosition[position] / (double) starterSlotsByPosition.Sum(s => s.Value);
                    benchWeight[position] = starterRatio * slopeByPosition[position];
                }
            }
            
            Dictionary<string, int> benchSlotsByPosition = new();

            foreach (string position in basePositions)
            {
                if (starterSlotsByPosition[position] > 0)
                {
                    benchSlotsByPosition[position] = (int) (teams * benchSlots * benchWeight[position] / benchWeight.Sum(b => b.Value));
                }
            }

            if (benchSlotsByPosition.Sum(b => b.Value) < teams * benchSlots)
            {
                string mostImportantPosition = benchSlotsByPosition.OrderByDescending(b => b.Value).First().Key;
                benchSlotsByPosition[mostImportantPosition] += teams * benchSlots - benchSlotsByPosition.Sum(b => b.Value);
            }

            return benchSlotsByPosition;
        }

        public Dictionary<string, double> GetSlopeByPosition(List<Player> players, List<string> basePositions, Dictionary<string, int> starterSlotsByPosition, int teams)
        {
            Dictionary<string, double> slopeByPosition = new();

            foreach (string position in basePositions)
            {
                if (starterSlotsByPosition[position] > 0)
                {
                    List<Player> starters = players.Where(p => p.Position == position).Take(teams * starterSlotsByPosition[position]).ToList();
                    slopeByPosition[position] = CalculateSlope(starters);
                }
            }

            return slopeByPosition;
        }

        public void IdentifyTopFreeAgent(PointAverages averages, List<Player> players, Dictionary<string, int> startersByPosition, string position)
        {
            if (startersByPosition[position] > 0)
            {
                double topFreeAgent = players.OrderByDescending(p => p.WeeklyPoints).Where(p => p.Position == position).First().WeeklyPoints;
                SaveAverage(averages, position, "FA", topFreeAgent);
            }
        }

        public void MockDraftBasePosition(PointAverages averages, List<Player> players, Dictionary<string, int> startersByPosition, int teams, string position)
        {
            for (int round = 1; round <= startersByPosition[position]; round++)
            {
                players.Where(p => p.Position == position).OrderByDescending(p => p.WeeklyPoints).Take(teams).ToList().ForEach(p => p.Position = position + round.ToString());
                SaveAverage(averages, position, round.ToString(), players.Where(p=>p.Position == position + round.ToString()).Average(p => p.WeeklyPoints));
            }
        }

        public void MockDraftBenchPosition(PointAverages averages, List<Player> players, Dictionary<string,int> benchSlotsByPosition, string position)
        {
            if (benchSlotsByPosition.ContainsKey(position))
            {
                players.Where(p => p.Position == position).OrderByDescending(p => p.WeeklyPoints).Take(benchSlotsByPosition[position]).ToList().ForEach(p => p.Position = position + "-bench");
            }        
        }

        public void MockDraftComboPosition(PointAverages averages, List<Player> players, Dictionary<string, int> startersByPosition, int teams, KeyValuePair<string, List<string>> position)
        {
            for (int round = 1; round <= startersByPosition[position.Key]; round++)
            {
                players.Where(p => position.Value.Contains(p.Position)).OrderByDescending(p => p.WeeklyPoints).Take(teams).ToList().ForEach(p => p.Position = position.Key + round.ToString());
                SaveAverage(averages, position.Key, round.ToString(), players.Where(p => p.Position == position.Key + round.ToString()).Average(p => p.WeeklyPoints));
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
