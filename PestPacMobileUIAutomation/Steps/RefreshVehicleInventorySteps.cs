using NUnit.Framework;
using OpenQA.Selenium;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Activities.Expressions;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RealGreen.MobileAutomation.Model;




namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class RefreshVehicleInventorySteps
    {
        private SettingView settingsObj = new SettingView();
        private RouteListView routelistObj = new RouteListView();
        [When(@"Click on Refresh Vehicle Inventory")]
        public void WhenClickOnRefreshVehicleInventory()
        {
            settingsObj.clickOnElement(settingsObj.refreshVehicleInventoryListView);
        }
        
        [Then(@"Vehicle Inventory is Refreshed")]
        public void ThenVehicleInventoryIsRefreshed()
        {
            routelistObj.VerifyElementLoaded(2,routelistObj.loadingLayout);
        }
    }
}
