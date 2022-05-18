using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkWave.TA.TestEngine;

namespace RealGreen.MobileAutomation.Model
{
    class RGCallLogPage
    {

        #region Page Factory          
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Button']")]
        private IWebElement MainScreenButton { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//*[@text='Call Log']")]
        private IWebElement CallLogOption { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='1 Employee Selected']")]
        private IWebElement CallLogText { get; set; }
        #endregion Page Factory

        public RGCallLogPage() => InitializePageFactoryElements();

        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);

        public bool VerifyMainScreenLoaded(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(MainScreenButton), System.TimeSpan.FromSeconds(time));

        public bool VerifyMessageLoaded(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(CallLogText), System.TimeSpan.FromSeconds(time));
        public void MainButton()
        {
            VerifyMainScreenLoaded(50);
            MainScreenButton.Click();
        }
  

        public void CallLog() => CallLogOption.Click();

        public string verifyMessage()
        {
            VerifyMessageLoaded(15);
            string message1 = CallLogText.Text;
            Console.Write(message1);
            return message1;

        }

    }
}