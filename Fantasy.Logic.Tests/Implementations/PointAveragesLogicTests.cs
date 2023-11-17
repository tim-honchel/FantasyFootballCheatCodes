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
            
            Assert.That(response.Averages != null);
        }

        [Test]
        public void Get_Returns_PointAveragesForEveryPosition_Given_ListOfPlayersAndRules()
        {
            List<Player> players = TestService.GetValidPlayers();
            Rules rules = TestService.GetValidRules();
            PointAveragesRequest request = new() { Players = players, Rules = rules };

            PointAveragesResponse response = _logic.Get(request);

            Assert.That(response.Averages.AverageByPosition.Keys.Count() == PositionDictionaryService.GetStarterSlotsByPosition(rules.Positions).Sum (p=>p.Value));
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
