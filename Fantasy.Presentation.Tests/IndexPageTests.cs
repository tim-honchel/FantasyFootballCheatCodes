﻿using Bunit;
using Fantasy.Presentation.Pages;
using Microsoft.AspNetCore.Components;
using System;
using Index = Fantasy.Presentation.Pages.Index;
using TestContext = Bunit.TestContext;

namespace Fantasy.Presentation.Tests
{
    [TestFixture]
    public class IndexPageTests : Bunit.TestContext
    {
        [Test]
        public void Page_Renders_CorrectHeaderText()
        {
            TestContext testContext = new();
            IRenderedComponent<Index> component = testContext.RenderComponent<Index>();

            string header = component.Find("h1").TextContent;

            Assert.AreEqual(header, "Fantasy Football Cheat Codes");
        }

        [Test]
        public void EspnButton_Click_NavigatesTo_EnterLeagueInformationPage()
        {
            TestContext testContext = new();
            NavigationManager navigation = testContext.Services.GetRequiredService<NavigationManager>();
            IRenderedComponent<Index> component = testContext.RenderComponent<Index>();

            component.Find("button[id =\"espn\"]").Click();

            Assert.AreEqual(navigation.Uri, navigation.BaseUri + "EnterLeagueInformation");
            
            
        }
    }
}
