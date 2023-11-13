using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Fantasy.Logic.Services;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class ValidRulesLogicTests
    {
        public static IConfiguration _configuration = ConfigurationHelper.GetIConfigurationRoot();
        ValidRulesLogic _logic = new(_configuration);

        [Test]
        public void Get_Returns_SuccessTrue_GivenValidRulesAndPlayers()
        {
            List<Player> players = TestService.GetValidPlayers();
            Rules rules = TestService.GetValidRules();
            ValidRulesRequest request = new()
            {
                Players = players,
                Rules = rules
            };
            
            ValidRulesResponse response = _logic.Get(request);
            
            Assert.That(response.Success, Is.True);
        }

        [Test]
        public void Get_Returns_SuccessFalse_GivenNullRules()
        {
            List<Player> players = TestService.GetValidPlayers();
            Rules rules = new() {};
            ValidRulesRequest request = new()
            {
                Rules= rules,
                Players = players
            };

            ValidRulesResponse response = _logic.Get(request);

            Assert.That(response.Success, Is.False);
        }

        [Test]
        public void Get_Returns_SuccessFalse_GivenNullPlayers()
        {
            List<Player> players = new();
            Rules rules = TestService.GetValidRules();
            ValidRulesRequest request = new()
            {
                Rules = rules,
                Players = players
            };

            ValidRulesResponse response = _logic.Get(request);

            Assert.That(response.Success, Is.False);
        }

        [Test]
        public void Get_Returns_SuccessFalse_GivenInvalidRules()
        {
            List<Player> players = TestService.GetValidPlayers();
            Rules rules = TestService.GetValidRules();
            rules.Status.DraftComplete = true;
            ValidRulesRequest request = new()
            {
                Players = players,
                Rules = rules
            };

            ValidRulesResponse response = _logic.Get(request);

            Assert.That(response.Success, Is.False);
        }

        [Test]
        public void Get_Returns_SuccessFalse_GivenInvalidPlayers()
        {
            List<Player> players = TestService.GetValidPlayers();
            players.RemoveAll(p => p.Position == BasePositionConstants.Quarterback);
            Rules rules = TestService.GetValidRules();
            ValidRulesRequest request = new()
            {
                Players = players,
                Rules = rules
            };

            ValidRulesResponse response = _logic.Get(request);

            Assert.That(response.Success, Is.False);
        }


    }
}
