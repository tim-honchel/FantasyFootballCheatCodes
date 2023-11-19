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

            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().RelativePoints[$"{BasePositionConstants.Quarterback}1"] != 0);
            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.RunningBack).First().RelativePoints[$"{BasePositionConstants.RunningBack}1"] != 0);
            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.WideReceiver).First().RelativePoints[$"{BasePositionConstants.WideReceiver}1"] != 0);
            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.TightEnd).First().RelativePoints[$"{BasePositionConstants.TightEnd}1"] != 0);
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

            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().RelativePoints[$"{BasePositionConstants.Quarterback}1"] == Math.Round(response.Players.Where(p => p.Position == BasePositionConstants.Quarterback).First().WeeklyPoints - averages.AverageByPosition[$"{BasePositionConstants.Quarterback}1"],2));
            Assert.That(response.Players.Where(p => p.Position == BasePositionConstants.RunningBack).First().RelativePoints[$"{BasePositionConstants.RunningBack}1"] == Math.Round(response.Players.Where(p => p.Position == BasePositionConstants.RunningBack).First().WeeklyPoints - averages.AverageByPosition[$"{BasePositionConstants.RunningBack}1"],2));

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
