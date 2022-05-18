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
    class CrewMembersView
    {
        #region Page Factory
        [OpenQA.Selenium.Support.PageObjects.FindsBy(How = How.XPath, Using = "//*[@id='job_date_picker']")]
        private OpenQA.Selenium.IWebElement dateTextView { get; set; }
        #endregion
        #region Page Factory Setup
        #endregion
        #region Behaivor
        #endregion
    }
}
