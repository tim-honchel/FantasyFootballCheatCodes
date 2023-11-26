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
using Microsoft.Extensions.Configuration;

namespace Fantasy.Presentation.Tests
{
    internal class ContextHelper : Bunit.TestContext
    {

        public Mock<IApiCallService> GetMockApiService()
        {
            Mock<IApiCallService> mockService = new();
            return mockService;
        }

        public Mock<IStrategyService> GetMockStrategyService(bool success, UserData userData, string errorMessage = "")
        {
            Mock<IStrategyService> mockStrategyService = new();

            mockStrategyService.Setup(m => m.EvaluatePlayers()).ReturnsAsync(success);

            if (success = false && !string.IsNullOrEmpty(errorMessage))
            {
                userData.ErrorMessages.Add(errorMessage);
            }

            return mockStrategyService;
        }

        public Mock<HttpMessageHandler> GetMockHandler()
        {
            var mockHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            return mockHandler;
        }
        
        public List<PlayerViewModel> GetMockPlayers()
        {
            PlayerViewModel mockPlayer = new();
            List<PlayerViewModel> mockPlayers = new();
            mockPlayers.Add(mockPlayer);
            return mockPlayers;
        }

        public RegisteredServices GetServiceObject()
        {
            return new RegisteredServices();
        }

        public Bunit.TestContext GetTestContextWithServices(RegisteredServices services)
        {

            TestContext testContext = new(); 
            testContext.Services.AddSingleton(services.MockApiCallService.Object);
            testContext.Services.AddSingleton(services.MockStrategyService.Object);
            testContext.Services.AddSingleton(services.UserData);
            testContext.Services.AddSingleton(services.Configuration);
            return testContext;
        }

        public UserData GetUserData()
        {
            UserData userData = new UserData();
            return userData;
        }

        public Mock<IApiCallService> SetupMockApiService(Mock<IApiCallService> mockApiService, Endpoint endpoint, ReturnType returnType)
        {
            if (endpoint == Endpoint.costAnalysis)
            {
                CostAnalysisViewModel analysis = new();
                mockApiService.Setup(service => service.CostAnalysis(It.IsAny<CostAnalysisRequestObject>())).ReturnsAsync(analysis);
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
            else if (endpoint == Endpoint.expectedValue)
            {
                List<PlayerViewModel> players = new();
                mockApiService.Setup(service => service.ExpectedValue(It.IsAny<ExpectedValueRequestObject>())).ReturnsAsync(players);
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
            else if (endpoint == Endpoint.pointAverages)
            {
                PointAveragesViewModel averages = new();
                mockApiService.Setup(service => service.PointAverages(It.IsAny<PointAveragesRequestObject>())).ReturnsAsync(averages);
            }
            else if (endpoint == Endpoint.relativePoints)
            {
                List<PlayerViewModel> players = new();
                mockApiService.Setup(service => service.RelativePoints(It.IsAny<RelativePointsRequestObject>())).ReturnsAsync(players);
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
            costAnalysis,
            espnPlayers,
            espnRules,
            expectedValue,
            leagueRules,
            playerProjections,
            pointAverages,
            relativePoints,
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
            public Mock<IStrategyService> MockStrategyService { get; set; } = new();
            public UserData UserData { get; set; } = new();

            public IConfiguration Configuration { get; set; } = ConfigurationHelper.GetIConfigurationRoot();

 

        }
    }
}
