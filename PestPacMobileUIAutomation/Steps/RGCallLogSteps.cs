using NUnit.Framework;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using RealGreen.MobileAutomation.Model;
//using WorkWave.PestPac.Mobile.Model;


namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class RGCallLogSteps
    {
        
        
        RGCallLogPage rgCallLog = new RGCallLogPage();
       
 

        [Given(@"Click on Main Arrow")]
        public void GivenClickOnMainArrow()
        {
            Thread.Sleep(20000);
            Console.Write("Main button clicked");
            rgCallLog.MainButton();

        }

        [When(@"Click on Call log")]
        public void WhenClickOnCallLog()
        {
            Thread.Sleep(5000);
            Console.Write("Call log button clicked");
            rgCallLog.CallLog();
        }

        [Then(@"Check Call log information")]
        public void ThenCheckCallLogInformation()
        {
            Thread.Sleep(10000);
            Assert.IsTrue(rgCallLog.verifyMessage().Contains("1 Employee Selected"));
            Console.Write("Home Page displayed");
        }

    }
}
