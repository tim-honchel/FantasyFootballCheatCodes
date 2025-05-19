using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;

namespace Fantasy.Logic.Implementations
{
    public class SimplifiedDraftPoolLogic : ISimplifiedDraftPoolLogic
    {
        public SimplifiedDraftPoolResponse Get(SimplifiedDraftPoolRequest request)
        {
            SimplifiedDraftPoolResponse response = new();

            List<string> positions = GetListOfPositions(request.PointAverages);

            List<Player> draftPool = new();

            foreach(string position in positions)
            {
                SelectTopPlayersByPricePoint(draftPool, request.Players.Where(p => p.Position == position).ToList(), position);
            }

            response.Players = draftPool;
            response.Success = true;

            return response;
        }

        public List<string> GetListOfPositions(PointAverages averages)
        {
            List<string> positions = new();

            List<string> basePositions = PositionListService.GetListOfBasePositions();
            Dictionary<string, List<string>> comboPositions = PositionDictionaryService.GetComboPositionsAndTheirBasePositions();

            foreach (KeyValuePair<string, double> average in averages.AverageByPosition)
            {
                string position = average.Key.Substring(0, average.Key.Length - 1);
                if (average.Value > 0 && basePositions.Contains(position) && !positions.Contains(position))
                {
                    positions.Add(position);
                }
                else if (average.Value > 0 && comboPositions.Keys.Contains(position))
                {
                    foreach (string basePosition in comboPositions[position])
                    {
                        if (!positions.Contains(basePosition))
                        {
                            positions.Add(basePosition);
                        }
                    }
                }
            }

            return positions;
        }

        public void SelectTopPlayersByPricePoint(List<Player> draftPool, List<Player> players, string position)
        {
            players = players.OrderByDescending(p => p.WeeklyPoints).ToList();

            if (players.Count == 0)
            {
                return;
            }

            int salary = players[0].Cost + 1;
            int playersAdded = 0;

            foreach (Player player in players)
            {
                if (salary <= 1 && playersAdded > 0)
                {
                    break;
                }
                else if (player.Cost < salary)
                {
                    player.Cost = Math.Max(player.Cost, 1);
                    salary = player.Cost;
                    player.DraftPosition = position; 
                    draftPool.Add(player);
                    playersAdded++;
                }
            }


        }
    }
}
