using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WorkWave.TA.TestEngine;
using System;

namespace RealGreen.MobileAutomation.Model
{
    class ProductionEntryView : BasePage
    {

        #region Page Factory
        [FindsBy(How = How.XPath, Using = "(//*[@id='job_details_option_list']/*[./*[@id='item_job_details_products_icon']])[1]")]
        private IWebElement productsViewGroup { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@id='job_details_option_list']/*[./*[@id='item_job_details_products_icon']])[2]")]
        private IWebElement conditionsViewGroup { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@id='job_details_option_list']/*[./*[@id='item_job_details_products_icon']])[3]")]
        private IWebElement weatherViewGroup { get; set; }
        [FindsBy(How = How.XPath, Using = "(//*[@id='job_details_option_list']/*[./*[@id='item_job_details_products_icon']])[4]")]
        private IWebElement customerNotesViewGroup { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='IN PROGRESS']")]
        private IWebElement inprogressServiceStatus { get; set; }
        #endregion
        #region PageFactorySetup
        public ProductionEntryView(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
        }
        #endregion
        #region Behaivor
        public override bool verifyPageLoads()
        {
            return waitForElementVisible(customerNotesViewGroup);
        }
           
        #endregion



    }
}
