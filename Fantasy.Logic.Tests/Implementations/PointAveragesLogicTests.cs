using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class PointAveragesLogicTests
    {
        PointAveragesLogic _logic = new();

        [Test]
        public void Get_Returns_PointAverages_Given_ListOfPlayersAndRules()
        {
            List<Player> players = TestService.GetValidPlayers();
            Rules rules = TestService.GetValidRules();
            PointAveragesRequest request = new() { Players = players, Rules = rules };

            PointAveragesResponse response = _logic.Get(request);
            
            Assert.That(response.Averages.AverageByPosition.Count() > 0);
        }

        [Test]
        public void Get_Returns_PointAveragesForEveryPosition_Given_ListOfPlayersAndRules()
        {
            List<Player> players = TestService.GetValidPlayers();
            Rules rules = TestService.GetValidRules();
            PointAveragesRequest request = new() { Players = players, Rules = rules };

            PointAveragesResponse response = _logic.Get(request);

            List<string> basePositions = PositionListService.GetListOfBasePositions();
            Dictionary<string,int> starters = PositionDictionaryService.GetStarterSlotsByPosition(rules.Positions);
            int freeAgentPositions = starters.Count(s => basePositions.Contains(s.Key));
            int starterSlots = starters.Sum(s => s.Value);

            Assert.That(response.Averages.AverageByPosition.Keys.Count() == starterSlots + freeAgentPositions);
        }

        [Test]
        public void Get_Returns_CorrectPointAverages_Given_ListOfPlayersAndRules()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidListOfPlayers()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidRules()
        {
            Assert.Ignore();
        }

        

        

    }
}
