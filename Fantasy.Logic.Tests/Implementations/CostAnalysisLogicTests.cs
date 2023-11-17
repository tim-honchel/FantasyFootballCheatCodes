using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class CostAnalysisLogicTests
    {
        CostAnalysisLogic _logic = new();

        [Test]
        public void Get_Returns_CostAnalysis_Given_ListOfPlayersAndAuctionType()
        {
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, 5);
            CostAnalysisRequest request = new()
            {
                Players = players,
                DraftType = DraftType.Auction
            };

            CostAnalysisResponse response = _logic.Get(request);

            Assert.That(response.Analysis != null);
        }

        [Test]
        public void Get_Returns_CostAnalysisWithNonZeroValues_Given_ListOfPlayersAndAuctionType()
        {
            int costMultiplier = 5;
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, costMultiplier);
            CostAnalysisRequest request = new()
            {
                Players = players,
                DraftType = DraftType.Auction
            };

            CostAnalysisResponse response = _logic.Get(request);

            Assert.That(response.Analysis.PositionCostMultiplier.Values.Sum() != 0);
        }

        [Test]
        public void Get_Returns_CorrectMultiplier_Given_ListOfPlayersAndAuctionType()
        {
            int costMultiplier = 5;
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, costMultiplier);
            CostAnalysisRequest request = new()
            {
                Players = players,
                DraftType = DraftType.Auction
            };

            CostAnalysisResponse response = _logic.Get(request);

            Assert.That(response.Analysis.PositionCostMultiplier.Values.Min() >= costMultiplier - 1);
            Assert.That(response.Analysis.PositionCostMultiplier.Values.Max() <= costMultiplier + 1);
        }

        [Test]
        public void Get_Returns_CorrectResidual_Given_ListOfPlayersAndAuctionType()
        {
            int costMultiplier = 5;
            List<Player> players = TestService.GetValidPlayers();
            players = TestService.AddFAValueToPlayers(players);
            players = TestService.AddCostToPlayers(players, costMultiplier);
            CostAnalysisRequest request = new()
            {
                Players = players,
                DraftType = DraftType.Auction
            };

            CostAnalysisResponse response = _logic.Get(request);

            Assert.That(response.Analysis.PositionCostErrorMargin.Values.Min() == 0);
            Assert.That(response.Analysis.PositionCostErrorMargin.Values.Max() == 1);
        }

        [Test]
        public void Get_Throws_CustomException_Given_EmptyListOfPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InsufficientPlayers()
        {
            Assert.Ignore();
        }
    }
}
