using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WorkWave.TA.TestEngine;
using System;


    namespace RealGreen.MobileAutomation.Model
{
    class LoginPageView : BasePage
    {
        #region Page Factory
        //New 2.0
        [FindsBy(How = How.XPath, Using = "//*[@id='companyLogo']")]
        private IWebElement companyLogoImage { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.EditText' and ./parent::*[./parent::*[@id='companyTextBox']]]")]
        private IWebElement companyIdTexbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.EditText' and ./parent::*[./parent::*[@id='emailTextbox']]]")]
        private IWebElement employeeIdTexbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='passwordEditText']")]
        private IWebElement passwordTexbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@id='loginButton']")]
        private IWebElement loginButton { get; set; }
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement termsUseLink { get; set; }
        [FindsBy(How = How.XPath, Using = "")]
        private IWebElement privacyPolicyLink { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='Login Message']")]
        private IWebElement loginMesage { get; set; }
        [FindsBy(How = How.XPath, Using = "//*[@text='OK']")]
        private IWebElement okButton { get; set; }




        // New

        [FindsBy(How = How.XPath, Using = "//*[@contentDescription='txtUserName']")]
        private IWebElement UserNameRealGreen { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@contentDescription='txtPwd']")]
        private IWebElement PasswordRealGreen { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='Login']")]
        private IWebElement LoginRealGreen { get; set; }
        //
        [FindsBy(How = How.XPath, Using = "//*[@class='android.widget.FrameLayout' and ./*[@class='android.view.ViewGroup' and ./*[@text='Employee ID:']]]")]
        public IWebElement employeIdFrameLayout { get; set; }


        [FindsBy(How = How.XPath, Using = "//*[@text='Ok']")]
        public IWebElement OkRealGreen { get; set; }

        [FindsBy(How = How.Id, Using = "button1")]
        public IWebElement OkRealGreen2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='Unable to login! User login validation failed.'")]
        public IWebElement FailedMessage { get; set; }

        [FindsBy(How = How.Id, Using = "errorText")]
        private IWebElement MessageRealGreen { get; set; }

        // Old
        [FindsBy(How = How.Id, Using = "emailTextbox")]
        private IWebElement EmailTextBox { get; set; }

        [FindsBy(How = How.Id, Using = "passwordTextbox")]
        private IWebElement PasswordTextbox { get; set; }

        [FindsBy(How = How.Id, Using = "loginButton")]
        private IWebElement LoginButton { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        private IWebElement ErrorMessage { get; set; }

        //*[@class='android.widget.Button']
        [FindsBy(How = How.ClassName, Using = "android.widget.ProgressBar")]
        private IWebElement ProgressBar { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@text='Invalid email or password. Too many failed attempts may result in a temporary lockout.']")]
        private IWebElement InvalidEmailPassError { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "You have entered an incorrect password.")]
        private IWebElement InvalidPasswordError1 { get; set; }

        [FindsBy(How = How.PartialLinkText, Using = "until next allowed login")]
        private IWebElement InvalidPasswordError2 { get; set; }

        #endregion Page Factory

        #region Page Factory Setup

        public LoginPageView(IWebDriver driver):base(driver)
        {
            PageFactory.InitElements(driver, this);
        }

        #endregion Page Factory Setup

        #region Behavior

        public override bool verifyPageLoads()
        {
            return waitForElementVisible(companyLogoImage);
        }

        
        public void loginUser(string companyId, string username, string password)
        {
            if (verifyPageLoads())
            {
                waitAndTypeOnCleanElement(companyIdTexbox, companyId);
                waitAndTypeOnCleanElement(employeeIdTexbox,username);
                waitAndTypeOnCleanElement(passwordTexbox,password);
            }
            waitAndClick(loginButton);
            waitAndClick(okButton);
        }
        
        //New

        public bool RGUserNameTextBoxVisible() => EmailTextBox.Displayed; 

        public void ClearRGUserName() => EmailTextBox.Clear();

        //  public void EnterRGUserName(string email) => UserNameRealGreen.SendKeys("rstJohn");

        public bool RGPasswordTextBoxVisible() => passwordTexbox.Displayed;
        public bool LoginMessageVisible() => loginMesage.Displayed;
        public void ClearRGPassword() => passwordTexbox.Clear();

        public bool  CompanyIdTextBoxVisible() => companyIdTexbox.Displayed;
        public void ClearCompanyId() => companyIdTexbox.Clear();

        public bool FailedMessageVisible() => FailedMessage.Displayed;

        //public void EnterRGPassword(string email) => PasswordRealGreen.SendKeys("123");

        public void RGLogin() => loginButton.Click();

        public void RGOkButton() => OkRealGreen.Click();
        public void RGOkButton2() => OkRealGreen2.Click();

        public void ClikOkButton() {
            SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(okButton), System.TimeSpan.FromSeconds(30));
            okButton.Click();
        }

        public string verifyMessage()
        {
           string message1 = MessageRealGreen.Text;
            Console.Write(message1);
            return message1;

        }
     
        public bool VerifyViewLoaded(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(companyLogoImage), System.TimeSpan.FromSeconds(time));
        public bool VerifyElement(int time, IWebElement element) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(element), System.TimeSpan.FromSeconds(time));

        public bool VerifyHomePageWindowLoaded(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(OkRealGreen), System.TimeSpan.FromSeconds(time));
        // old
        // public bool VerifyViewLoaded(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(EmailTextBox), System.TimeSpan.FromSeconds(time));

        public bool EmailTextBoxVisible() => UserNameRealGreen.Displayed;

        public void ClearEmail() => UserNameRealGreen.Clear();

        public void EnterEmail(string email) => UserNameRealGreen.SendKeys(email);

        public void ClearPassword() => PasswordRealGreen.Clear();

        public void EnterPassword(string pass) => PasswordRealGreen.SendKeys(pass);

        public void Login() => LoginRealGreen.Click();

        public bool ErrorMessageVisible(int time, string msg)
        {
            switch (msg)
            {
                case "Invalid Credentials":
                    return SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(InvalidEmailPassError), System.TimeSpan.FromSeconds(time));
                case "Lockout":
                    return SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(InvalidPasswordError1), System.TimeSpan.FromSeconds(time)) || SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(InvalidPasswordError2), System.TimeSpan.FromSeconds(time));
            }
            return false;
            
        }

        public string ErrorMessageText() => ErrorMessage.Text;

        public bool ProgressBarVisible()
        {
            if (RealGreenMobileSupport.IsDisplayed(ProgressBar))
                return true;
            return false;
        }

        #endregion Behavior

        #region Behavior Support
        //New
        public void RGLoginAttempt()
        {
            if (VerifyViewLoaded(1000))
            {
                ClearCompanyId();
                companyIdTexbox.SendKeys("889565");
                ClearRGUserName();
                employeeIdTexbox.SendKeys("JM");

                ClearRGPassword();
                passwordTexbox.SendKeys("123");
            }

            RGLogin();
            ClikOkButton();

        }
        public void WrongLoginAttempt()
        {
            if (VerifyViewLoaded(1000))
            {
                ClearCompanyId();
                companyIdTexbox.SendKeys("889565");
                ClearRGUserName();
                employeeIdTexbox.SendKeys("JM");
               

                ClearRGPassword();
                passwordTexbox.SendKeys("12");
            }

            RGLogin();
        }
            //Old
            public void LoginAttempt(string email, string pass)
        {
            /*
             * VerifyViewLoaded() is present to make sure the test does not begin
             * before the login page is accessible
             */
            VerifyViewLoaded(35);

            UserNameRealGreen.Click();
            ClearEmail();
            EnterEmail(email);
            PasswordRealGreen.Click();
            ClearPassword();
            EnterPassword(pass);
            RealGreenMobileSupport.HideKeyboard();
            Login();
            VerifyHomePageWindowLoaded(25);
            RGOkButton();

       }

        #endregion Behavior Support
    }
}
