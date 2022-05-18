using NUnit.Framework;
using OpenQA.Selenium;
using RealGreen.MobileAutomation.Model;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

//using WorkWave.PestPac.Mobile.Model;

namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class OdometerSteps
    {
       
        

       

        OdometerPageView OdometerPage = new OdometerPageView();

        [Given(@"Route List")]
        public void GivenRouteList()
        {
            Console.Write("Routing List");
            //ScenarioContext.Current.Pending();
        }

        [When(@"Click on Menu Button")]
        public void WhenClickOnMenuButton()
        {
            Thread.Sleep(10000);
            OdometerPage.ClickMenu();
        }

        [Then(@"Menu Is displayed")]
        public void ThenMenuIsDisplayed()
        {
            OdometerPage.VerifyOdometerSubMenu();
            // Console.Write("Menu List");
            //ScenarioContext.Current.Pending();
        }

        [When(@"Clik on Odometer Option")]
        public void WhenClikOnOdometerOption()
        {
            OdometerPage.ClickOdometerSub_Menu();
        }

        [Then(@"Odometer Pop Up is displayed")]
        public void ThenOdometerPopUpIsDisplayed()
        {
            OdometerPage.OdometerTextBoxVisible();
            //ScenarioContext.Current.Pending();
        }

    }
}
