using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;

namespace Fantasy.Logic.Implementations
{
    public class PlayerProjectionsLogic : IPlayerProjectionsLogic
    {
        public PlayerProjectionsResponse Get(PlayerProjectionsRequest request)
        {
            PlayerProjectionsResponse response = new();
            List<Player> players = new();

            foreach (PlayerESPN playerESPN in request.Players)
            {
                string position = ParsePosition(playerESPN.DefaultPositionID);
                string team = ParseTeam(playerESPN.ProTeamID);
                string lastName = position != "DEF" ? playerESPN.LastName : playerESPN.FirstName;
                string firstInitial = position != "DEF" ? playerESPN.FirstName[0].ToString() : "DEF";

                Player player = new()
                {
                    PlayerID = playerESPN.ID,
                    LastName = lastName,
                    FirstInitial = firstInitial,
                    Position = position,
                    Team = team,
                    Cost = playerESPN.DraftAuctionValue,
                    WeeklyPoints = playerESPN.ThisYearProjectedPointsPerWeek
                };
                players.Add(player);
            }

            response.Players = players;
            response.Success = true;

            return response;
        }

        public string ParsePosition(int positionID)
        {
            Dictionary<int, string> positionFinder = new()
            {
                {0, PositionConstants.TeamQuarterback },
                {1, PositionConstants.Quarterback },
                {2, PositionConstants.RunningBack },
                {3, PositionConstants.WideReceiver },
                {4, PositionConstants.TightEnd },
                {5, PositionConstants.Kicker },
                {6, PositionConstants.Punter },
                {7, PositionConstants.Coach },
                {8, PositionConstants.DefensiveTackle },
                {9, PositionConstants.DefensiveEnd },
                {10, PositionConstants.Linebacker },
                {11, PositionConstants.Cornerback },
                {12, PositionConstants.Safety },
                {16, PositionConstants.TeamDefense },

            };

            string position = positionFinder.ContainsKey(positionID) ? positionFinder[positionID] : positionID.ToString();
        
            return position;
        }

        public string ParseTeam(int teamID)
        {
            var teamFinder = new Dictionary<int, string>()
            {
                {1, TeamConstants.AtlantaFalcons },
                {2, TeamConstants.BuffaloBills },
                {3, TeamConstants.ChicagoBears },
                {4, TeamConstants.CincinnatiBengals },
                {5, TeamConstants.ClevelandBrowns },
                {6, TeamConstants.DallasCowboys },
                {7, TeamConstants.DenverBroncos },
                {8, TeamConstants.DetroitLions },
                {9, TeamConstants.GreenBayPackers },
                {10, TeamConstants.TennesseeTitans },
                {11, TeamConstants.IndianapolisColts },
                {12, TeamConstants.KansasCityChiefs },
                {13, TeamConstants.LasVegasRaiders },
                {14, TeamConstants.LosAngelesRams},
                {15, TeamConstants.MiamiDolphins },
                {16, TeamConstants.MinnesotaVikings },
                {17, TeamConstants.NewEnglandPatriots },
                {18, TeamConstants.NewOrleansSaints },
                {19, TeamConstants.NewYorkGiants },
                {20, TeamConstants.NewYorkJets },
                {21, TeamConstants.PhiladelphiaEagles },
                {22, TeamConstants.ArizonaCardinals },
                {23, TeamConstants.PittsburghSteelers },
                {24, TeamConstants.LosAngelesChargers },
                {25, TeamConstants.SanFrancisco49ers },
                {26, TeamConstants.SeattleSeahawks },
                {27, TeamConstants.TampaBayBucaneers },
                {28, TeamConstants.WashingtonCommanders },
                {29, TeamConstants.CarolinaPanthers },
                {30, TeamConstants.JacksonvilleJaguars },
                {33, TeamConstants.BaltimoreRavens },
                {34, TeamConstants.HoustonTexans }
            };

            string team = teamFinder.ContainsKey(teamID) ? teamFinder[teamID] : teamID.ToString();

            return team;
        }
    }
}
