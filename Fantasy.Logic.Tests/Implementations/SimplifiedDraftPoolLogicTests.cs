using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class SimplifiedDraftPoolLogicTests
    {
        SimplifiedDraftPoolLogic _logic = new();

        [Test]
        public void Get_Returns_ListOfPlayers_Given_ListOfPlayersAndPointAverages()
        {
            List<Player> players = TestService.GetValidPlayers();
            PointAverages averages = TestService.GetMockAverages(players);
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddRelativePointsToPlayers(players, averages);
            players = TestService.AddCostToPlayers(players, 5);

            SimplifiedDraftPoolRequest request = new()
            {
                PointAverages = averages,
                Players = players
            };

            SimplifiedDraftPoolResponse response = _logic.Get(request);

            Assert.That(response.Players.Count > 0);
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithEveryPosition_Given_ListOfPlayersAndPointAverages()
        {
            List<Player> players = TestService.GetValidPlayers();
            PointAverages averages = TestService.GetMockAverages(players);
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddRelativePointsToPlayers(players, averages);
            players = TestService.AddCostToPlayers(players, 5);

            SimplifiedDraftPoolRequest request = new()
            {
                PointAverages = averages,
                Players = players
            };

            SimplifiedDraftPoolResponse response = _logic.Get(request);

            List<string> positions = new();
            List<string> basePositions = PositionListService.GetListOfBasePositions();
            foreach (string basePosition in basePositions)
            {
                if (players.Exists(p => p.Position == basePosition))
                {
                    positions.Add(basePosition);
                }
            }

            foreach (string position in positions)
            {
                Assert.That(response.Players.Exists(p => p.Position == position));
            }
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithFewerPlayersThanOriginalList_Given_ListOfPlayersAndPointAverages()
        {
            List<Player> players = TestService.GetValidPlayers();
            PointAverages averages = TestService.GetMockAverages(players);
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddRelativePointsToPlayers(players, averages);
            players = TestService.AddCostToPlayers(players, 5);

            SimplifiedDraftPoolRequest request = new()
            {
                PointAverages = averages,
                Players = players
            };

            SimplifiedDraftPoolResponse response = _logic.Get(request);

            Assert.That(response.Players.Count < players.Count);
        }
    

        [Test]
        public void Get_Throws_CustomException_Given_EmptyListOfPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidListOfPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidPointAverages()
        {
            Assert.Ignore();
        }
    }
}
