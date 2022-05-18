using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TechTalk.SpecFlow;
using WorkWave.TA.TestEngine;
using RealGreen.MobileAutomation.SharedData;

namespace RealGreen.MobileAutomation.Model
{
   
    class JobListView
    {
        #region Page Factory
        //Job List leng  //*[@id='job_list']/*/*/*[@class='android.view.ViewGroup' and ./*[@id='address_container']]

        //[OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='job_list']/*/*/*[@class='android.view.ViewGroup' and ./*[@id='address_container']]")]
        //private OpenQA.Selenium. IList<IWebElement> jobListQty { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "(//*[@id='job_list']/*/*/*[@class='android.view.ViewGroup' and ./*[@id='address_container'] and ./*[@id='job_separator2']])[1]")]
        private OpenQA.Selenium.IWebElement firstJob { get; set; }

        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='job_date_picker']")]
        private OpenQA.Selenium.IWebElement dateTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='job_depot_title'")]
        private OpenQA.Selenium.IWebElement depotTextView { get; set; }
        //   
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='mtrl_picker_header_toggle']")]
        private OpenQA.Selenium.IWebElement editdateButton { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@class='android.widget.EditText']")]
        private OpenQA.Selenium.IWebElement newdateTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='confirm_button']")]
        private OpenQA.Selenium.IWebElement confirmButton { get; set; }

        #endregion
        #region Page factory Setup
        public JobListView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        #endregion
        #region Behaivor
        public void ClickOnJob()
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(depotTextView), TimeSpan.FromSeconds(25));
            firstJob.Click();
        }
        public void changeDate()
        {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(dateTextView), TimeSpan.FromSeconds(10));
            dateTextView.Click();
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(editdateButton), TimeSpan.FromSeconds(10));
            editdateButton.Click();
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(newdateTextView), TimeSpan.FromSeconds(10));
            newdateTextView.SendKeys("4/28/22");
            confirmButton.Click();

        }
        public Dictionary<int, Job> getJoblistData()
        {
            IWebDriver driver = WebApplication.Instance.WebDriver;
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(depotTextView), TimeSpan.FromSeconds(10));
            IList<IWebElement> jobListQty = driver.FindElements(By.XPath("//*[@id='job_list']/*/*/*[@class='android.view.ViewGroup' and ./*[@id='address_container']]"));
           

            int qty = jobListQty.Count;
            Job[] jobs = new Job [qty];
            Dictionary<int, Job> jobListData = new Dictionary<int, Job>();
            int jobindex = 1;
            for (int x = 0; x < qty; x++)
            {
                IWebElement address1 = driver.FindElement(By.XPath("(//*[@id='address_text1'])["+ jobindex + "]"));
                IWebElement address2 = driver.FindElement(By.XPath("(//*[@id='address_text2'])[" + jobindex + "]"));
                IWebElement services = driver.FindElement(By.XPath("(//*[@id='job_services_text'])[" + jobindex + "]"));
                jobs[x] = new Job();
                jobs[x].address1 = address1.Text.Trim();
                jobs[x].address2 = address2.Text.Trim();
                jobs[x].services = services.Text.Trim();
                jobListData.Add(x, jobs[x]);
                jobindex++;
            }
            return jobListData;

        }
        #endregion
    }
}
