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

            foreach (Player player in request.Players)
            {
                UpdatePlayerRelativePoints(player, request.PointAverages);
            }

            response.Players = request.Players;
            return response;
        }
        public void UpdatePlayerRelativePoints(Player player, PointAverages averages)
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
    }
}
