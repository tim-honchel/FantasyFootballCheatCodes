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
            List<Player> players = GetSamplePlayers();
            Rules rules = GetSampleRules();
            PointAveragesRequest request = new() { Players = players, Rules = rules };

            PointAveragesResponse response = _logic.Get(request);
            
            Assert.That(response.Averages != null);
        }

        [Test]
        public void Get_Returns_PointAveragesForEveryPosition_Given_ListOfPlayersAndRules()
        {
            List<Player> players = GetSamplePlayers();
            Rules rules = GetSampleRules();
            PointAveragesRequest request = new() { Players = players, Rules = rules };

            PointAveragesResponse response = _logic.Get(request);

            Assert.That(response.Averages.QB1 != 0);
            Assert.That(response.Averages.RB1 != 0);
            Assert.That(response.Averages.RB2 != 0);
            Assert.That(response.Averages.WR1 != 0);
            Assert.That(response.Averages.WR2 != 0);
            Assert.That(response.Averages.TE1 != 0);
            Assert.That(response.Averages.DEF1 != 0);
            Assert.That(response.Averages.K1 != 0);
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

        public List<Player> GetSamplePlayers()
        {
            List<Player> players = new() {};

            AddPlayers(players, BasePositionConstants.Quarterback, 40, 22, 0.25);
            AddPlayers(players, BasePositionConstants.RunningBack, 90, 16, 0.25);
            AddPlayers(players, BasePositionConstants.WideReceiver, 70, 14, 0.2);
            AddPlayers(players, BasePositionConstants.TightEnd, 40, 11, 0.15);


            AddPlayers(players, BasePositionConstants.Kicker, 30, 8, 0.1);
            AddPlayers(players, BasePositionConstants.Punter, 30, 6, 0.1);
            AddPlayers(players, BasePositionConstants.Coach, 30, 5, 0.1);

            AddPlayers(players, BasePositionConstants.TeamQuarterback, 30, 10, 0.1);
            AddPlayers(players, BasePositionConstants.TeamDefense, 30, 8, 0.1);

            AddPlayers(players, BasePositionConstants.DefensiveTackle, 40, 8, 0.15);
            AddPlayers(players, BasePositionConstants.DefensiveEnd, 40, 9, 0.15);
            AddPlayers(players, BasePositionConstants.Linebacker, 40, 10, 0.15);
            AddPlayers(players, BasePositionConstants.Cornerback, 40, 9, 0.15);
            AddPlayers(players, BasePositionConstants.Safety, 40, 8, 0.15);

            return players;
        }

        public List<Player> AddPlayers(List<Player> players, string position, int number, double topPoints, double decrement)
        {
            double points = topPoints;
            
            for (int i = 0; i < number; i++)
            {
                players.Add(new Player() { Position = position, WeeklyPoints = Math.Round(points,2)});
                points -= decrement;
            }

            return players;
        }

        public Rules GetSampleRules()
        {
            Positions positions = new()
            {
                Quarterbacks = new int[] { 1, 3 },
                RunningBacks = new int[] { 2, 8 },
                WideReceivers = new int[] { 2, 8 },
                TightEnds = new int[] { 1, 3 },

                Kickers = new int[] { 1, 2 },
                Punters = new int[] { 1, 2 },
                Coaches = new int[] { 1, 2 },

                TeamQuarterbacks = new int[] { 1, 3 },
                TeamDefenses = new int[] { 1, 3 },

                DefensiveTackles = new int[] { 1, 3 },
                DefensiveEnds = new int[] { 1, 3 },
                Linebackers = new int[] { 1, 3 },
                Cornerbacks = new int[] { 1, 3 },
                Safeties = new int[] { 1, 3 },

                FLEX = 1,
                OffensivePlayerUtilities = 1,
                BacksAndReceivers = 1,
                ReceiversAndEnds = 1,

                DefensiveLinemen = 1,
                DefensiveBacks = 1,
                DefensivePlayerUtilities = 1,

                Bench = 7,
                InjuredReserve = 0
            };

            Size size = new()
            {
                Teams = 10,
                PlayoffTeams = 4
            };

            Rules rules = new()
            { 
                Positions = positions,
                Size = size
            };

            return rules;
        }

    }
}
