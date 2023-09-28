using Fantasy.Presentation.Data.Exceptions;
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;
using TestContext = Bunit.TestContext;
using Fantasy.Presentation.Data.State;

namespace Fantasy.Presentation.Tests
{
    internal class ContextHelper : Bunit.TestContext
    {

        public Mock<IApiCallService> GetMockApiService()
        {
            Mock<IApiCallService> mockService = new();
            return mockService;
        }

        public Mock<HttpMessageHandler> GetMockHandler()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            return mockHandler;
        }
        

        public RegisteredServices GetServiceObject()
        {
            return new RegisteredServices();
        }

        public Bunit.TestContext GetTestContextWithServices(RegisteredServices services)
        {

            TestContext testContext = new(); 
            testContext.Services.AddSingleton(services.MockApiCallService.Object);
            testContext.Services.AddSingleton(services.UserData);
            return testContext;
        }

        public UserData GetUserData()
        {
            UserData userData = new UserData();
            return userData;
        }

        public Mock<IApiCallService> SetupMockApiService(Mock<IApiCallService> mockApiService, Endpoint endpoint, ReturnType returnType)
        {
            if (endpoint == Endpoint.editProjections)
            {
                List<PlayerViewModel> players = new();
                mockApiService.Setup(service => service.EditProjections(It.IsAny<EditProjectionsRequestObject>())).ReturnsAsync(players);
            }
            else if (endpoint == Endpoint.espnPlayers)
            {
                List<PlayerESPNViewModel> players = new();
                mockApiService.Setup(service => service.EspnPlayers(It.IsAny<EspnPlayersRequestObject>())).ReturnsAsync(players);
            }
            else if (endpoint == Endpoint.espnRules)
            {
                if (returnType == ReturnType.Default)
                {
                    RulesESPNViewModel rules = new();
                    mockApiService.Setup(service => service.EspnRules(It.IsAny<EspnRulesRequestObject>())).ReturnsAsync(rules);
                }
                else if (returnType == ReturnType.LeagueNotFound)
                {
                    mockApiService.Setup(service => service.EspnRules(It.IsAny<EspnRulesRequestObject>())).Throws<LeagueNotFoundException>();
                }
                else if (returnType == ReturnType.LeagueNotAccessible)
                {
                    mockApiService.Setup(service => service.EspnRules(It.IsAny<EspnRulesRequestObject>())).Throws<LeagueNotAccessibleException>();
                }
            }
            else if (endpoint == Endpoint.leagueRules)
            {
                RulesViewModel rules = new();
                mockApiService.Setup(service => service.LeagueRules(It.IsAny<LeagueRulesRequestObject>())).ReturnsAsync(rules);
            }
            else if (endpoint == Endpoint.playerProjections)
            {
                List<PlayerViewModel> players = new();
                mockApiService.Setup(service => service.PlayerProjections(It.IsAny<PlayerProjectionsRequestObject>())).ReturnsAsync(players);
            }
            else if (endpoint == Endpoint.validRules)
            {
                if (returnType == ReturnType.Default)
                {
                    RuleValidityViewModel ruleValidity = new() { IsValid = true};
                    mockApiService.Setup(service => service.ValidRules(It.IsAny<ValidRulesRequestObject>())).ReturnsAsync(ruleValidity);
                }
                else if (returnType == ReturnType.LeagueNotSupported)
                {
                    RuleValidityViewModel ruleValidity = new() { IsValid = false };
                    mockApiService.Setup(service => service.ValidRules(It.IsAny<ValidRulesRequestObject>())).ReturnsAsync(ruleValidity);
                }
            }
            return mockApiService;
        }

        public Mock<HttpMessageHandler> SetupMockHandler(Mock<HttpMessageHandler> mockHandler, Endpoint endpoint, HttpMethod requestMethodType, HttpStatusCode responseStatusCode, string returnedJson = "success")
        {
            var content = new StringContent(returnedJson);
            mockHandler.Protected().Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.Is<HttpRequestMessage>(request => request.Method == requestMethodType && request.RequestUri != null && request.RequestUri.ToString().Contains(endpoint.ToString())), ItExpr.IsAny<CancellationToken>()).ReturnsAsync(new HttpResponseMessage() { StatusCode = responseStatusCode, Content = content }).Verifiable();
            return mockHandler;
        }

        public enum Endpoint
        {
            editProjections,
            espnPlayers,
            espnRules,
            leagueRules,
            playerProjections,
            validRules
        }

        public enum ReturnType
        {
            Default,
            LeagueNotAccessible,
            LeagueNotFound,
            LeagueNotSupported
        }

        public class RegisteredServices
        {
            public Mock<IApiCallService> MockApiCallService { get; set; } = new();
            public UserData UserData { get; set; } = new();

        }
    }
}
