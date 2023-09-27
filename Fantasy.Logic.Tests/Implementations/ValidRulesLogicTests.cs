
using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
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
            Player player = new();
            List<Player> players = new();
            players.Add(player);
            ValidRulesRequest request = new()
            {
                Players = players
            };
            
            ValidRulesResponse response = _logic.Get(request);
            
            Assert.That(response.Success, Is.True);
        }

        [Test]
        public void Get_Returns_SuccessFalse_GivenNullRules()
        {
            Settings? settings = null;
            Rules rules = new()
            {
                Settings = settings
            };
            ValidRulesRequest request = new()
            {
                Rules= rules
            };

            ValidRulesResponse response = _logic.Get(request);

            Assert.That(response.Success, Is.False);
        }

        [Test]
        public void Get_Returns_SuccessFalse_GivenNullPlayers()
        {
            ValidRulesRequest request = new();

            ValidRulesResponse response = _logic.Get(request);

            Assert.That(response.Success, Is.False);
        }

        [Test]
        public void Get_Returns_ValidationErrors_GivenInvalidRules()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_Returns_ValidationErrors_GivenInvalidPlayers()
        {
            Assert.Ignore();
        }
    }
}
