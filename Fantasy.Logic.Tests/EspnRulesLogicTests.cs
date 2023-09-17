

using Fantasy.Logic.Implementations;
using Fantasy.Logic.Models;
using Fantasy.Logic.Requests;
using Fantasy.Logic.Responses;
using NUnit.Framework;

namespace Fantasy.Logic.Tests
{
    [TestFixture]
    public class EspnRulesLogicTests
    {
        EspnRulesLogic _logic = new();
        
        [Test]
        public async Task Get_Returns_ESPNRules_Given_ValidESPNStrings()
        {
            string leagueID = "1472201749";
            string espn_s2 = "espn_s2=AEBUl2qnSDad1uBMx5bD5kwRp1%2BuMGyUn%2FVHGkXh1VcOzucbIMKtogYveuIhohTtzhmgO2Yzq8gsvWWNIKcF%2FPIYrWR9F8JyAUShUCDChkqo0JziBOrnw5OxA4sGD4HfgCIJ61Iz%2FaAy7kwFHcP0qhVMWgHUXUcjIPI1qXxdQt3%2BIzqN619fPtE3M4Wzu8C%2BVoekS0%2FcPwv1v13OojdUCLIlghkcUUwf6Q6rCc31fxTki62QjiHFoTZ8YPOoF0HkSa8KspuIM6oAcA0e0IDYxhGj;";
            string swid = "SWID={5392B6D6-D775-475C-833C-5AEB107000B2};";
            EspnRulesRequest request = new()
            {
                LeagueID = leagueID,
                espn_s2 = espn_s2,
                swid = swid
            };

            EspnRulesResponse response = await _logic.Get(request);
           
            RulesESPN rules = response.Rules; 
            Assert.IsNotNull(rules);
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
