using OpenQA.Selenium;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using OpenQA.Selenium.Support.PageObjects;
using RealGreen.MobileAutomation;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using WorkWave.TA.TestEngine;

namespace WorkWave.PestPac.Mobile.Model
{
    class PDFView
    {
        // This view is built around google drive's pdf viewer. In the event that google drive isn't available on
        // a given phone this code will have to be modified. In addition make sure that google drive is designated as
        // the default pdf viewing app

        #region Page Factory
        // Functionally this button does nothing but serves as a unique identifier for the pdf viewer indicating
        // the inspection report is opened
        [FindsBy(How = How.Id, Using = "edit_fab")]
        private IWebElement ReportEditButton { get; set; }

        [FindsBy(How = How.Id, Using = "pdf_view")]
        private IWebElement PDFViewIdentifier { get; set; }

        [FindsBy(How = How.Id, Using = "action_mode_close_button")]
        private IWebElement CloseButton { get; set; }

        [FindsBy(How = How.Id, Using = "action_find")]
        private IWebElement SearchIcon { get; set; }

        [FindsBy(How = How.Id, Using = "find_query_box")]
        private IWebElement SearchField { get; set; }

        [FindsBy(How = How.Id, Using = "match_status_textview")]
        private IWebElement MatchStatus { get; set; }

        [FindsBy(How = How.Id, Using = "button_once")]
        private IWebElement DriveButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text and @class='android.widget.TextView' and ./parent::*[@id='projector_toolbar']]")]
        private IWebElement PDFTitle { get; set; }

        #endregion Page Factory

        #region Page Factory Setup

        public PDFView() => InitializePageFactoryElements();

        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);

        #endregion Page Factory Setup

        #region Behavior

        public string GetPDFTitle() => PDFTitle.GetAttribute("text");

        public bool VerifyPageLoaded(int time)
        {
            if (RealGreenMobileSupport.GetDeviceName().Contains("Pixel 2"))
            {
                if (DriveButtonVisible(2))
                {
                    OpenWithDrive();

                    return SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(PDFViewIdentifier), System.TimeSpan.FromSeconds(time));
                }
                    
            }
            return SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(ReportEditButton), System.TimeSpan.FromSeconds(time));
        }

        public bool DriveButtonVisible(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(DriveButton), System.TimeSpan.FromSeconds(time));
        public void OpenWithDrive() => DriveButton.Click();

        public void Close()
        {
                CloseButton.Click();
        }

        public bool CloseButtonVisible(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(SearchField), System.TimeSpan.FromSeconds(time));

        public void OpenSearch()
        {
            if (!SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(SearchField), System.TimeSpan.FromSeconds(3)))
                SearchIcon.Click();
        }

        public bool SearchText(string search)
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(SearchField), System.TimeSpan.FromSeconds(3));
            SearchField.Click();
            SearchField.Clear();
            SearchField.SendKeys(search);
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(MatchStatus), System.TimeSpan.FromSeconds(5));
            while (MatchStatus.GetAttribute("text")==null)
            {
                SearchField.Clear();
                SearchField.SendKeys(search);
            }

            if (MatchStatus.GetAttribute("text").Equals("1 of 1"))
                return true;
            return false;
        }

        #endregion Behavior

        #region Behavior Support

        #endregion Behavior Support
    }
}
