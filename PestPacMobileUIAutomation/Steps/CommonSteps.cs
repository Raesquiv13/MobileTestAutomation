using NUnit.Framework;
using OpenQA.Selenium;
using System.Diagnostics;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using WorkWave.PestPac.Mobile.Model;
using RealGreen.MobileAutomation.Model;

using RealGreen.MobileAutomation.ShareData;
using WorkWave.TA.TestEngine;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading;

namespace RealGreen.MobileAutomation.Steps
{
    [Binding]
    public sealed class CommonSteps
    {
       
        RealGreenData realGreenData;
            
        public CommonSteps(RealGreenData realGreenData)
        {
            this.realGreenData = realGreenData;
        }

        #region BeforeAfter Runs

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //WebApplication.Instance.StartAppiumStudio();
            WebApplication.Instance.InitializeLogger();

            WebApplication.Instance.CreateNewDriver();
            WebApplication.Log.Info("Created Web Driver: " + WebApplication.Instance.WebDriver.GetType());

            // RealGreenMobile config
            RealGreenMobileSupport.InitializeRealGreenMobileConfig();  
        }

        

        [AfterTestRun]
        public static void AfterTestRun()
        {
            WebApplication.Instance.WebDriver.Quit();

            //WebApplication.Instance.QuitAppiumStudio();
        }

        [BeforeFeature]
        public static void LoginBefore()
        {
            RealGreenMobileSupport.SetFeature(FeatureContext.Current.FeatureInfo.Title);

            LoginPageView loginPage = new LoginPageView();
            //TimeSheetsView timeSheetsView = new TimeSheetsView();
           // DailyView dailyView = new DailyView();

            if (!RealGreenMobileSupport.GetFeature().Equals("Login"))
            {
                if (RealGreenMobileSupport.GetLoginStatus() == false)
                {
                    Thread.Sleep(5000);
                    try
                    {
                        if (loginPage.VerifyViewLoaded(20))
                        {
                            // loginPage.LoginAttempt(PestPacMobileSupport.DefaultEmail, PestPacMobileSupport.DefaultPassword); //Just a Test
                            loginPage.LoginAttempt("JM", "123");
                        }
                    }
                    /*   while (loginPage.ProgressBarVisible())
                       {
                           if (dailyView.VerifyViewLoaded(1))
                               break;
                       }
                   }

                   PestPacMobileSupport.Login();
                   PestPacMobileSupport.SetCurrentUser(PestPacMobileSupport.DefaultEmail);

                   if (PestPacMobileSupport.GetTimedInStatus().Equals("TimedOut"))
                   {
                       if (timeSheetsView.OrangeClockVisible(5))
                       {
                           try
                           {
                               timeSheetsView.TimeIn();
                           }
                           catch
                           {
                               timeSheetsView.Close();
                           }
                       }
                       else
                           PestPacMobileSupport.TimeInChange("TimedIn");
                   }

               }*/
                    catch
                    {
                        Console.Write("Object not identified");
                       //ReturnToDailyView();
                    }
                }
            }            
        }
      

        #endregion BeforeAfter Runs

        #region Given

        [Given("I am logged in")]
        public void GivenIAmLoggedIn()
        {
            if (!RealGreenMobileSupport.GetLoginStatus())
                Support_GivenIAmLoggedIn();
        }

        [Given("I am logged in")]
        public void GivenIAmLoggedIn(Table table)
        {
            if (!RealGreenMobileSupport.GetLoginStatus())
                Support_GivenIAmLoggedIn(table);
        }

        
        #endregion Given

        #region Support

        private void Support_GivenIAmLoggedIn(Table table = null)
        {
            LoginPageView loginPage = new LoginPageView();
            
            try
            {
                if (loginPage.VerifyViewLoaded(5))
                {
                    if (table != null)
                    {
                        Login login = table.CreateInstance<Login>();
                        loginPage.LoginAttempt(login.Email, login.Password);
                    }
                    else
                    {
                        loginPage.LoginAttempt(RealGreenMobileSupport.DefaultEmail, RealGreenMobileSupport.DefaultPassword);
                    }
                }

                while (loginPage.ProgressBarVisible())
                {
                    if (loginPage.verifyMessage().Contains("Be a blessing"))
                        break;
                }

                Assert.IsTrue(loginPage.verifyMessage().Contains("Be a blessing"));

                RealGreenMobileSupport.Login();
                if (realGreenData.Login != null)
                {
                    if (realGreenData.Login.Email != null)
                        RealGreenMobileSupport.SetCurrentUser(realGreenData.Login.Email);
                }
                else
                    RealGreenMobileSupport.SetCurrentUser(RealGreenMobileSupport.DefaultEmail);

                //if (RealGreenMobileSupport.GetTimedInStatus().Equals("TimedOut"))
                //{
                //    if (timeSheetsView.OrangeClockVisible(5))
                //    {
                //        try
                //        {
                //            timeSheetsView.TimeIn();
                //        }
                //        catch
                //        {
                //            timeSheetsView.Close();
                //        }
                //    }
                //    else
                //        RealGreenMobileSupport.TimeInChange("TimedIn");
                //}

            }
            catch
            {

            }
        }

             
        #endregion Support

       

        

       
    }
}
