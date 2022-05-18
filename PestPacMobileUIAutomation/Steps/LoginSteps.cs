using NUnit.Framework;
using OpenQA.Selenium;
using RealGreen.MobileAutomation.Model;
using RealGreen.MobileAutomation.ShareData;
using System;
using System.Diagnostics;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
//using WorkWave.PestPac.Mobile.Model;


namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class LoginSteps
    {
        //private LoginPageView login;
        
        
        private RouteListView routeList = new RouteListView();
       
        LoginPageView loginPage = new LoginPageView();
        // New code 

        [Given(@"Home")]
        public void GivenHome()
        {
            Thread.Sleep(4000);
            Console.Write("432423");
            //Thread.Sleep(25000);
        }

        [When(@"Enter user name and password")]
        public void WhenEnterUserNameAndPassword()
        {
            Console.Write("Enter User name and password  ");

            loginPage.RGLoginAttempt();
         
        }

        [Then(@"Real Green Home page displayed")]
        public void ThenRealGreenHomePageDisplayed()
        {
            Thread.Sleep(6000);
            Assert.IsTrue(loginPage.LoginMessageVisible());
            //RouteListView routeList = new RouteListView();
            //routeList.VerifyDepot(3000);
            loginPage.ClikOkButton();
            routeList.VerifyPageLoaded(1000);
            Console.Write("Home Page displayed");
            routeList.ClickOnMore();
            routeList.ClickOnLogout();
            routeList.ClickOnConfirmLogout();
            
        }

        [When(@"Enter user name and Wrong password")]
        public void WhenEnterUserNameAndWrongPassword()
        {           
               Console.Write("Enter User name and Wrong password  ");
               loginPage.WrongLoginAttempt();
              
        }

        [Then(@"Login Failed")]
        public void ThenLoginFailed()
        {
            Console.Write("Invalid Credentials");
            Thread.Sleep(1000);
            Assert.IsTrue(loginPage.verifyMessage().Contains("Server"));
            Console.Write("Unable to login");
            //loginPage.RGOkButton2();
        }

        [Given("Logged Out")]
        public void LogOut()
        {
        }

        [When("I Login")]
        public void WhenILogin(Table data)
        {

        }
    }
}
