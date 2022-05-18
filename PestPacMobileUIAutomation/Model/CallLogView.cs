using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using WorkWave.TA.TestEngine;

namespace RealGreen.MobileAutomation.Model
{
    class CallLogView
    {
        #region Page Factory
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@text='Total Calls:']")]
        public OpenQA.Selenium.IWebElement totalCallsTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "(//*[@class='androidx.appcompat.widget.LinearLayoutCompat']/*[@class='android.widget.TextView'])[1]")]
        public OpenQA.Selenium.IWebElement plusIconTextView { get; set; }
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@class='android.view.ViewGroup' and ./*[@text='Allison George']]")]
        public OpenQA.Selenium.IWebElement AllisonCustomerViewGroup { get; set; }

        #endregion

        #region Page Factory Setup
        #endregion

        #region Behavior
        #endregion
    }
}
