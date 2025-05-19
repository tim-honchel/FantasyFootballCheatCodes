using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

namespace Fantasy.Logic.Implementations
{
    public class ExpectedValueLogic : IExpectedValueLogic
    {
        public ExpectedValueResponse Get(ExpectedValueRequest request)
        {
            foreach (Player player in request.Players)
            {
                if (player.FA <= 0)
                {
                    player.ExpectedValue = 0;
                }
                else if (player.FA <= request.CostAnalysis.PositionCostBase[player.Position])
                {
                    player.ExpectedValue = 1;
                }
                else if (!request.CostAnalysis.PositionCostMultiplier.ContainsKey(player.Position))
                {
                    player.ExpectedValue = 0;
                }
                else
                {
                    player.ExpectedValue = Math.Round(1 + (player.FA - request.CostAnalysis.PositionCostBase[player.Position]) * request.CostAnalysis.PositionCostMultiplier[player.Position],0);
                }

                if (request.CostAnalysis.PositionCostErrorMargin.ContainsKey(player.Position))
                {
                    player.ExpectedValueLow = Math.Max(0, player.ExpectedValue - request.CostAnalysis.PositionCostErrorMargin[player.Position]);
                    player.ExpectedValueHigh = Math.Min(player.ExpectedValue * 2 + 1, player.ExpectedValue + request.CostAnalysis.PositionCostErrorMargin[player.Position]);
                }
                else
                {
                    player.ExpectedValueLow = Math.Max(0, player.ExpectedValue - 1);
                    player.ExpectedValueHigh = player.ExpectedValue == 0 ? 1 : player.ExpectedValue;
                }
            }

            ExpectedValueResponse response = new()
            {
                Players = request.Players,
                Success = true
            };

            return response;
        }
    }
}
