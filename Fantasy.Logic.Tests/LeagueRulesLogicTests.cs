using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using NUnit.Framework;

namespace Fantasy.Logic.Tests
{
    [TestFixture]
    public class LeagueRulesLogicTests
    {
        LeagueRulesLogic _logic = new();

        [Test]
        public void Get_Returns_Rules_Given_ESPNRules()
        {
            Dictionary<int, int> positionSlotCounts = new()
            {
                {0,1}, {1,0}, {2,2}, {3,0}, {4,2}, {5,0}, {6,1}, {7,0}, {8,0}, {9,0}, {10,0}, {11,0}, {12,0}, {13,0}, {14,0}, {15,0}, {16,1}, {17,1}, {18,0}, {19,0}, {20,7}, {21,1}, {22,0}, {23,1}, {24,0}
            };
            Dictionary<int, int> positionLimits = new()
            {
                {0,0}, {1,4}, {2,8}, {3,8}, {4,3}, {5,3}, {6,-1}, {7,-1}, {8,-1}, {9,-1}, {10,-1}, {11,-1}, {12,-1}, {13,-1}, {14,-1}, {15,-1}, {16,3}, {17,-1}
            };

            RulesESPN espnRules = new RulesESPN()
            {
                PositionLimits = positionLimits,
                PositionSlotCounts = positionSlotCounts,
            };

            LeagueRulesRequest request = new()
            {
                Provider = Provider.ESPN,
                EspnRules = espnRules
            };

            LeagueRulesResponse response = _logic.Get(request);

            Assert.IsNotNull(response.Rules);
        }

        [Test]
        public void Get_Throws_CorrectRules_Given_ESPNRules()
        {
            Dictionary<int, int> positionSlotCounts = new()
            {
                {0,1}, {1,0}, {2,2}, {3,0}, {4,2}, {5,0}, {6,1}, {7,0}, {8,0}, {9,0}, {10,0}, {11,0}, {12,0}, {13,0}, {14,0}, {15,0}, {16,1}, {17,1}, {18,0}, {19,0}, {20,7}, {21,1}, {22,0}, {23,1}, {24,0}
            };
            Dictionary<int, int> positionLimits = new()
            {
                {0,0}, {1,4}, {2,8}, {3,8}, {4,3}, {5,3}, {6,-1}, {7,-1}, {8,-1}, {9,-1}, {10,-1}, {11,-1}, {12,-1}, {13,-1}, {14,-1}, {15,-1}, {16,3}, {17,-1}
            };

            RulesESPN espnRules = new RulesESPN()
            {
                AuctionBudget = 0,
                DraftComplete = false,
                DraftInProgress = false,
                DraftOrderType = "MANUAL",
                DraftType = "AUCTION",
                IsActive = true,
                IsTradingEnabled = false,
                KeeperCount = 0,
                LeagueID = 1,
                LeagueSubType = "NONE",
                MatchupPeriodLength = 1,
                MatchupPeriods = 14,
                PlayoffMatchupPeriodLength = 1,
                PlayoffSeedingRule = "POINTS",
                PlayoffTeams = 4,
                PositionLimits = positionLimits,
                PositionSlotCounts = positionSlotCounts,
                ScoringType = "H2H_POINTS",
                Season = 2023,
                Teams = 10
            };

            LeagueRulesRequest request = new()
            {
                Provider = Provider.ESPN,
                EspnRules = espnRules
            };

            LeagueRulesResponse response = _logic.Get(request);

            Assert.That(espnRules.LeagueID == response.Rules.LeagueID);
            Assert.That(espnRules.Teams == response.Rules.Size.Teams);
            Assert.That(espnRules.DraftComplete == response.Rules.Status.DraftComplete);
            Assert.That(espnRules.IsTradingEnabled == response.Rules.Settings.IsTradingEnabled);
            Assert.That(espnRules.PositionSlotCounts[0] == response.Rules.Positions.Quarterbacks[0]);
        }
    

        [Test]
        public void Get_Throws_CustomException_Given_InvalidESPNRules()
        {
            Assert.Ignore();
        }
    }
}
