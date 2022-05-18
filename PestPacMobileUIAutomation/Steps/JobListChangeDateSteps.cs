using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using RealGreen.MobileAutomation.Model;
using System.Collections.Generic;
using RealGreen.MobileAutomation.SharedData;

namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class JobListChangeDateSteps
    {
        JobListView jobs = new JobListView();
        Dictionary<int, Job> firstJoblistData;




        [Then(@"Job List are Updated")]
        public void ThenJobListAreUpdated()
        {
            Dictionary<int, Job> secondJoblistData;
            secondJoblistData= jobs.getJoblistData();
            if (firstJoblistData.Count != 0 && secondJoblistData.Count != 0)
            {
               int iterationQty =  Math.Min(firstJoblistData.Count, secondJoblistData.Count);
                for (int i = 0; i > iterationQty; i++)
                {
                    Assert.AreNotEqual(firstJoblistData[i].address1,secondJoblistData[i].address1);
                    Assert.AreNotEqual(firstJoblistData[i].address2, secondJoblistData[i].address2);
                    Assert.AreNotEqual(firstJoblistData[i].services, secondJoblistData[i].services);
                }
            }
        }

        [When(@"Jobs List are Displayed")]
        public void WhenJobsListAreDisplayed()
        {
            firstJoblistData = jobs.getJoblistData();
        }

        [When(@"Change Date")]
        public void WhenChangeDate()
        {
            jobs.changeDate();
            Thread.Sleep(10);

        }

    }
}
