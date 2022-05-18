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
    class RouteSetupView
    {
        #region Page Factory
        [FindsBy(How = How.XPath, Using = "//*[@text='Route Setup']")]
        private IWebElement routeSetupPageTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.EditText']")]
        private IWebElement dateTextBox { get; set; }
        
        [FindsBy(How = How.Id, Using = "back")]
        private IWebElement backButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Switch' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@text='Auto-navigate:']]]")]
        public IWebElement autoNavigateSwitch { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Switch' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@text='Auto-refresh Route:']]]")]
        public IWebElement AutoRefreshRouteSwitch { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Switch' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@text='Do Quick Production:']]]")]
        public IWebElement doQuickProductionSwitch { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Switch' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@text='Do Not Auto Advance Date']]]")]
        public IWebElement doNotAutoAdvanceDateSwitch { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Switch' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@text='Do Not Auto Advance Date']]]")]
        public IWebElement showDateDistanceSwitch { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.TextView' and ./parent::*[@class='androidx.appcompat.widget.LinearLayoutCompat']]")]
        public IWebElement threedotsButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Options']")]
        public IWebElement optionsTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Delete Database']")]
        public IWebElement deleteDatabaseButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='loadingProgressWheel'")]
        public IWebElement loadingprogressView { get; set; }

        #endregion
        #region Page Factory Setup
        public RouteSetupView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(routeSetupPageTitle), TimeSpan.FromSeconds(time)));
        #endregion
        #region Behaivor
        public void typeNewDate(String date) => dateTextBox.SendKeys(date); //format Day,M/D/Y
        public void clickOnBack() => backButton.Click();
        public void clickOnThreedoots() => threedotsButton.Click();
        public void clickOnDeleteDatabase() => deleteDatabaseButton.Click();
        public void clickonElement(IWebElement element) => element.Click();
        public bool verifyElementLoaded(int time, IWebElement element)=> (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(element), TimeSpan.FromSeconds(time)));
        public bool VerifyProgressWheelLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(loadingprogressView), TimeSpan.FromSeconds(time)));
        public bool VerifyNoProgressWheelLoaded(int time) => (!SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(loadingprogressView), TimeSpan.FromSeconds(time)));
        public void enableSwitch(IWebElement element)
        {                       
            if (element.GetAttribute("checked") == "false")
                element.Click();
         }
        public void disableSwitch(IWebElement element)
        {
            if (element.GetAttribute("checked") == "true")
                element.Click();
        }

        #endregion
    }
}
