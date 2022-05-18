using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WorkWave.TA.TestEngine;

namespace RealGreen.MobileAutomation.Model
{
    class RouteListView
    {
        #region PageFactory

        //New Code 2.0
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='jobs_fragment']")]
        private OpenQA.Selenium.IWebElement jobsFrameLayout { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='timesheets_fragment']")]
        private OpenQA.Selenium.IWebElement timesheetsFrameLayout { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='more_fragment']")]
        private OpenQA.Selenium.IWebElement moreFrameLayout { get; set; }
        //*** More Section  **********///
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='logout_container']")]
        private OpenQA.Selenium.IWebElement logoutContainer { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='button1']")]
        private OpenQA.Selenium.IWebElement logoutButton { get; set; }




        //DEPOT ViewGroup Xpath
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='DEPOT'")]
        public OpenQA.Selenium.IWebElement DepotViewGroup { get; set; }
        //Bob Kolich Job 
        [FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@text='Bob Harsh']]")]
        public IWebElement VickiJobViewGroup { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='Broken equipment']")]
        public IWebElement notServiceableReasonTextView { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.TextView' and ./parent::*[@class='androidx.appcompat.widget.LinearLayoutCompat']]")]
        public IWebElement threedotsButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.LinearLayout' and ./*[@id='loadingProgressWheel']]")]
        public IWebElement loadingLayout { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Refresh Parameters']")]
        public IWebElement refreshParametersTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Refresh Images']")]
        public IWebElement refreshImagesTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Refresh Images']")]
        public IWebElement imageDownloadTextBox { get; set; }
        [FindsBy(How = How.Id, Using = "textViewStatus")]
        public IWebElement statusTextView { get; set; }
        //Menu 
        [FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.ViewGroup' and ./*[@text='Vehicle Inventory']]]")]
        public IWebElement vehicleInventoryMenu { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.ViewGroup' and ./*[@text='Call Log']]]")]
        public IWebElement callLogMenu { get; set; }
        #endregion

        #region Page Factory Setup
        public RouteListView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);

        #endregion

        #region Behaivor
        public bool VerifyElementLoaded(int time, IWebElement element) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(element), TimeSpan.FromSeconds(time)));
        public bool VerifyElementNLoaded(int time, IWebElement element) => (!SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(element), TimeSpan.FromSeconds(time)));
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(jobsFrameLayout), TimeSpan.FromSeconds(time)));
        public bool VerifyExistingJob(int time, IWebElement job) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(job), TimeSpan.FromSeconds(time)));
        public void ClickOnThreeDots() => threedotsButton.Click();
        public void ClickOnStop() => VickiJobViewGroup.Click();
        public void clickOnElement(IWebElement element) => element.Click();
        //New Code 2.0
        public void ClickOnMore() => moreFrameLayout.Click();
        public void ClickOnLogout() => logoutContainer.Click();
        public void ClickOnConfirmLogout() => logoutButton.Click();
        public void ClickOnTimeSheets() {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(timesheetsFrameLayout), TimeSpan.FromSeconds(30));
            timesheetsFrameLayout.Click();
}
        
        #endregion

    }
}
