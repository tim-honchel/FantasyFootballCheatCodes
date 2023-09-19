using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;

namespace Fantasy.Logic.Tests.Implementations
{
    [TestFixture]
    public class EspnPlayersLogicTests
    {
        public static IConfiguration _configuration = ConfigurationHelper.GetIConfigurationRoot();
        EspnPlayersLogic _logic = new EspnPlayersLogic(_configuration);

        [Test]
        public async Task Get_Returns_ListOfESPNPlayers_Given_ESPNStrings()
        {
            string leagueID = "1472201749";
            string espn_s2 = "espn_s2=AEBUl2qnSDad1uBMx5bD5kwRp1%2BuMGyUn%2FVHGkXh1VcOzucbIMKtogYveuIhohTtzhmgO2Yzq8gsvWWNIKcF%2FPIYrWR9F8JyAUShUCDChkqo0JziBOrnw5OxA4sGD4HfgCIJ61Iz%2FaAy7kwFHcP0qhVMWgHUXUcjIPI1qXxdQt3%2BIzqN619fPtE3M4Wzu8C%2BVoekS0%2FcPwv1v13OojdUCLIlghkcUUwf6Q6rCc31fxTki62QjiHFoTZ8YPOoF0HkSa8KspuIM6oAcA0e0IDYxhGj;";
            string swid = "SWID={5392B6D6-D775-475C-833C-5AEB107000B2};";

            Size size = new()
            {
                Teams = 10
            };
            Positions positions = new()
            {
                Quarterbacks = new int[] { 1, 3 },
                RunningBacks = new int[] { 2, 8 },
                WideReceivers = new int[] { 2, 8 },
                TightEnds = new int[] { 1, 3 },
                FLEX = 1,
                TeamDefenses = new int[] { 1, 3 },
                Kickers = new int[] { 1, 3 },
                Bench = 7
            };
            Rules rules = new()
            {
                Size = size,
                Positions = positions
            };

            EspnPlayersRequest request = new()
            {
                LeagueID = leagueID,
                espn_s2 = espn_s2,
                swid = swid,
                Rules = rules
            };

            EspnPlayersResponse response = await _logic.Get(request);

            List<PlayerESPN> players = response.Players;
            Assert.IsNotNull(players);
        }

        [Test]
        public void Get_Throws_CustomException_Given_InvalidESPNStrings()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_ThrowsCustomException_Given_PageNotFoundResponse()
        {
            Assert.Ignore();
        }

        [Test]
        public void Get_ThrowsCustomException_Given_UnauthorizedResponse()
        {
            Assert.Ignore();
        }
    }
}