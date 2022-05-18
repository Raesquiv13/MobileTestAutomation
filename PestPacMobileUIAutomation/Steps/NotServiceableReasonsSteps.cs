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
    public sealed class NotServiceableReasonsSteps
    {
        JobListView jobs = new JobListView();
        QuickProductionView quickProduction= new QuickProductionView();
        NotServiceableReasonsView NotServ = new NotServiceableReasonsView();

        [Given(@"Hit on a Job from List")]
        public void GivenHitOnAJobFromList()
        {
            jobs.ClickOnJob();
        }
        
        [When(@"Add Serviceable Reason")]
        public void WhenAddServiceableReason()
        {
            quickProduction.ClickOnNotServiceable();
            NotServ.SelectNotServiceableReason();
        }
        
        [Then(@"Job is Marked Not Serviceable")]
        public void ThenJobIsMarkedNotServiceable()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
