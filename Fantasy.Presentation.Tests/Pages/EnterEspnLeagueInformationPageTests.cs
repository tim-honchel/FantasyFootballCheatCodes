using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Pages;
using Fantasy.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Moq;
using System;
using TestContext = Bunit.TestContext;

namespace Fantasy.Presentation.Tests.Pages
{
    [TestFixture]
    public class EnterEspnLeagueInformationPageTests : TestContext
    {
        ContextHelper _helper = new();

        [Test]
        public void Page_Renders_CorrectHeaderText()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string header = component.Find("h1").TextContent;

            Assert.AreEqual(header, "Enter League Information");
        }
        [Test]
        public void Page_Renders_LeagueIDInput()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string leagueID = component.Find("input[id =\"leagueID\"]").TextContent;

            Assert.IsNotNull(leagueID);
        }
        [Test]
        public void Page_Renders_ESPN2CookieInput()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string espn_s2 = component.Find("textarea[id =\"espn_s2\"]").TextContent;

            Assert.IsNotNull(espn_s2);
        }
        [Test]
        public void Page_Renders_SWIDCookieInput()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string swid = component.Find("input[id =\"swid\"]").TextContent;

            Assert.IsNotNull(swid);
        }
        [Test]
        public void ButtonClick_Calls_EspnRulesEndpoint()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            service.Verify(service => service.EspnRules(It.IsAny<EspnRulesRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_LeagueRulesEndpoint()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            service.Verify(service => service.LeagueRules(It.IsAny<LeagueRulesRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_EspnPlayersEndpoint()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            service.Verify(service => service.EspnPlayers(It.IsAny<EspnPlayersRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_PlayerProjectionsEndpoint()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            service.Verify(service => service.PlayerProjections(It.IsAny<PlayerProjectionsRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_ValidRulesEndpoint()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            service.Verify(service => service.ValidRules(It.IsAny<ValidRulesRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueNotFoundPage_Given_CustomException()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.LeagueNotFound);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "leaguenotfound");
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueNotAccessiblePage_Given_CustomException()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.LeagueNotAccessible);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "leaguenotaccessible");
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueNotSupportedPage_Given_InvalidRuleResponse()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.LeagueNotSupported);
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "leaguenotsupported");
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueRulesAndProjections_Given_SuccesssfulAPIResponses()
        {
            Mock<IApiCallService> service = _helper.GetMockApiService();
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            service = _helper.SetupMockApiService(service, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            TestContext testContext = _helper.GetTestContextWithApiService(service);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "leaguerulesandprojections");
        }
    }
}
