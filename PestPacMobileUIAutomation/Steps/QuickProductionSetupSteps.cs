using NUnit.Framework;
using OpenQA.Selenium;
using RealGreen.MobileAutomation.Model;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WorkWave.TA.TestEngine;

namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public class QuickProductionSetupSteps
    {
        RouteListView routeList = new RouteListView();


        [Given(@"Click on More")]
        public void GivenClickOnMore()
        {
            routeList.ClickOnMore();
        }
        
        [When(@"Click on Quick Production")]
        public void WhenClickOnQuickProduction()
        {
            routeList.ClickOnQuickProduction();
        }
        
        [Then(@"Enable and Disable Options Are Displayed")]
        public void ThenEnableAndDisableOptionsAreDisplayed()
        {
            Assert.True(routeList.EnableQuickProductionVisible() && routeList.DisableQuickProductionVisible());
        }
    }
}
