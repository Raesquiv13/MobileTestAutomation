using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class RealGrennLoginSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;

        public RealGrennLoginSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"Open the Homepage")]
        public void GivenOpenTheHomepage()
        {
            Console.Write("test");
        }

        [When(@"Enter User name and Password")]
        public void WhenEnterUserNameAndPassword()
        {
            Console.Write("test");
        }

        [Then(@"Home page displayed")]
        public void ThenHomePageDisplayed()
        {
            Console.Write("test");
        }

    }
}
