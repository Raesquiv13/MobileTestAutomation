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
    public sealed class RescheduleSteps
    {
        private RouteListView routelistObj = new RouteListView();
        private ScheduleView scheduleObj = new ScheduleView();
        private RescheduleView rescheduleObj = new RescheduleView();
        private SettingView settingsObj = new SettingView();
        private NotServiceableReasonsView notServObj = new NotServiceableReasonsView();
        private ProductionView productionObj = new ProductionView();
        private StopView stopObj = new StopView();
        private RouteSetupView routesetObj = new RouteSetupView();
        
        
        RescheduleView ReschedulePage = new RescheduleView();

       
        

        [Given(@"Home Displayed")]
        public void GivenHomeDisplayed()
        {
            while (routelistObj.VerifyElementLoaded(60,routelistObj.DepotViewGroup))
            {
                break;
            }
            Console.Write("Home Page displayed");
        }

        [When(@"Click on Stop")]
        public void WhenClickOnStop()
        {
            

                routelistObj.ClickOnStop();
              
            
        }
        
        [When(@"Click on Confirm Buuton")]
        public void WhenClickOnConfirmBuuton()
        {
            stopObj.clickOnConfirm();
        }
        
        [When(@"Back to Route from Production")]
        public void WhenBackToRouteFromProduction()
        {
            productionObj.clickOnBack();
        }

        [When(@"Route list home is displayed")]
        public void WhenRouteListHomeIsDisplayed()
        {
            routelistObj.VerifyPageLoaded(5000);
        }
        
        [Then(@"Confirm Button Is Displayed")]
        public void ThenConfirmButtonIsDisplayed()
        {
            stopObj.VerifyPageLoaded(2000);
            RealGreenMobileSupport.GoBackPhone();
        }
        


        [Then(@"Click on No Start Time")]
        public void ThenClickOnNoStartTime()
        {
            productionObj.VerifyPageLoaded(5000);
            
            productionObj.clickOnNoStart();
        }
        
        [Then(@"Click on Arrow")]
        public void ThenClickOnArrow()
        {
            productionObj.clickOnArrow();
            
        }
        
        [Then(@"Click on Reschedule Menu")]
        public void ThenClickOnRescheduleMenu()
        {
            //productionObj.VerifyRescheduleMenuLoaded(5000);


                productionObj.clickOnReschedule();
             
            
        }
        
        [Then(@"Add New Date")]
        public void ThenAddNewDate()
        {
            scheduleObj.clickOnScheduleDate();
            scheduleObj.VerifyMonthViewLoaded(4000);
            scheduleObj.EnterNewDate();
        }
        
        [Then(@"Mark promise")]
        public void ThenMarkPromise()
        {
            scheduleObj.enablePromise();
        }
        
        [Then(@"Click on Back from Production")]
        public void ThenClickOnBackFromProduction()
        {
            scheduleObj.VerifyBackLoaded(5000);
            scheduleObj.clickOnBack();
        }
        
        [Then(@"Enable Not Serviceable Reason")]
        public void ThenEnableNotServiceableReason()
        {
            notServObj.enableBrokenEquipment();
        }
        
        [Then(@"Click On Back from Not Serviceable")]
        public void ThenClickOnBackFromNotServiceable()
        {
            notServObj.clickOnBack();
        }
        
        [Then(@"Service is Not Present")]
        public void ThenServiceIsNotPresent()
        {
            bool x = routelistObj.VerifyExistingJob(20,routelistObj.VickiJobViewGroup) ;
            if (x == false)
            {
                Console.Write("Element not Found");
            }
            else
            {
                Console.Write("Element Found");
            }
                
        }
        
        [When(@"Click on Three Dots")]
        public void ThenClickOnThreeDots()
        {
            routelistObj.ClickOnThreeDots();
        }

        [When(@"Click on Setup Route")]
        public void WhenClickOnSetupRoute()
        {
            settingsObj.clickOnSetupRoute();
        }
        
        [Then(@"Add New Date on Setup Route")]
        public void ThenAddNewDateOnSetupRoute()
        {
            routesetObj.typeNewDate("02-15-2022");
        }
        
        [Then(@"Back from Setup Route")]
        public void ThenBackFromSetupRoute()
        {
            routesetObj.clickOnBack();
        }
        
        [Then(@"Rescheduled Service is present")]
        public void ThenRescheduledServiceIsPresent()
        {
            routelistObj.VerifyExistingJob(5000,routelistObj.VickiJobViewGroup);
        }
    }
}
