
using Fantasy.Presentation.Data.RequestObjects;
using Fantasy.Presentation.Data.State;
using Fantasy.Presentation.Data.ViewModels;
using Fantasy.Presentation.Pages;
using Fantasy.Presentation.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Moq;
using System;
using System.Collections.Generic;
using TestContext = Bunit.TestContext;

namespace Fantasy.Presentation.Tests.Pages
{
    [TestFixture]
    public class LeagueRulesAndProjectionsPageTests : Bunit.TestContext
    {
        ContextHelper _helper = new();

        [Test]
        public void Page_Renders_CorrectHeaderText()
        {
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<LeagueRulesAndProjections> component = testContext.RenderComponent<LeagueRulesAndProjections>();

            string header = component.Find("h1").TextContent;

            Assert.AreEqual(header, "League Rules And Projections");
        }

        [Test]
        public void Page_Renders_Rules()
        {
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = _helper.GetUserData();
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<LeagueRulesAndProjections> component = testContext.RenderComponent<LeagueRulesAndProjections>();

            string table = component.Find("table[id=\"positions\"]").TextContent;

            int rows = table.Split("\n").Length;
            Assert.That(rows, Is.GreaterThan(1));
        }

        [Test]
        public void Page_Renders_ListOfPlayers()
        {
            PlayerViewModel player = new();
            List<PlayerViewModel> players = new();
            players.Add(player);   
            UserData userData = _helper.GetUserData();
            userData.Players = players;
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = userData;
            TestContext testContext = _helper.GetTestContextWithServices(services);
            IRenderedComponent<LeagueRulesAndProjections> component = testContext.RenderComponent<LeagueRulesAndProjections>();

            string table = component.Find("table[id=\"players\"]").TextContent;

            int rows = table.Split("\n").Length;
            Assert.That(rows, Is.GreaterThan(5));
        }

        [Test]
        public void NextButton_Click_NavigatesTo_LoadingPage()
        {
            PlayerViewModel player = new();
            List<PlayerViewModel> players = new();
            players.Add(player);
            UserData userData = _helper.GetUserData();
            userData.Players = players;
            ContextHelper.RegisteredServices services = _helper.GetServiceObject();
            services.MockApiCallService = _helper.GetMockApiService();
            services.UserData = userData;
            TestContext testContext = _helper.GetTestContextWithServices(services);
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();
            IRenderedComponent<LeagueRulesAndProjections> component = testContext.RenderComponent<LeagueRulesAndProjections>();

            component.Find("button[id=\"next-page\"]").Click();

            string page = navigation.Uri.Substring(navigation.BaseUri.Length).ToLower();
            Assert.AreEqual(page, "loading");
        }

    }
}
