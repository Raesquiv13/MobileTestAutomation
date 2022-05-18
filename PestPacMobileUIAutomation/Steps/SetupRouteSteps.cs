using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RealGreen.MobileAutomation.Model;




namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public class SetupRouteSteps
    {

        private RouteListView routelistObj = new RouteListView();
        private RouteSetupView routesetObj = new RouteSetupView();
        private MapView mapObj = new MapView();
        private QuickProductionView quickProdObj = new QuickProductionView();

        [When(@"Enable Auto Navigate")]
        public void WhenEnableAutoNavigate()
        {
            routesetObj.enableSwitch(routesetObj.autoNavigateSwitch);
        }

        [When(@"Click on Back from Setup Route")]
        public void WhenClickOnBackFromSetupRoute()
        {
            RealGreenMobileSupport.GoBackPhone();
        }


               
        [Then(@"Maps is opened")]
        public void ThenMapsIsOpened()
        {
            Assert.IsTrue(mapObj.VerifyPageLoaded(5000));
            

        }
        [When(@"Deactivate Auto Navigate")]
        public void WhenDeactivateAutoNavigate()
        {
            routesetObj.disableSwitch(routesetObj.autoNavigateSwitch);
            routesetObj.disableSwitch(routesetObj.doQuickProductionSwitch);
            routesetObj.disableSwitch(routesetObj.AutoRefreshRouteSwitch);
        }
        [When(@"Deactivate Auto Refresh Route")]
        public void WhenDeactivateAutoRefreshRoute()
        {
            routesetObj.disableSwitch(routesetObj.AutoRefreshRouteSwitch);
        }

        
        [Then(@"Route List does not update automatically")]
        public void ThenRouteListDoesNotUpdateAutomatically()
        {
            routelistObj.VerifyElementNLoaded(10,routelistObj.loadingLayout);
        }

        [When(@"Activate Quick Production")]
        public void WhenActivateQuickProduction()
        {
            routesetObj.enableSwitch(routesetObj.doQuickProductionSwitch);
            routesetObj.disableSwitch(routesetObj.AutoRefreshRouteSwitch);
            routesetObj.disableSwitch(routesetObj.autoNavigateSwitch);

        }
        [When(@"Deactivate Quick Production")]
        public void WhenDeactivateQuickProduction()
        {
            routesetObj.disableSwitch(routesetObj.doQuickProductionSwitch);
            routesetObj.disableSwitch(routesetObj.AutoRefreshRouteSwitch);
        }

        


        [Then(@"Interface Quick Production Mode is Displayed")]
        public void ThenInterfaceQuickProductionModeIsDisplayed()
        {
            quickProdObj.VerifyElementLoaded(5000,quickProdObj.startButton);
            quickProdObj.ClickOnButton(quickProdObj.closeButton);
        }
        


        [Then(@"Activate Do Not Auto Advance")]
        public void ThenActivateDoNotAutoAdvance()
        {
            routesetObj.enableSwitch(routesetObj.doNotAutoAdvanceDateSwitch);
        }
        
        [Then(@"Date is not changed")]
        public void ThenDateIsNotChanged()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Activate Show Distance and Direction to Stop")]
        public void ThenActivateShowDistanceAndDirectionToStop()
        {
            routesetObj.enableSwitch(routesetObj.showDateDistanceSwitch);
        }
        
        [Then(@"Routes have Distance and Directions")]
        public void ThenRoutesHaveDistanceAndDirections()
        {
            ScenarioContext.Current.Pending();
        }
        [When(@"Click on Route Setup Three Dots")]
        public void WhenClickOnRouteSetupThreeDots()
        {
            routesetObj.clickOnThreedoots();
        }
        [When(@"Click on Delete Data Base")]
        public void WhenClickOnDeleteDataBase()
        {
            routesetObj.clickOnDeleteDatabase();
        }

        [Then(@"Data Base is Deleted")]
        public void ThenDataBaseIsDeleted()
        {
            routesetObj.VerifyProgressWheelLoaded(10);
            routesetObj.VerifyNoProgressWheelLoaded(60);

            routesetObj.enableSwitch(routesetObj.AutoRefreshRouteSwitch);
            RealGreenMobileSupport.GoBackPhone();
        }
        [When(@"Enable AutoRefresh")]
        public void WhenEnableAutoRefresh()
        {
            routesetObj.enableSwitch(routesetObj.AutoRefreshRouteSwitch);
        }
                
        [Then(@"Route is refresh")]
        public void ThenRouteIsRefresh()
        {
            routelistObj.VerifyExistingJob(3,routelistObj.loadingLayout);
        }


    }
}
