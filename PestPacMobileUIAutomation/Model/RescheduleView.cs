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
    class RescheduleView
    {

        #region Page Factory
        //New
        [FindsBy(How = How.XPath, Using = "//*[@text='Choose a service to re-schedule']")]
        private IWebElement reschedulePageTitle { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@text='I25 Backflow Test (I25)']]")]
        private IWebElement service { get; set; }

        //old
        

        #endregion

        #region Page Factory Setup

        public RescheduleView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(reschedulePageTitle), TimeSpan.FromSeconds(time)));
        #endregion Page Factory Setup

        #region Behavior

        //New
        public void clickOnService() => service.Click();

        //Old
        // When choosing a time, remove leading zeroes
        public bool SelectTime(string time)
        {
            try
            {
                WebApplication.Instance.WebDriver.FindElement(By.XPath("//*[@contentDescription='" + time + "']")).Click();
                return true;
            }
            catch
            {
                return false;
            }
        }
          
        public int findMonthEnd()
        {
            int r = 1;

                try
                {
                    WebApplication.Instance.WebDriver.FindElement(By.LinkText("31"));
                    r = 31;
                }
                catch
                {
                    try
                    {
                        WebApplication.Instance.WebDriver.FindElement(By.LinkText("30"));
                        r = 30;
                    }
                    catch
                    {
                        try
                        {
                            WebApplication.Instance.WebDriver.FindElement(By.LinkText("29"));
                            r = 29;
                        }
                        catch
                        {
                            r = 28;
                        }
                    }
                }

            return r;
        }
       
        public int RescheduleNextAvailable()
        {
            int daysAhead = 0;
            DateTime today = new DateTime();
            today = DateTime.Now;
            int day = today.Day;
           // daysAhead = RescheduleDatePlusOne(day, 0);
            return daysAhead;
        }

        #endregion Behavior

        #region Behavior Support



        #endregion Behavior Support

    }
}
