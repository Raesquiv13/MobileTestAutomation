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
    class ScheduleView
    {
        #region Page Factory
        [FindsBy(How = How.XPath, Using = "//*[@text='Clear']")]
        private IWebElement clearButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text and @class='android.widget.EditText' and ./parent::*[./parent::*[./parent::*[(./preceding-sibling::* | ./following-sibling::*)[./*[@text='Schedule Date']]]]]]")]
        private IWebElement scheduleDateTextBox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text and @class='android.widget.EditText' and ./parent::*[./parent::*[./parent::*[(./preceding-sibling::* | ./following-sibling::*)[./*[@text='Schedule Date']]]]]]")]
        private IWebElement promisedSwitch { get; set; }
        [FindsBy(How = How.Id, Using = "back")]
        private IWebElement backButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='month_view']")]
        private IWebElement monthViewController { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='18']")]
        private IWebElement dayViewController { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Aceptar']")]
        private IWebElement AcceptButton { get; set; }
        #endregion
        #region Page Factory Setup
        public ScheduleView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(clearButton), TimeSpan.FromSeconds(time)));
        public bool VerifyMonthViewLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(monthViewController), TimeSpan.FromSeconds(time)));
        public bool VerifyBackLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(backButton), TimeSpan.FromSeconds(time)));

        #endregion
        #region Behaivor
        public void clickOnBack() => backButton.Click();
        public void clickOnScheduleDate() => scheduleDateTextBox.Click();
        public void clickOnDay() => dayViewController.Click();
        public void clickOnAccept() => AcceptButton.Click();
        public void EnterNewDate()
        {
            //clickOnScheduleDate();
            clickOnDay();
            clickOnAccept();
        }
        public bool enablePromise() => promisedSwitch.Enabled;
        #endregion
    }
}
