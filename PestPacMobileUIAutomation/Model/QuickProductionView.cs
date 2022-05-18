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
    class QuickProductionView
    {
        #region Page Factory
        // NEw Code 2.0
        //1st job in list    (//*[@class='android.view.ViewGroup' and ./*[@class='androidx.cardview.widget.CardView']])[1]


        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Start']")]
        public OpenQA.Selenium.IWebElement startButton { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='End']")]
        public OpenQA.Selenium.IWebElement endButton { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Not Serviceable']")]
        public OpenQA.Selenium.IWebElement notServiceableButton { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Close']")]
        public OpenQA.Selenium.IWebElement closeButton { get; set; }
        #endregion
        #region Page Factory Setup
        public QuickProductionView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        #endregion
        #region Behaivor
        public void ClickOnButton(IWebElement element) => element.Click();
        public void ClickOnNotServiceable()
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(notServiceableButton), TimeSpan.FromSeconds(10));
            ClickOnNotServiceable();
        }
        public bool VerifyElementLoaded(int time, IWebElement element) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(element), TimeSpan.FromSeconds(time)));
        #endregion
    }
}
