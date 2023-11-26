using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class ExpectedValueLogicTests
    {
        ExpectedValueLogic _logic = new();

        [Test]
        public void Get_Returns_ListOfPlayers_Given_ListOfPlayersAndCostAnalysis()
        {
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, 5);
            CostAnalysis analysis = TestService.GetMockCostAnalysis(players);

            ExpectedValueRequest request = new()
            {
                CostAnalysis = analysis,
                Players = players
            };

            ExpectedValueResponse response = _logic.Get(request);

            Assert.IsNotNull(response.Players);
        }

        [Test]
        public void Get_Returns_SameListOfPlayers_Given_ListOfPlayersAndCostAnalysis()
        {
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, 5);
            CostAnalysis analysis = TestService.GetMockCostAnalysis(players);

            ExpectedValueRequest request = new()
            {
                CostAnalysis = analysis,
                Players = players
            };

            ExpectedValueResponse response = _logic.Get(request);

            Assert.That(response.Players.Count() == players.Count());
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithNonZeroExpectedValues_Given_ListOfPlayersAndCostAnalysis()
        {
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, 5);
            CostAnalysis analysis = TestService.GetMockCostAnalysis(players);

            ExpectedValueRequest request = new()
            {
                CostAnalysis = analysis,
                Players = players
            };

            ExpectedValueResponse response = _logic.Get(request);

            Assert.That(response.Players.Where(p => p.ExpectedValue != 0).Count() > 0);
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithCorrectExpectedValues_Given_ListOfPlayersAndCostAnalysis()
        {
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, 5);
            CostAnalysis analysis = TestService.GetMockCostAnalysis(players);

            ExpectedValueRequest request = new()
            {
                CostAnalysis = analysis,
                Players = players
            };

            ExpectedValueResponse response = _logic.Get(request);

            Player startingQuarterback = response.Players.Where(p => p.Position == BasePositionConstants.Quarterback && p.ExpectedValue > 1).First();
            Player benchQuarterback = response.Players.Where(p => p.Position == BasePositionConstants.Quarterback && p.ExpectedValue == 1).First();
            Player freeAgentQuarterback = response.Players.Where(p => p.Position == BasePositionConstants.Quarterback && p.ExpectedValue == 0).First();

            Assert.That(startingQuarterback.ExpectedValue == Math.Round(1 + (startingQuarterback.FA - analysis.PositionCostBase[BasePositionConstants.Quarterback]) * analysis.PositionCostMultiplier[BasePositionConstants.Quarterback],0));
            Assert.That(benchQuarterback.FA > 0 && benchQuarterback.FA <= analysis.PositionCostBase[BasePositionConstants.Quarterback]);
            Assert.That(freeAgentQuarterback.FA <= 0);
        }

        [Test]
        public void Get_Throws_CustomException_Given_EmptyListOfPlayersD()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidListOfPlayersD()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidCostAnalysis()
        {
            Assert.Ignore();
        }
    }
}
