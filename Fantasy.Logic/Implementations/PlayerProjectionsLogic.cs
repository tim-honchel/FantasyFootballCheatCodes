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
                {0, BasePositionConstants.TeamQuarterback },
                {1, BasePositionConstants.Quarterback },
                {2, BasePositionConstants.RunningBack },
                {3, BasePositionConstants.WideReceiver },
                {4, BasePositionConstants.TightEnd },
                {5, BasePositionConstants.Kicker },
                {6, BasePositionConstants.Punter },
                {7, BasePositionConstants.Coach },
                {8, BasePositionConstants.DefensiveTackle },
                {9, BasePositionConstants.DefensiveEnd },
                {10, BasePositionConstants.Linebacker },
                {11, BasePositionConstants.Cornerback },
                {12, BasePositionConstants.Safety },
                {16, BasePositionConstants.TeamDefense },

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
