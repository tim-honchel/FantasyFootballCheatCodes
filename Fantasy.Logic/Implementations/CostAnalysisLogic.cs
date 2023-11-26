using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;

namespace Fantasy.Logic.Implementations
{
    public class CostAnalysisLogic : ICostAnalysisLogic
    {
        public CostAnalysisResponse Get(CostAnalysisRequest request)
        {

            CostAnalysisResponse response = new();

            if (request.DraftType == DraftType.Auction)
            {
                response = GetCostAnalysisForAuctionDraft(request.Players);
            }
            else
            {
                response.Success = false;
            }

            return response;
        }


        public CostAnalysisResponse GetCostAnalysisForAuctionDraft(List<Player> players)
        {
            CostAnalysisResponse response = new();

            CostAnalysis analysis = new()
            {
                PositionCostBase = new(),
                PositionCostMultiplier = new(),
                PositionCostErrorMargin = new(),
            };

            List<string> basePositions = PositionListService.GetListOfBasePositions();
            
            foreach (string position in basePositions)
            {
                CalculateBase(analysis, players.Where(p => p.Position == position && p.FA > 0).ToList(), position);
                CalculateMultiplier(analysis, players.Where(p => p.Position == position && p.FA > analysis.PositionCostBase[position] && p.Cost > 1).ToList(), position);
            }

            response.Analysis = analysis;

            return response;
        }

        public void CalculateBase(CostAnalysis analysis, List<Player> players, string position)
        {
            if (players == null || players.Count == 0)
            {
                return;
            }

            double average1Dollar = 0;
            double best1Dollar = 0;
            double worst2Dollar = 0;

            if (players.Where(p => p.Cost == 1).Count() > 0)
            {
                average1Dollar = players.Where(p => p.Cost == 1).Average(p => p.FA);
                best1Dollar = players.Where(p => p.Cost == 1).Max(p => p.FA);
                worst2Dollar = best1Dollar;
            }
            if (players.Where(p => p.Cost > 1).Count() > 0)
            {
                worst2Dollar = players.Where(p => p.Cost > 1).Min(p => p.FA);
            }

            analysis.PositionCostBase[position] = Math.Round(worst2Dollar >= best1Dollar ? best1Dollar : Math.Max(average1Dollar, worst2Dollar),2);
        }

        public void CalculateMultiplier(CostAnalysis analysis, List<Player> players, string position)
        {
            if (players == null || players.Count == 0)
            {
                return;
            }
            analysis.PositionCostMultiplier[position] = Math.Round(players.Average(p => (p.Cost - 1) / (p.FA - analysis.PositionCostBase[position])), 2);
            analysis.PositionCostErrorMargin[position] = Math.Round(players.Average(p => Math.Abs(p.Cost - (1 + (p.FA - analysis.PositionCostBase[position]) * analysis.PositionCostMultiplier[position]))));

            if (analysis.PositionCostErrorMargin[position] > 1)
            {
                ExcludeOutliers(analysis, players, position);
            }

        }

        public void ExcludeOutliers(CostAnalysis analysis, List<Player> players, string position)
        {

            int minPlayers = Math.Max(3,players.Count() / 2);

            while (analysis.PositionCostErrorMargin[position] > 1 && players.Count() > minPlayers)
            {
                foreach (Player player in players)
                {
                    player.ExpectedValue = 1 + (player.FA - analysis.PositionCostBase[position]) * analysis.PositionCostMultiplier[position];
                    player.ExpectedValueLow = player.ExpectedValue - player.Cost;
                }
                players.Remove(players.Where(n => n.ExpectedValueLow == players.Max(n => n.ExpectedValueLow)).First());
                players.Remove(players.Where(n => n.ExpectedValueLow == players.Min(n => n.ExpectedValueLow)).First());
                analysis.PositionCostMultiplier[position] = Math.Round(players.Average(p => (p.Cost - 1) / (p.FA - analysis.PositionCostBase[position])), 2);
                analysis.PositionCostErrorMargin[position] = Math.Round(players.Average(p => Math.Abs(p.Cost - (1 + (p.FA - analysis.PositionCostBase[position]) * analysis.PositionCostMultiplier[position]))));
            }
        }
    }
}
