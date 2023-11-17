using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class RelativePointsLogicTests
    {
        RelativePointsLogic _logic = new();

        [Test]
        public void Get_Returns_ListOfPlayers_Given_ListOfPlayersAndPointAverages()
        {
            List<Player> players = TestService.GetValidPlayers();
            PointAverages averages = TestService.GetMockAverages(players);

            RelativePointsRequest request = new RelativePointsRequest()
            {
                Players = players,
                PointAverages = averages
            };

            RelativePointsResponse response = _logic.Get(request);

            Assert.That(response.Players.Count == players.Count);
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithRelativePoints_Given_ListOfPlayersAndPointAverages()
        {
            List<Player> players = TestService.GetValidPlayers();
            PointAverages averages = TestService.GetMockAverages(players);

            RelativePointsRequest request = new RelativePointsRequest()
            {
                Players = players,
                PointAverages = averages
            };

            RelativePointsResponse response = _logic.Get(request);

            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().RelativePointsByPosition["QB1"] != 0);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().QB1 != 0);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.RunningBack).First().RB1 != 0);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.WideReceiver).First().WR1 != 0);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.TightEnd).First().TE1 != 0);
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithCorrectRelativePoints_Given_ListOfPlayersAndPointAverages()
        {
            List<Player> players = TestService.GetValidPlayers();
            PointAverages averages = TestService.GetMockAverages(players);

            RelativePointsRequest request = new RelativePointsRequest()
            {
                Players = players,
                PointAverages = averages
            };

            RelativePointsResponse response = _logic.Get(request);

            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().RelativePointsByPosition["QB1"] == response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().WeeklyPoints - averages.AverageByPosition["QB1"]);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().QB1 == response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().WeeklyPoints - averages.QB1);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.RunningBack).First().RB1 == response.Players.Where(p => p.Position == BasePositionConstants.RunningBack).First().WeeklyPoints - averages.RB1);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.WideReceiver).First().WR1 == response.Players.Where(p => p.Position  == BasePositionConstants.WideReceiver).First().WeeklyPoints - averages.WR1);
            //Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.TightEnd).First().TE1 == response.Players.Where(p => p.Position == BasePositionConstants.TightEnd).First().WeeklyPoints - averages.TE1);
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
