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
    class MapView
    

    #region Page Factory
    {
        [FindsBy(How = How.XPath, Using = "(//*[@id='fab_icon']/*/*[@class='android.widget.ImageView' and ./parent::*[@class='android.widget.FrameLayout']])[2]")]
        private IWebElement startButton { get; set; }
        #endregion
        #region Page Factory Setup
        public MapView() => InitializePageFactoryElements();
        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);
        #endregion
        #region Behaivor
        public bool VerifyPageLoaded(int time) => (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(startButton), TimeSpan.FromSeconds(time)));
        #endregion
    }


}
