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
    class StopView
    {
        #region PageFactory
        //Confirm/Navigate/Three Dots  Buttons
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Confirm']")]
        public IWebElement confirmButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Navigate']")]
        private IWebElement navigateButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.TextView' and ./parent::*[@class='androidx.appcompat.widget.LinearLayoutCompat']]")]
        private IWebElement threedotsButton { get; set; }
        //List View Displayed after hot on tree dots
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement callListView { get; set; }
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement linkeddocsListView { get; set; }
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement customerSearchListView { get; set; }
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement treatmenthistoryListView { get; set; }
        #endregion

        #region Page Factory Setup
        public StopView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        #endregion
        #region Behaivor
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(confirmButton), TimeSpan.FromSeconds(time)));
        public void clickOnConfirm()
        {
            confirmButton.Click();
        }
        #endregion
    }



}
