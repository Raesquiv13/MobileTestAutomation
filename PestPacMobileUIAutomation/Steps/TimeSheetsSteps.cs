using NUnit.Framework;
using OpenQA.Selenium;
using RealGreen.MobileAutomation.Model;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class TimeSheetsSteps
    {
        private LoginPageView login = new LoginPageView();
        private TimeSheetsView timesheets = new TimeSheetsView();
        private RouteListView routeList = new RouteListView();


        [Given(@"User is logged in")]
        public void GivenUserIsLoggedIn()
        {
            login.RGLoginAttempt();
        }


        [When(@"User is on timesheets screen")]
        public void WhenUserIsOnTimesheetsScreen()
        {
            routeList.ClickOnTimeSheets();
            timesheets.TimeSheetsTitleVisible();
        }

        [When(@"User adds crew members")]
        public void WhenUserAddsCrewMembers()
        {
            timesheets.addOrRemoveCrewMembers(false);
        }


        [When(@"User adds crew members and clicks done")]
        public void WhenUserAddsCrewMembersAndClicksDone()
        {
            timesheets.addOrRemoveCrewMembers(true);
        }

        [When(@"User removes the Crew Members")]
        public void WhenUserRemovesTheCrewMembers()
        {
            timesheets.addOrRemoveCrewMembers(true);
        }


        [Then(@"System displayed the crew members selected")]
        public void ThenSystemDisplayedTheCrewMembersSelected()
        {
            Assert.True(timesheets.areCrewMemberSelected());
        }

        [Then(@"Crew members selected appears in the timesheets screen")]
        public void ThenCrewMembersSelectedAppearsInTheTimesheetsScreen()
        {
            Assert.True(timesheets.verifyCrewMembersAppearsTimesheetsScreen());
        }


        [Then(@"Crew members were removed from timesheets screen")]
        public void ThenCrewMembersWereRemovedFromTimesheetsScreen()
        {
            Assert.True(timesheets.verifyCrewMembersWereRemoveTimesheetsScreen());
        }



        [Given(@"Job List Screen")]
        public void GivenJobListScreen()
        {
            login.ClikOkButton();
            
        }
        
        [Given(@"Tap on Time Sheets")]
        public void GivenTapOnTimeSheets()
        {
            routeList.ClickOnTimeSheets();
            
        }
        
        [Given(@"Time Sheets Screen")]
        public void GivenTimeSheetsScreen()
        {
            Assert.True(timesheets.TimeSheetsTitleVisible());
        }
        
        [When(@"User is Not Clocked In")]
        public void WhenUserIsNotClockedIn()
        {
            Assert.AreEqual("Not Clocked In", timesheets.GetClocked());
        }
        
        [When(@"Tap on Clock In")]
        public void WhenTapOnClockIn()
        {
            timesheets.ClickOnClockIn();
        }
        
        [When(@"User is Clocked In")]
        public void WhenUserIsClockedIn()
        {
            string status = timesheets.GetClocked();

            if  (status== "Not Clocked In")
            {
                timesheets.ClickOnClockIn();
            }
           
        }
        
        [When(@"Tap on Clock Out")]
        public void WhenTapOnClockOut()
        {
            timesheets.ClickOnClockOut();
        }
        
        [Then(@"User is Clocked In")]
        public void ThenUserIsClockedIn()
        {
            Assert.True(timesheets.GetClocked().Contains("Clocked In"));
        }
        
        [Then(@"User is Not Clocked In")]
        public void ThenUserIsNotClockedIn()
        {
            Assert.True(timesheets.GetClocked().Contains("Not Clocked"));
        }
    }
}
