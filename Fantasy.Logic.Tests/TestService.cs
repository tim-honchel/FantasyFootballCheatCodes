
using Fantasy.Logic.Models;
using Fantasy.Logic.Services;
using System.Numerics;

namespace Fantasy.Logic.Tests
{
    public static class TestService
    {
        public static List<Player> AddPlayers(List<Player> players, string position, int number, double topPoints, double decrement)
        {
            double points = topPoints;

            for (int i = 0; i < number; i++)
            {
                players.Add(new Player() { Position = position, DraftPosition = position, WeeklyPoints = Math.Round(points, 2) });
                points = Math.Max(0, points - decrement);
            }

            return players;
        }

        public static List<Player> AddCostToPlayers(List<Player> players, double costMultiplier)
        {
            foreach (Player player in players)
            {
                if (player.FA <= 0)
                {
                    player.Cost = 0;
                }
                else
                {
                    player.Cost = Math.Max(1, (int) (player.FA * costMultiplier));
                }
            }

            return players;
        }

        public static List<Player> AddFAValueToPlayers(List<Player> players)
        {
            Dictionary<string, double> topFreeAgentsByPosition = new();

            List<string> basePositions = PositionListService.GetListOfBasePositions();

            foreach (string position in basePositions)
            {
                List<Player> playersByPosition = players.Where(p => p.Position == position).ToList();
                if (playersByPosition != null && playersByPosition.Count > 0)
                {
                    topFreeAgentsByPosition[position] = (playersByPosition.Average(p => p.WeeklyPoints) + playersByPosition.OrderByDescending(p => p.WeeklyPoints).Last().WeeklyPoints) / 2;
                }
                
            }

            foreach (Player player in players)
            {
                player.FA = Math.Round(player.WeeklyPoints - topFreeAgentsByPosition[player.Position],2);
            }

            return players;
        }

        public static List<Player> AddRelativePointsToPlayers(List<Player> players, PointAverages averages)
        {
            foreach (Player player in players)
            {
                string position = player.Position;
                double average1 = averages.AverageByPosition.ContainsKey($"{position}1") ? averages.AverageByPosition[$"{position}1"] : 0;
                double average2 = averages.AverageByPosition.ContainsKey($"{position}2") ? averages.AverageByPosition[$"{position}2"] : 0;
                double average3 = averages.AverageByPosition.ContainsKey($"{position}3") ? averages.AverageByPosition[$"{position}3"] : 0;

                if (average1 > 0)
                {
                    player.RelativePoints[$"{position}1"] = Math.Round(player.WeeklyPoints - average1, 2);
                }
                if (average2 > 0)
                {
                    player.RelativePoints[$"{position}2"] = Math.Round(player.WeeklyPoints - average2, 2);
                }
                if (average3 > 0)
                {
                    player.RelativePoints[$"{position}3"] = Math.Round(player.WeeklyPoints - average3, 2);
                }
            }

            return players;
        }

        public static PointAverages GenerateAverage(PointAverages averages, List<Player> players, string position)
        {
            players.OrderByDescending(p => p.WeeklyPoints);

            double best = players.First().WeeklyPoints;
            double average = players.Average(p => p.WeeklyPoints);
            double worst = players.Last().WeeklyPoints;

            averages.AverageByPosition[$"{position}1"] = Math.Round((2 * best + average) / 3, 2);
            averages.AverageByPosition[$"{position}2"] = Math.Round((best + 2 * average) / 3, 2);
            averages.AverageByPosition[$"{position}3"] = Math.Round(average, 2);
            averages.AverageByPosition[$"{position}FA"] = Math.Round((2 * average + worst) / 3, 2);

            return averages;
        }

        public static PointAverages GetMockAverages(List<Player> players)
        {
            PointAverages averages = new();

            List<string> basePositions = PositionListService.GetListOfBasePositions();


            foreach (string position in basePositions)
            {
                List<Player> playersByPosition = players.Where(x => x.Position == position).ToList();
                if (playersByPosition.Count() > 0)
                {
                    GenerateAverage(averages, playersByPosition, position);
                }
            }

            Dictionary<string, List<string>> comboPositionsAndTheirBasePositions = PositionDictionaryService.GetComboPositionsAndTheirBasePositions();

            foreach (string comboPosition in comboPositionsAndTheirBasePositions.Keys)
            {
                List<Player> playersByPosition = players.Where(x => comboPositionsAndTheirBasePositions[comboPosition].Contains(x.Position)).ToList();
                if (playersByPosition.Count() > 0)
                {
                    GenerateAverage(averages, playersByPosition, comboPosition);
                }
            }
            return averages;
        }

        public static CostAnalysis GetMockCostAnalysis(List<Player> players)
        {
            CostAnalysis analysis = new CostAnalysis();

            List<string> basePositions = PositionListService.GetListOfBasePositions();

            foreach (string position in basePositions)
            {
                if (players.Where(p => p.Position == position).Count() == 0)
                {
                    break;
                }

                analysis.PositionCostBase[position] = players.Where(p => p.Position == position && p.Cost <= 1).Max(p =>p.FA);
                
                if (players.Where(p => p.Position == position && p.Cost > 1).Count() == 0)
                {
                    break;
                }

                analysis.PositionCostMultiplier[position] = Math.Round(players.Where(p => p.Position == position && p.Cost > 1).Average(p => p.Cost - 1) / players.Where(p => p.Position == position && p.Cost > 1).Average(p => p.FA - analysis.PositionCostBase[position]),2);

                analysis.PositionCostErrorMargin[position] = 1;
            }

            return analysis;
        }

        public static List<Player> GetValidPlayers()
        {
            List<Player> players = new() { };

            AddPlayers(players, BasePositionConstants.Quarterback, 40, 22, 0.25);
            AddPlayers(players, BasePositionConstants.RunningBack, 90, 16, 0.25);
            AddPlayers(players, BasePositionConstants.WideReceiver, 70, 14, 0.2);
            AddPlayers(players, BasePositionConstants.TightEnd, 40, 11, 0.15);


            AddPlayers(players, BasePositionConstants.Kicker, 30, 8, 0.1);
            AddPlayers(players, BasePositionConstants.Punter, 30, 6, 0.1);
            AddPlayers(players, BasePositionConstants.Coach, 30, 5, 0.1);

            AddPlayers(players, BasePositionConstants.TeamQuarterback, 30, 10, 0.1);
            AddPlayers(players, BasePositionConstants.TeamDefense, 30, 8, 0.1);

            AddPlayers(players, BasePositionConstants.DefensiveTackle, 40, 8, 0.15);
            AddPlayers(players, BasePositionConstants.DefensiveEnd, 40, 9, 0.15);
            AddPlayers(players, BasePositionConstants.Linebacker, 40, 10, 0.15);
            AddPlayers(players, BasePositionConstants.Cornerback, 40, 9, 0.15);
            AddPlayers(players, BasePositionConstants.Safety, 40, 8, 0.15);

            return players;
        }

        public static Rules GetValidRules()
        {
            Positions positions = new()
            {
                Quarterbacks = new int[] { 1, 3 },
                RunningBacks = new int[] { 2, 8 },
                WideReceivers = new int[] { 2, 8 },
                TightEnds = new int[] { 1, 3 },

                Kickers = new int[] { 1, 2 },
                Punters = new int[] { 1, 2 },
                Coaches = new int[] { 1, 2 },

                TeamQuarterbacks = new int[] { 1, 3 },
                TeamDefenses = new int[] { 1, 3 },

                DefensiveTackles = new int[] { 1, 3 },
                DefensiveEnds = new int[] { 1, 3 },
                Linebackers = new int[] { 1, 3 },
                Cornerbacks = new int[] { 1, 3 },
                Safeties = new int[] { 1, 3 },

                FLEX = 1,
                OffensivePlayerUtilities = 1,
                BacksAndReceivers = 1,
                ReceiversAndEnds = 1,

                DefensiveLinemen = 1,
                DefensiveBacks = 1,
                DefensivePlayerUtilities = 1,

                Bench = 7,
                InjuredReserve = 0
            };

            Settings settings = new()
            {
                DraftType = DraftType.Auction,
                DraftOrderType = DraftOrderType.Other,
                Keeper = false,
                SalaryCap = 200
            };

            Size size = new()
            {
                Teams = 10,
                PlayoffTeams = 4
            };

            Status status = new()
            {
                IsActive = true,
                Season = DateTime.Now.Year
            };

            Rules rules = new()
            {
                Positions = positions,
                Settings = settings,
                Size = size,
                Status = status
            };

            return rules;
        }
    }
}
