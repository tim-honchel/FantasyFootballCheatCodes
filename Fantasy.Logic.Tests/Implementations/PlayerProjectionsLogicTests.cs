using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class PlayerProjectionsLogicTests
    {
        PlayerProjectionsLogic _logic = new();

        [Test]
        public void Get_Returns_ListOfPlayers_Given_ListOfRawPlayers()
        {
            PlayerESPN player = new()
            {
                ID = 1,
                LastName = "Last",
                FirstName = "First",
                ProTeamID = 3,
                DefaultPositionID = 4
            };
            List<PlayerESPN> espnPlayers = new();
            espnPlayers.Add(player);
            PlayerProjectionsRequest request = new()
            {
                Players =espnPlayers
            };
            PlayerProjectionsResponse response = _logic.Get(request);

            List<Player> players = response.Players;
            Assert.IsNotNull(players);
        }

        [Test]
        public void Get_Returns_SameListOfPlayers_Given_ListOfRawPlayers()
        {
            PlayerESPN player1 = new()
            {
                ID = 1,
                LastName = "Last",
                FirstName = "First",
                ProTeamID = 3,
                DefaultPositionID = 4
            };
            PlayerESPN player2 = new()
            {
                ID = 2,
                LastName = "LastName",
                FirstName = "TheFirst",
                ProTeamID = 4,
                DefaultPositionID = 5
            };
            List<PlayerESPN> espnPlayers = new();
            espnPlayers.Add(player1);
            espnPlayers.Add(player2);
            PlayerProjectionsRequest request = new()
            {
                Players = espnPlayers
            };
            PlayerProjectionsResponse response = _logic.Get(request);

            List<Player> players = response.Players;
            Assert.That(players.Count, Is.EqualTo(espnPlayers.Count));
            Assert.That(players.Count > 0);
            Assert.That(players.First().PlayerID, Is.EqualTo(player1.ID));
            Assert.That(players.First().LastName, Is.EqualTo(player1.LastName));
            Assert.That(players.First().FirstInitial, Is.EqualTo(player1.FirstName[0].ToString()));
            Assert.That(players.Last().PlayerID, Is.EqualTo(player2.ID));
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithNonZeroProperties_Given_ListOfRawPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithCorrectProperties_Given_ListOfRawPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_EmptyListOfRawPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidListOfRawPlayers()
        {
            Assert.Ignore();
        }
    }
}
