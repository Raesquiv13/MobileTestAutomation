using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.PageObjects.Attributes;
using WorkWave.TA.TestEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;

namespace RealGreen.MobileAutomation.Model
{
    abstract class BasePage
    {
        protected IWebDriver driver;
        private WebDriverWait wait;
        private int timeOut, staticTimeout;

        protected BasePage(IWebDriver driver, int timeOut = 30, int staticTimeout = 10)
        {
            this.driver = driver;
            this.timeOut = timeOut;
            this.staticTimeout = staticTimeout;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(this.timeOut));
        }

        public abstract bool verifyPageLoads();

        protected IWebElement findElement(By elementKey)
        {
            try
            {
                return this.wait.Until(presenceOfElementLocated(elementKey));
            }
            catch (Exception e)
            {
                //String name = ExceptionManager.parseException(e);
                //ExceptionManager.handleExeption(e, "[ERROR] There was a problem finding element " + name
                // + ". It may not be available");
                return null;
            }
        }

        protected bool waitForElementVisible(IWebElement element)
        {
            try
            {
                return SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(element), System.TimeSpan.FromSeconds(timeOut));
            }
            catch (Exception e)
            {
                // String name = ExceptionManager.parseException(e);
                //ExceptionManager.handleExeption(e, "[ERROR] There was a problem waiting for element " + name
                // + " to be visible. It may not be available");
                return false;
            }
        }

        protected bool waitAndClick(IWebElement element)
        {
            try
            {
                waitForElementVisible(element);
                this.wait.Until(CustomExpectedConditions.ElementIsEnabled(element));
                element.Click();
                return true;
            }
            catch (Exception e)
            {
                //String name = ExceptionManager.parseException(e);
                //ExceptionManager.handleExeption(e, "[ERROR] There was a problem waiting for element " + name
                //+ " to be clickable. It may not be available");
                return false;
            }
        }

        protected bool waitAndTypeOnCleanElement(IWebElement element, string text)
        {
            try
            {
                waitForElementVisible(element);
                this.wait.Until(CustomExpectedConditions.ElementIsEnabled(element));
                element.Clear();
                return typeOnElement(element, text);
            }
            catch (Exception e)
            {
                //String name = ExceptionManager.parseException(e);
                //ExceptionManager.handleExeption(e, "[ERROR]  Cannot type the desired text on element " + name
                //+ ". It may not be available");
                return false;
            }
        }

        private bool typeOnElement(IWebElement element, String txt)
        {
            element.SendKeys(txt);
            return element.TagName.Equals("input") ? waitForAttributeOnElementToBe(element, "value", txt) : true;
        }


        protected bool waitForAttributeOnElementToBe(IWebElement element, String attribute, String value)
        {
            try
            {
                return this.wait.Until(attributeOnElement(element, attribute, value));

            }
            catch (Exception e)
            {
                //String name = ExceptionManager.parseException(e);
                //ExceptionManager.handleExeption(e, "");
                return false;
            }
        }





        //SPECIAL FUNCIONS-------------------------------------------------->>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        private static Func<IWebDriver, IWebElement> presenceOfElementLocated(By locator)
        {
            return driver =>
            {
                try
                {
                    return driver.FindElement(locator);
                }
                catch (Exception)
                {
                    return null;
                }
            };
        }


        private static Func<IWebDriver, bool> attributeOnElement(IWebElement element, String attribute, String value)
        {
            return driver =>
            {
                try
                {
                    return element.GetAttribute(attribute).Equals(value);
                }
                catch (Exception)
                {
                    return false;
                }
            };
        }


    }
}
