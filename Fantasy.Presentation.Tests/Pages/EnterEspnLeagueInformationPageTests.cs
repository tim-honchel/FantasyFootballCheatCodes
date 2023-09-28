using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.State;
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
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string header = component.Find("h1").TextContent;

            Assert.AreEqual(header, "Enter League Information");
        }
        [Test]
        public void Page_Renders_LeagueIDInput()
        {
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string leagueID = component.Find("input[id =\"leagueID\"]").TextContent;

            Assert.IsNotNull(leagueID);
        }
        [Test]
        public void Page_Renders_ESPN2CookieInput()
        {
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string espn_s2 = component.Find("textarea[id =\"espn_s2\"]").TextContent;

            Assert.IsNotNull(espn_s2);
        }
        [Test]
        public void Page_Renders_SWIDCookieInput()
        {
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            string swid = component.Find("input[id =\"swid\"]").TextContent;

            Assert.IsNotNull(swid);
        }
        [Test]
        public void ButtonClick_Calls_EspnRulesEndpoint()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            
            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            apiCall.Verify(service => service.EspnRules(It.IsAny<EspnRulesRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_LeagueRulesEndpoint()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            apiCall.Verify(service => service.LeagueRules(It.IsAny<LeagueRulesRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_EspnPlayersEndpoint()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            apiCall.Verify(service => service.EspnPlayers(It.IsAny<EspnPlayersRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_PlayerProjectionsEndpoint()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            apiCall.Verify(service => service.PlayerProjections(It.IsAny<PlayerProjectionsRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_Calls_ValidRulesEndpoint()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            apiCall.Verify(service => service.ValidRules(It.IsAny<ValidRulesRequestObject>()), Times.Once);
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueNotFoundPage_Given_CustomException()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.LeagueNotFound);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "error/leaguenotfound");
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueNotAccessiblePage_Given_CustomException()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.LeagueNotAccessible);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "error/leaguenotaccessible");
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueNotSupportedPage_Given_InvalidRuleResponse()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.LeagueNotSupported);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "error/leaguenotsupported");
        }
        [Test]
        public void ButtonClick_NavigatesTo_LeagueRulesAndProjections_Given_SuccesssfulAPIResponses()
        {
            Mock<IApiCallService> apiCall = _helper.GetMockApiService();
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.leagueRules, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.espnPlayers, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.playerProjections, ContextHelper.ReturnType.Default);
            apiCall = _helper.SetupMockApiService(apiCall, ContextHelper.Endpoint.validRules, ContextHelper.ReturnType.Default);
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = apiCall;
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();

            IRenderedComponent<EnterEspnLeagueInformation> component = testContext.RenderComponent<EnterEspnLeagueInformation>();

            component.Find("form").Submit();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "leaguerulesandprojections");
        }
    }
}
