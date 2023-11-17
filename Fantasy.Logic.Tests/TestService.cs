
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
                players.Add(new Player() { Position = position, WeeklyPoints = Math.Round(points, 2) });
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

        public static PointAverages GenerateAverage(PointAverages averages, List<Player> players, string position)
        {
            players.OrderByDescending(p => p.WeeklyPoints);

            if (position == BasePositionConstants.Coach)
            {
                averages.HC1 = Math.Round(players.Average(p => p.WeeklyPoints),2);
                averages.FAHC = Math.Round(players.Last().WeeklyPoints,2);
            }
            else if (position == BasePositionConstants.Cornerback)
            {
                averages.CB1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.CB2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FACB = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.DefensiveEnd)
            {
                averages.DE1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.DE2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FADE = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.DefensiveTackle)
            {
                averages.DT1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.DT2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FADT = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.Kicker)
            {
                averages.K1 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FAK = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.Linebacker)
            {
                averages.LB1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.LB2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FALB = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.Punter)
            {
                averages.P1 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FAP = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.Quarterback)
            {
                averages.QB1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.QB2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FAQB = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.RunningBack)
            {
                averages.RB1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.RB2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.RB3 = Math.Round(players.Average(p => p.WeeklyPoints) - 1, 2);
                averages.FARB = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.Safety)
            {
                averages.S1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.S2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FAS = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.TeamDefense)
            {
                averages.DEF1 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FADEF = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.TeamQuarterback)
            {
                averages.TQB1 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FATQB = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.TightEnd)
            {
                averages.TE1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.TE2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.FATE = Math.Round(players.Last().WeeklyPoints, 2);
            }
            else if (position == BasePositionConstants.WideReceiver)
            {
                averages.WR1 = Math.Round(players.First().WeeklyPoints, 2) - 1;
                averages.WR2 = Math.Round(players.Average(p => p.WeeklyPoints), 2);
                averages.WR3 = Math.Round(players.Average(p => p.WeeklyPoints) - 1, 2);
                averages.FAWR = Math.Round(players.Last().WeeklyPoints, 2);
            }

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

                averages.OPU1 = Math.Round((averages.QB2 + averages.FAQB) / 2,2);
                averages.FLEX1 = Math.Round((averages.RB3 + averages.FARB + averages.WR3 + averages.FAWR) / 4,2);
                averages.RBWR1 = Math.Round(averages.FLEX1, 2);
                averages.WRTE1 = Math.Round((averages.WR3 + averages.FAWR + averages.TE2 + averages.FATE) / 4,2);
                averages.DL1 = Math.Round((averages.DE2 + averages.FADE + averages.DT2 + averages.FADT) / 4,2);
                averages.DB1 = Math.Round((averages.CB2 + averages.FACB + averages.S2 + averages.FAS) / 4,2);
                averages.DPU1 = Math.Round((averages.LB2 + averages.FALB + averages.DL1 + averages.DB1) / 4,2);
            }



            return averages;
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
