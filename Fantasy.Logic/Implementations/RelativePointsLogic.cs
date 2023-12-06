using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;

namespace Fantasy.Logic.Implementations
{
    public class RelativePointsLogic : IRelativePointsLogic
    {
        public RelativePointsResponse Get(RelativePointsRequest request)
        {
            RelativePointsResponse response = new();

            Dictionary<string, List<string>> relevantComboPositions = GetRelevantComboPositions(request.PointAverages);

            foreach (Player player in request.Players)
            {
                UpdatePlayerRelativePointsBasePosition(player, request.PointAverages);
                UpdatePlayerRelativePointsComboPosition(player, relevantComboPositions, request.PointAverages);
            }

            response.Players = request.Players;
            response.Success = true;
            return response;
        }

        public Dictionary<string, List<string>> GetRelevantComboPositions(PointAverages averages)
        {
            Dictionary<string, List<string>> relevantComboPositions = new Dictionary<string, List<string>>();

            Dictionary<string, List<string>> comboPositionsAndTheirBasePositions = PositionDictionaryService.GetComboPositionsAndTheirBasePositions();

            foreach (KeyValuePair<string, double> average in averages.AverageByPosition)
            {
                string position = average.Key.Substring(0, average.Key.Length - 1);

                if (average.Value > 0 && comboPositionsAndTheirBasePositions.Keys.Contains(position) && !relevantComboPositions.Keys.Contains(position))
                {
                    relevantComboPositions.Add(position, comboPositionsAndTheirBasePositions[position]);
                }
            }

            return relevantComboPositions;
        }
        public void UpdatePlayerRelativePointsBasePosition(Player player, PointAverages averages)
        {
            string position = player.Position;
            double average1 = averages.AverageByPosition.ContainsKey($"{position}1") ? averages.AverageByPosition[$"{position}1"] : 0;
            double average2 = averages.AverageByPosition.ContainsKey($"{position}2") ? averages.AverageByPosition[$"{position}2"] : 0;
            double average3 = averages.AverageByPosition.ContainsKey($"{position}3") ? averages.AverageByPosition[$"{position}3"] : 0;
            double freeAgent = averages.AverageByPosition.ContainsKey($"{position}FA") ? averages.AverageByPosition[$"{position}FA"] : 0;

            if (average1 > 0)
            {
                player.RelativePoints[$"{position}1"] = Math.Round(player.WeeklyPoints - average1,2);
            }
            if (average2 > 0)
            {
                player.RelativePoints[$"{position}2"] = Math.Round(player.WeeklyPoints - average2,2);
            }
            if (average3 > 0)
            {
                player.RelativePoints[$"{position}3"] = Math.Round(player.WeeklyPoints - average3,2);
            }
            if (freeAgent > 0)
            {
                player.FA = Math.Round(player.WeeklyPoints - freeAgent, 2);
            }
        }

        public void UpdatePlayerRelativePointsComboPosition(Player player, Dictionary<string, List<string>> relevantComboPositions, PointAverages averages)
        {
            foreach (KeyValuePair<string, List<string>> relevantComboPosition in relevantComboPositions)
            {
                if (relevantComboPosition.Value.Contains(player.Position))
                {
                    double average1 = averages.AverageByPosition.ContainsKey($"{relevantComboPosition.Key}1") ? averages.AverageByPosition[$"{relevantComboPosition.Key}1"] : 0;
                    double average2 = averages.AverageByPosition.ContainsKey($"{relevantComboPosition.Key}2") ? averages.AverageByPosition[$"{relevantComboPosition.Key}2"] : 0;
                    double average3 = averages.AverageByPosition.ContainsKey($"{relevantComboPosition.Key}3") ? averages.AverageByPosition[$"{relevantComboPosition.Key}3"] : 0;

                    if (average1 > 0)
                    {
                        player.RelativePoints[$"{relevantComboPosition.Key}1"] = Math.Round(player.WeeklyPoints - average1, 2);
                    }
                    if (average2 > 0)
                    {
                        player.RelativePoints[$"{relevantComboPosition.Key}2"] = Math.Round(player.WeeklyPoints - average2, 2);
                    }
                    if (average3 > 0)
                    {
                        player.RelativePoints[$"{relevantComboPosition.Key}3"] = Math.Round(player.WeeklyPoints - average3, 2);
                    }
                }
            }
        }
    }
}
