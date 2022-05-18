using NUnit.Framework;
using OpenQA.Selenium;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RealGreen.MobileAutomation.Model;


namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class RefreshParametersAndImagesSteps
    {
        private RouteListView routelistObj = new RouteListView();
        
        

      

        [When(@"Click on Refresh Parameters")]
        public void WhenClickOnRefreshParameters()
        {
            routelistObj.clickOnElement(routelistObj.refreshParametersTextBox);
        }

         
        [Then(@"Parameters are Refreshed")]
        public void ThenParametersAreRefreshed()
        {
            Thread.Sleep(4000);
            routelistObj.VerifyElementLoaded(5,routelistObj.statusTextView);
        }
        [When(@"Click on Refresh Images")]
        public void WhenClickOnRefreshImages()
        {
            routelistObj.clickOnElement(routelistObj.refreshImagesTextBox);
        }
        
        [Then(@"Images are Refreshed")]
        public void ThenImagesAreRefreshed()
        {
            routelistObj.VerifyElementLoaded(5, routelistObj.imageDownloadTextBox);
        }
    }
}
