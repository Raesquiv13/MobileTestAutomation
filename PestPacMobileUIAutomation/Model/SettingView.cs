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
    class SettingView
    {
        #region Page Factory
        [FindsBy(How = How.XPath, Using = "//*[@text='Setup Route']")]
        private IWebElement setupRouteListView { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Refresh Vehicle Inventory']")]
        public IWebElement refreshVehicleInventoryListView { get; set; }

        #endregion
        #region Page Factory Setup
        public SettingView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(setupRouteListView), TimeSpan.FromSeconds(time)));
        #endregion
        #region Behaivor
        public void clickOnSetupRoute() => setupRouteListView.Click();
        public void clickOnElement(IWebElement element) => element.Click();
        #endregion
    }
}
