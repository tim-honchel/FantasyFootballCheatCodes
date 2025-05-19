using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class StrongRosterLogicTests
    {
        StrongRosterLogic _logic = new();

        [Test]
        public void Get_Returns_ListOfPlayersWithEveryPosition_Given_ListOfPlayersAndRules()
        {
            Rules rules = TestService.GetValidRules();
            List<Player> players = TestService.GetValidDraftPool(rules.Positions);
            PointAverages averages = TestService.GetMockAverages(players);
            players = TestService.AddRelativePointsToPlayers(players, averages);
            players = TestService.AddComboRelativePointsToPlayers(players, averages);
            players = TestService.AddPlayerID(players);
            StrongRosterRequest request = new()
            {
                Players = players,
                Rules = rules
            };

            StrongRosterResponse response = _logic.Get(request);

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
                Assert.That(response.Roster.Players.Exists(p => p.Position == position));
            }

        }

        [Test]
        public void Get_Returns_ListOfPlayersUnderSalaryCap_Given_ListOfPlayersAndRules()
        {
            Rules rules = TestService.GetValidRules();
            List<Player> players = TestService.GetValidDraftPool(rules.Positions);
            PointAverages averages = TestService.GetMockAverages(players);
            players = TestService.AddRelativePointsToPlayers(players, averages);
            players = TestService.AddComboRelativePointsToPlayers(players, averages);
            players = TestService.AddPlayerID(players);
            StrongRosterRequest request = new()
            {
                Players = players,
                Rules = rules
            };

            StrongRosterResponse response = _logic.Get(request);

            Assert.That(response.Roster.Cost <= rules.Settings.SalaryCap - rules.Positions.Bench);
        }

        [Test]
        public void Get_Returns_ListOfPlayersWithAboveAveragePoints_Given_ListOfPlayersAndRules()
        {
            Rules rules = TestService.GetValidRules();
            List<Player> players = TestService.GetValidDraftPool(rules.Positions);
            PointAverages averages = TestService.GetMockAverages(players);
            players = TestService.AddRelativePointsToPlayers(players, averages);
            players = TestService.AddComboRelativePointsToPlayers(players, averages);
            players = TestService.AddPlayerID(players);
            StrongRosterRequest request = new()
            {
                Players = players,
                Rules = rules
            };

            StrongRosterResponse response = _logic.Get(request);

            var startingPositions = TestService.GetStartingPositions(rules.Positions);
            double averageTeamPoints = 0;
            foreach (var position in startingPositions)
            {
                averageTeamPoints += averages.AverageByPosition[position];
            }


            Assert.That(response.Roster.TotalPoints >= averageTeamPoints);
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
        public void Get_Throws_CustomException_Given_InvalidRules()
        {
            Assert.Ignore();
        }
    }
}
