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
                if (player.Position == BasePositionConstants.Coach)
                {
                    UpdateCoachRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.Cornerback)
                {
                    UpdateCornerbackRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.DefensiveEnd)
                {
                    UpdateDefensiveEndRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.DefensiveTackle)
                {
                    UpdateDefensiveTackleRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.Kicker)
                {
                    UpdateKickerRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.Linebacker)
                {
                    UpdateLinebackerRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.Punter)
                {
                    UpdatePunterRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.Quarterback)
                {
                    UpdateQuarterbackRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.RunningBack)
                {
                    UpdateRunningBackRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.Safety)
                {
                    UpdateSafetyRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.TeamDefense)
                {
                    UpdateTeamDefenseRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.TeamQuarterback)
                {
                    UpdateTeamQuarterbackRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.TightEnd)
                {
                    UpdateTightEndRelativePoints(player, request.PointAverages);
                }
                else if (player.Position == BasePositionConstants.WideReceiver)
                {
                    UpdateWideReceiverRelativePoints(player, request.PointAverages);
                }
            }

            response.Players = request.Players;
            return response;
        }

        public void UpdateCoachRelativePoints(Player player, PointAverages averages)
        {
            if (averages.HC1 > 0)
            {
                player.HC1 = player.WeeklyPoints - averages.HC1;
                player.FA = player.WeeklyPoints - averages.FAHC;
            }
        }

        public void UpdateCornerbackRelativePoints(Player player, PointAverages averages)
        {
            if (averages.CB1 > 0)
            {
                player.CB1 = player.WeeklyPoints - averages.CB1;
                player.FA = player.WeeklyPoints - averages.FACB;
            }
            if (averages.CB2 > 0)
            {
                player.CB2 = player.WeeklyPoints - averages.CB2;
            }

            if (averages.DB1 > 0)
            {
                player.DB1 = player.WeeklyPoints - averages.DB1;
            }
            if (averages.DPU1 > 0)
            {
                player.DPU1 = player.WeeklyPoints - averages.DPU1;
            }
        }

        public void UpdateDefensiveEndRelativePoints(Player player, PointAverages averages)
        {
            if (averages.DE1 > 0)
            {
                player.DE1 = player.WeeklyPoints - averages.DE1;
                player.FA = player.WeeklyPoints - averages.FADE;
            }
            if (averages.DE2 > 0)
            {
                player.DE2 = player.WeeklyPoints - averages.DE2;
            }

            if (averages.DL1 > 0)
            {
                player.DL1 = player.WeeklyPoints - averages.DL1;
            }
            if (averages.DPU1 > 0)
            {
                player.DPU1 = player.WeeklyPoints - averages.DPU1;
            }
        }

        public void UpdateDefensiveTackleRelativePoints(Player player, PointAverages averages)
        {
            if (averages.DT1 > 0)
            {
                player.DT1 = player.WeeklyPoints - averages.DT1;
                player.FA = player.WeeklyPoints - averages.FADT;
            }
            if (averages.DT2 > 0)
            {
                player.DT2 = player.WeeklyPoints - averages.DT2;
            }

            if (averages.DL1 > 0)
            {
                player.DL1 = player.WeeklyPoints - averages.DL1;
            }
            if (averages.DPU1 > 0)
            {
                player.DPU1 = player.WeeklyPoints - averages.DPU1;
            }
        }

        public void UpdateKickerRelativePoints(Player player, PointAverages averages)
        {
            if (averages.K1 > 0)
            {
                player.K1 = player.WeeklyPoints - averages.K1;
                player.FA = player.WeeklyPoints - averages.FAK;
            }
        }

        public void UpdateLinebackerRelativePoints(Player player, PointAverages averages)
        {
            if (averages.LB1 > 0)
            {
                player.LB1 = player.WeeklyPoints - averages.LB1;
                player.FA = player.WeeklyPoints - averages.FALB;
            }
            if (averages.LB2 > 0)
            {
                player.LB2 = player.WeeklyPoints - averages.LB2;
            }

            if (averages.DPU1 > 0)
            {
                player.DPU1 = player.WeeklyPoints - averages.DPU1;
            }
        }

        public void UpdatePunterRelativePoints(Player player, PointAverages averages)
        {
            if (averages.P1 > 0)
            {
                player.P1 = player.WeeklyPoints - averages.P1;
                player.FA = player.WeeklyPoints - averages.FAP;
            }
        }

        public void UpdateQuarterbackRelativePoints(Player player, PointAverages averages)
        {
            if (averages.QB1 > 0)
            {
                player.QB1 = player.WeeklyPoints - averages.QB1;
                player.FA = player.WeeklyPoints - averages.FAQB;
            }
            if (averages.QB2 > 0)
            {
                player.QB2 = player.WeeklyPoints - averages.QB2;
            }

            if (averages.OPU1 > 0)
            {
                player.OPU1 = player.WeeklyPoints - averages.OPU1;
            }
        }

        public void UpdateRunningBackRelativePoints(Player player, PointAverages averages)
        {
            if (averages.RB1 > 0)
            {
                player.RB1 = player.WeeklyPoints - averages.RB1;
                player.FA = player.WeeklyPoints - averages.FARB;
            }
            if (averages.RB2 > 0)
            {
                player.RB2 = player.WeeklyPoints - averages.RB2;
            }
            if (averages.RB3 > 0)
            {
                player.RB3 = player.WeeklyPoints - averages.RB3;
            }

            if (averages.RBWR1 > 0)
            {
                player.RBWR1 = player.WeeklyPoints - averages.RBWR1;
            }
            if (averages.FLEX1 > 0)
            {
                player.FLEX1 = player.WeeklyPoints - averages.FLEX1;
            }
            if (averages.OPU1 > 0)
            {
                player.OPU1 = player.WeeklyPoints - averages.OPU1;
            }
        }

        public void UpdateSafetyRelativePoints(Player player, PointAverages averages)
        {
            if (averages.S1 > 0)
            {
                player.S1 = player.WeeklyPoints - averages.S1;
                player.FA = player.WeeklyPoints - averages.FAS;
            }
            if (averages.S2 > 0)
            {
                player.S2 = player.WeeklyPoints - averages.S2;
            }

            if (averages.DB1 > 0)
            {
                player.DB1 = player.WeeklyPoints - averages.DB1;
            }
            if (averages.DPU1 > 0)
            {
                player.DPU1 = player.WeeklyPoints - averages.DPU1;
            }
        }

        public void UpdateTeamDefenseRelativePoints(Player player, PointAverages averages)
        {
            if (averages.DEF1 > 0)
            {
                player.DEF1 = player.WeeklyPoints - averages.DEF1;
                player.FA = player.WeeklyPoints - averages.FADEF;
            }
        }

        public void UpdateTeamQuarterbackRelativePoints(Player player, PointAverages averages)
        {
            if (averages.TQB1 > 0)
            {
                player.TQB1 = player.WeeklyPoints - averages.TQB1;
                player.FA = player.WeeklyPoints - averages.FATQB;
            }
        }

        public void UpdateTightEndRelativePoints(Player player, PointAverages averages)
        {
            if (averages.TE1 > 0)
            {
                player.TE1 = player.WeeklyPoints - averages.TE1;
                player.FA = player.WeeklyPoints - averages.FATE;
            }
            if (averages.TE2 > 0)
            {
                player.TE2 = player.WeeklyPoints - averages.TE2;
            }

            if (averages.WRTE1 > 0)
            {
                player.WRTE1 = player.WeeklyPoints - averages.WRTE1;
            }
            if (averages.FLEX1 > 0)
            {
                player.FLEX1 = player.WeeklyPoints - averages.FLEX1;
            }
            if (averages.OPU1 > 0)
            {
                player.OPU1 = player.WeeklyPoints - averages.OPU1;
            }
        }

        public void UpdateWideReceiverRelativePoints(Player player, PointAverages averages)
        {
            if (averages.WR1 > 0)
            {
                player.WR1 = player.WeeklyPoints - averages.WR1;
                player.FA = player.WeeklyPoints - averages.FAWR;
            }
            if (averages.WR2 > 0)
            {
                player.WR2 = player.WeeklyPoints - averages.WR2;
            }
            if (averages.WR3 > 0)
            {
                player.WR3 = player.WeeklyPoints - averages.WR3;
            }

            if (averages.RBWR1 > 0)
            {
                player.RBWR1 = player.WeeklyPoints - averages.RBWR1;
            }
            if (averages.WRTE1 > 0)
            {
                player.WRTE1 = player.WeeklyPoints - averages.WRTE1;
            }
            if (averages.FLEX1 > 0)
            {
                player.FLEX1 = player.WeeklyPoints - averages.FLEX1;
            }
            if (averages.OPU1 > 0)
            {
                player.OPU1 = player.WeeklyPoints - averages.OPU1;
            }
        }
    }
}
