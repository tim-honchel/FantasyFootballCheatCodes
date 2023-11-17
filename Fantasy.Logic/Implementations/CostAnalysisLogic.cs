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
                PositionCostMultiplier = new(),
                PositionCostErrorMargin = new(),
            };

            List<string> basePositions = PositionListService.GetListOfBasePositions();
            
            foreach (string position in basePositions)
            {
                CalculateMultiplier(analysis, players.Where(p => p.Position == position && p.FA > 0.2 && p.Cost > 0).ToList(), position);
            }

            response.Analysis = analysis;

            return response;
        }

        public void CalculateMultiplier(CostAnalysis analysis, List<Player> players, string position)
        {
            if (players == null || players.Count == 0)
            {
                return;
            }

            analysis.PositionCostMultiplier[position] = Math.Round(players.Average(p => p.Cost / p.FA),2);
            analysis.PositionCostErrorMargin[position] = Math.Round(players.Average(p => Math.Abs(p.Cost - (p.FA * analysis.PositionCostMultiplier[position]))));

            if (analysis.PositionCostErrorMargin[position] > 1)
            {
                ExcludeOutliers(analysis, players, position);
            }
            
        }

        public void ExcludeOutliers(CostAnalysis analysis, List<Player> players, string position)
        {
            List<Player> nonOutliers = players.Where(p => Math.Abs(p.Cost - (p.FA * analysis.PositionCostMultiplier[position])) <= 1.25* analysis.PositionCostErrorMargin[position]).ToList();

            analysis.PositionCostMultiplier[position] = Math.Round(nonOutliers.Average(p => p.Cost / p.FA), 2);
            analysis.PositionCostErrorMargin[position] = Math.Round(nonOutliers.Average(p => Math.Abs(p.Cost - (p.FA * analysis.PositionCostMultiplier[position]))));
        }
    }
}
