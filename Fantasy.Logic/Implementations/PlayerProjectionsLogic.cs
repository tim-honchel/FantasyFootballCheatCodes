using Fantasy.Logic.Interfaces;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;

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
                {0, "TQB" },
                {1, "QB" },
                {2, "RB" },
                {3, "WR" },
                {4, "TE" },
                {5, "K" },
                {6, "P" },
                {7, "HC" },
                {8, "DT" },
                {9, "DE" },
                {10, "LB" },
                {11, "CB" },
                {12, "S" },
                {16, "DEF" },

            };

            string position = positionFinder.ContainsKey(positionID) ? positionFinder[positionID] : positionID.ToString();
        
            return position;
        }

        public string ParseTeam(int teamID)
        {
            var teamFinder = new Dictionary<int, string>()
            {
                {1, "ATL" },
                {2, "BUF" },
                {3, "CHI" },
                {4, "CIN" },
                {5, "CLE" },
                {6, "DAL" },
                {7, "DEN" },
                {8, "DET" },
                {9, "GB" },
                {10, "TEN" },
                {11, "IND" },
                {12, "KC" },
                {13, "LV" },
                {14, "LAR" },
                {15, "MIA" },
                {16, "MIN" },
                {17, "NE" },
                {18, "NO" },
                {19, "NYG" },
                {20, "NYJ" },
                {21, "PHI" },
                {22, "ARI" },
                {23, "PIT" },
                {24, "LAC" },
                {25, "SF" },
                {26, "SEA" },
                {27, "TB" },
                {28, "WAS" },
                {29, "CAR" },
                {30, "JAC" },
                {33, "BAL" },
                {34, "HOU" }
            };

            string team = teamFinder.ContainsKey(teamID) ? teamFinder[teamID] : teamID.ToString();

            return team;
        }
    }
}
