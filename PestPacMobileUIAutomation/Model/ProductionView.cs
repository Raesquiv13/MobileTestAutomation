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
    class ProductionView
    {
        #region Page Factory
        //Confirm Windows
        [FindsBy(How = How.XPath, Using = "//*[@text='Confirm']")]
        private IWebElement confirmTextView { get; set; }
        //Start Time Yes/NO Button
        [FindsBy(How = How.XPath, Using = "//*[@text='Yes']")]
        private IWebElement yesStartTimeButton { get; set; }
        [FindsBy(How = How.Id, Using = "button2")]
        private IWebElement noStartTimeButton { get; set; }
        //Work Completed By Window
        [FindsBy(How = How.XPath, Using = "//*[@text='Yes']")]
        private IWebElement completedYesButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='No (Exit Anyways)']")]
        private IWebElement completedNoButton { get; set; }
        //Add Job Details View Group
        [FindsBy(How = How.XPath, Using = "(//*[@class='android.view.ViewGroup' and ./parent::*[@class='android.widget.FrameLayout']]/*[./*[@class='android.widget.ImageButton']])[3]")]
        private IWebElement AddJobDetailViewGroup { get; set; }
        [FindsBy(How = How.XPath, Using = "((//*[@class='android.view.ViewGroup' and ./parent::*[@class='android.widget.FrameLayout']]/*[@class='android.view.ViewGroup'])[7]/*[@class='android.widget.ImageButton'])[1]")]
        private IWebElement AddProductsButton { get; set; }
        [FindsBy(How = How.XPath, Using = "((//*[@class='android.view.ViewGroup' and ./parent::*[@class='android.widget.FrameLayout']]/*[@class='android.view.ViewGroup'])[7]/*[@class='android.widget.ImageButton'])[2]")]
        private IWebElement AddConditionsButton { get; set; }
        [FindsBy(How = How.XPath, Using = "((//*[@class='android.view.ViewGroup' and ./parent::*[@class='android.widget.FrameLayout']]/*[@class='android.view.ViewGroup'])[7]/*[@class='android.widget.ImageButton'])[3]")]
        private IWebElement AddWeatherButton { get; set; }
        [FindsBy(How = How.XPath, Using = "((//*[@class='android.view.ViewGroup' and ./parent::*[@class='android.widget.FrameLayout']]/*[@class='android.view.ViewGroup'])[7]/*[@class='android.widget.ImageButton'])[4]")]
        private IWebElement AddNotesButton { get; set; }
        //Menu Buttons
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Button' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@class='android.widget.ImageButton']]]")]
        private IWebElement arrowButton { get; set; }
        //Menu options
        [FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@class='android.view.ViewGroup' and ./*[@class='android.widget.FrameLayout' and ./*[@class='android.view.ViewGroup']]]]")]
        private IWebElement menuViewGroup { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Reschedule']")]
        private IWebElement rescheduleMenu { get; set; }
        [FindsBy(How = How.Id, Using = "back")]
        private IWebElement backButton { get; set; }
        

        #endregion
        #region Page Factory Setup
        public ProductionView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(confirmTextView), TimeSpan.FromSeconds(time)));
        public bool VerifyMenuLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(menuViewGroup), TimeSpan.FromSeconds(time)));
        public bool VerifyRescheduleMenuLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(rescheduleMenu), TimeSpan.FromSeconds(time)));
        public bool VerifyJobStarted() => AddJobDetailViewGroup.Enabled; //this can be works diffrent not Sure

        

        #endregion
        #region Behaivor
        public void clickOnNoStart() => noStartTimeButton.Click();
        public void clickOnYesStart() => yesStartTimeButton.Click();
        public void clickOnCompleted() => completedYesButton.Click();
        public void clickOnNotCompleted() => completedNoButton.Click();
        public void clickOnArrow() => arrowButton.Click();
        public void clickOnReschedule() => rescheduleMenu.Click();
        public void clickOnBack() => backButton.Click();
        
        #endregion
    }
}
