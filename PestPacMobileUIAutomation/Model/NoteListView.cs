using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using WorkWave.TA.TestEngine;

namespace WorkWave.PestPac.Mobile.Model
{
    class NoteListView
    {

        #region Page Factory

        [FindsBy(How = How.XPath, Using = "//*[@text='Notes']")]
        private IWebElement Header { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='Alerts']")]
        private IWebElement AlertsHeader { get; set; }

        [FindsBy(How = How.Id, Using = "Add")]
        private IWebElement AddButton { get; set; }

        #endregion

        #region Page Factory Setup

        public NoteListView() => InitializePageFactoryElements();

        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);



        #endregion Page Factory Setup

        #region Behavior

        public void AddNote() => AddButton.Click();

        public bool VerifyViewLoaded(int time)
        {
            if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(Header), TimeSpan.FromSeconds(time)))
                return true;
            return false;
        }

        public bool VerifyAlertsOpened(int time)
        {
            if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(AlertsHeader), TimeSpan.FromSeconds(time)))
                return true;
            return false;
        }

        public bool VerifyNoteAtIndex(string text, string toc, int index)
        {
            IWebElement UserDate = WebApplication.Instance.WebDriver.FindElement(By.XPath("(//*[@id='RecyclerView']/*/*[@id='UserAndDate'])[" + index + "]"));
            IWebElement NoteText = WebApplication.Instance.WebDriver.FindElement(By.XPath("(//*[@id='RecyclerView']/*/*[@id='Note'])[" + index + "]"));
            if (UserDate.GetAttribute("text").Contains(toc) && NoteText.GetAttribute("text").Contains(text))
                return true;
            return false;
        }

        #endregion Behavior

        #region Behavior Support



        #endregion Behavior Support

    }
}
