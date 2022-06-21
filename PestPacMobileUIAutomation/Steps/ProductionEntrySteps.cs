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
    public class ProductionEntrySteps
    {
        RouteListView route = new RouteListView();
        JobListView joblist = new JobListView();

        [Given(@"Disable Quick Production")]
        public void GivenDisableQuickProduction()
        {
            route.ClickOnMore();
            route.ClickOnQuickProduction();
            route.DisableQuickProd();
            RealGreenMobileSupport.GoBackApp();
        }
        
        [When(@"Open and Start a Service")]
        public void WhenOpenAndStartAService()
        {
            joblist.ClickOnJob();
            joblist.ClickOnAcceptAndContinue();
        }
        
        [Then(@"Elements in Production Entry are Displayed")]
        public void ThenElementsInProductionEntryAreDisplayed()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
