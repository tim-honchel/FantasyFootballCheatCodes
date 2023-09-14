using Fantasy.Presentation.Data.Exceptions;
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Services.Interfaces;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using TestContext = Bunit.TestContext;

namespace Fantasy.Presentation.Tests
{
    internal class ContextHelper : Bunit.TestContext
    {

        public Mock<IApiCallService> GetMockApiService()
        {
            Mock<IApiCallService> mockService = new();
            return mockService;
        }

        public Bunit.TestContext GetTestContextWithApiService(Mock<IApiCallService> service)
        {

            TestContext testContext = new(); 
            testContext.Services.AddSingleton(service.Object); 
            return testContext;
        }

        public Mock<IApiCallService> SetupMockApiService(Mock<IApiCallService> mockApiService, Endpoint endpoint, ReturnType returnType)
        {
            if (endpoint == Endpoint.espnPlayers)
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
                mockApiService.Setup(service => service.LeagueRules(It.IsAny<LeagueRulesRequestObject>())).Returns(rules);
            }
            else if (endpoint == Endpoint.playerProjections)
            {
                List<PlayerViewModel> players = new();
                mockApiService.Setup(service => service.PlayerProjections(It.IsAny<PlayerProjectionsRequestObject>())).Returns(players);
            }
            else if (endpoint == Endpoint.validRules)
            {
                if (returnType == ReturnType.Default)
                {
                    RuleValidityViewModel ruleValidity = new() { IsValid = true};
                    mockApiService.Setup(service => service.ValidRules(It.IsAny<ValidRulesRequestObject>())).Returns(ruleValidity);
                }
                else if (returnType == ReturnType.LeagueNotSupported)
                {
                    RuleValidityViewModel ruleValidity = new() { IsValid = false };
                    mockApiService.Setup(service => service.ValidRules(It.IsAny<ValidRulesRequestObject>())).Returns(ruleValidity);
                }
            }
            return mockApiService;
        }

        public enum Endpoint
        {
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
    }
}
