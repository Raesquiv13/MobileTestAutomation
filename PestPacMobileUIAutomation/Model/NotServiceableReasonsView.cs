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
    class NotServiceableReasonsView
    {
        #region Page Factory
        //New Code 2.0

        [FindsBy(How = How.XPath, Using = "(//*[@id='not_serviceable_reasons_list']/*/*[@id='item_not_serviceable_reasons_title'])")]
        private IWebElement notserviceableItem { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='not_serviceable_reasons_menu_done']")]
        private IWebElement doneButton { get; set; }


        /// <summary>
        /// //
        /// </summary>

        [FindsBy(How = How.XPath, Using = "//*[@text='Not serviceable reasons']")]
        private IWebElement notserviceablePageTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.Switch' and ./parent::*[(./preceding-sibling::* | ./following-sibling::*)[@text='Broken equipment']]]")]
        private IWebElement brokenequipmentSwitch { get; set; }
        [FindsBy(How = How.Id, Using = "back")]
        private IWebElement backButton { get; set; }
        #endregion
        #region Page Factory Setup
        public NotServiceableReasonsView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(notserviceablePageTitle), TimeSpan.FromSeconds(time)));
        #endregion
        #region Behaivor
        public bool enableBrokenEquipment() => brokenequipmentSwitch.Enabled;
        public void clickOnBack() => backButton.Click();

        public void SelectNotServiceableReason()
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(doneButton), TimeSpan.FromSeconds(5));
            notserviceableItem.Click();
            doneButton.Click();
        }
        #endregion
    }
}
