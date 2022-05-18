using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WorkWave.TA.TestEngine;
using System;

namespace RealGreen.MobileAutomation.Model
{
    class OdometerPageView
    {
        #region Page Factory
        //Menu Button Xpath= //*[@class='android.widget.Button']
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Button']")] //*[@class='android.widget.Button'], //*[@class='android.widget.Button'], //*[@class='android.widget.ImageButton']
        private IWebElement MenuButton { get; set; }

        //Odometer Menu Xpath=  //*[@text='Odometer']
        [FindsBy(How = How.XPath, Using = "//*[@text='Odometer']")]
        private IWebElement OdometerSubMenu { get; set; }

        //Odometer Message Xpath= //*[@text='Set the odometer (no tenths) reading for vehicle Test vehdesc']
        [FindsBy(How = How.XPath, Using = "//*[@text='Set the odometer (no tenths) reading for vehicle Test vehdesc']")]
        private IWebElement OdomerterMessage { get; set; }

        //Odometer TextBox Xpath=  //*[@class='android.widget.EditText']
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.EditText']")]
        private IWebElement OdomerterTextBox { get; set; }

        //Ok Button Xpath = //*[@text='Ok']
        [FindsBy(How = How.XPath, Using = "//*[@text='Ok']")]
        private IWebElement OkButton { get; set; }

        //Cancel Button Xpath = //*[@text='Cancel']
        [FindsBy(How = How.XPath, Using = "//*[@text='Cancel']")]
        private IWebElement CancelButton { get; set; }

        #endregion

        #region Page Factory Setup

        public OdometerPageView() => InitializePageFactoryElements();

        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);

        #endregion Page Factory Setup

        #region Behavior
        public bool OdometerTextBoxVisible() => OdomerterTextBox.Displayed;
        public void OdometerClear() => OdomerterTextBox.Clear();
        public void EnterOdometer() => OdomerterTextBox.SendKeys("50");
        public string VerifyOdometer() => OdomerterMessage.Text;

        public void ClickMenu() => MenuButton.Click();
        public void ClickOdometerSub_Menu() => OdometerSubMenu.Click();

        public bool VerifyOdometerSubMenu() => OdometerSubMenu.Displayed;

        public string VerifyOdometerValue() => OdometerSubMenu.Text;
        public void ClickOk() => OkButton.Click();
        public void ClickCancel() => CancelButton.Click();

        public bool VerifyViewLoaded(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(OdomerterTextBox), System.TimeSpan.FromSeconds(time));
        #endregion

        #region Behavior Support
        public void UpdateOdometer()
        {
            if (VerifyViewLoaded(10000))
            {
                OdomerterTextBox.Clear();
                OdomerterTextBox.SendKeys("400");
            }
            ClickOk();
        }
        #endregion

    }
}
