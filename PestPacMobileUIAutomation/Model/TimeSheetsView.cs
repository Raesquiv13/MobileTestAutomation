using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using WorkWave.TA.TestEngine;

namespace RealGreen.MobileAutomation.Model
{
    class TimeSheetsView
    {
        #region Page Factory
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='TimeSheets']")]
        private OpenQA.Selenium.IWebElement timeSheetsScreenTitle { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='timesheets_menu_edit']")]
        private OpenQA.Selenium.IWebElement crewMembersIcon { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='timesheet_user_name']")]
        private OpenQA.Selenium.IWebElement userNameTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='timesheet_user_position']")]
        private OpenQA.Selenium.IWebElement loggedInAsTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Not Clocked In']")]
        private OpenQA.Selenium.IWebElement notClockedInTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='timesheet_user_clocked_in']")]
        private OpenQA.Selenium.IWebElement clockedInTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='CLOCK IN']")]
        private OpenQA.Selenium.IWebElement clockInButton { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='CLOCK OUT']")]
        private OpenQA.Selenium.IWebElement clockOutButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.View'] and ./*[@text='Aaron Kiefer']]")]
        private OpenQA.Selenium.IWebElement member1 { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.View'] and ./*[@text='Aaron Beck']]")]
        private OpenQA.Selenium.IWebElement member2 { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.View'] and ./*[@class='android.widget.ImageView'] and ./*[@text='Aaron Kiefer']]")]
        private OpenQA.Selenium.IWebElement member1Selected { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.View'] and ./*[@class='android.widget.ImageView'] and ./*[@text='Aaron Beck']]")]
        private OpenQA.Selenium.IWebElement member2Selected { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='crew_members_menu_done']")]
        private OpenQA.Selenium.IWebElement doneButton { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Aaron Kiefer']")]
        private OpenQA.Selenium.IWebElement member1InTimeSheets { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Aaron Beck']")]
        private OpenQA.Selenium.IWebElement member2InTimeSheets { get; set; }



        #endregion

        #region Page Factory Setup
        public TimeSheetsView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        #endregion
       
        #region Behaivor
        public bool TimeSheetsTitleVisible()
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(timeSheetsScreenTitle), TimeSpan.FromSeconds(30));
            return timeSheetsScreenTitle.Displayed;
        }
        public bool UserNameVisible() => userNameTextView.Displayed;
        public bool NotClockedInVisible() => notClockedInTextView.Displayed;

        public bool LoggedInAsViisble() => loggedInAsTextView.Displayed;
        public bool ClockInButtonEnabled() => clockInButton.Enabled;
        public void ClickOnClockIn() => clockInButton.Click();
        public void ClickOnClockOut() => clockOutButton.Click();
        public string GetUserName() => userNameTextView.Text.Trim();
        public string GetClocked() => clockedInTextView.Text.Trim(); ////*[@id='timesheet_user_clocked_in'] 

        public void clickDoneButton() => doneButton.Click();

        public void addOrRemoveCrewMembers(bool clickDone) {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(crewMembersIcon), TimeSpan.FromSeconds(30));
            crewMembersIcon.Click();

            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(member1), TimeSpan.FromSeconds(30));
            member1.Click();

            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(member2), TimeSpan.FromSeconds(30));
            member2.Click();

            if (clickDone)
            {
                clickDoneButton();
            }
        }


        public bool areCrewMemberSelected()
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(member1Selected), TimeSpan.FromSeconds(30));
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(member2Selected), TimeSpan.FromSeconds(30));
            return true;
        }

        public bool verifyCrewMembersAppearsTimesheetsScreen() {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(member1InTimeSheets), TimeSpan.FromSeconds(30));
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(member2InTimeSheets), TimeSpan.FromSeconds(30));
            return false;
        }

        public bool verifyCrewMembersWereRemoveTimesheetsScreen()
        {
            return !member1InTimeSheets.Displayed && !member2InTimeSheets.Displayed;
        }

        #endregion
    }
}
