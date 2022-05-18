using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using RealGreen.MobileAutomation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using WorkWave.TA.TestEngine;

namespace WorkWave.PestPac.Mobile.Model
{
    abstract class GenericPageModel
    {

        #region Page Factory

        [FindsBy(How = How.Id, Using = "Save")]
        public IWebElement SaveButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.widget.ProgressBar")]
        public IWebElement ProgressBar { get; set; }

        [FindsBy(How = How.Id, Using = "alertTitle")]
        public IWebElement AlertPopup { get; set; }

        [FindsBy(How = How.Id, Using = "message")]
        public IWebElement MessagePopup { get; set; }

        [FindsBy(How = How.Id, Using = "button1")]
        private IWebElement PositiveButton { get; set; }

        [FindsBy(How = How.Id, Using = "button2")]
        private IWebElement NegativeButton { get; set; }

        [FindsBy(How = How.ClassName, Using = "android.widget.ListView")]
        public IWebElement DropDownView { get; set; }


        #endregion

        #region Page Factory Setup

        public GenericPageModel() => InitializePageFactoryElements();

        public void InitializePageFactoryElements() => PageFactory.InitElements(WebApplication.Instance.WebDriver, this);

        public abstract bool VerifyViewLoaded(int time);

        public abstract bool VerifyViewLoaded();

        #endregion Page Factory Setup

        #region Behavior

        public bool MessagePopupVisible(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(MessagePopup), TimeSpan.FromSeconds(time));

        public bool VerifyDropdownOpen(int time)
        {
            if (SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(DropDownView), System.TimeSpan.FromSeconds(time)))
                return true;
            return false;
        }

        public void Save() => SaveButton.Click();

        public void AffirmativeClick() => PositiveButton.Click();

        public void NegativeClick() => NegativeButton.Click();

        public void EnterText(string text, IWebElement field)
        {
            field.Click();
            if (!field.GetAttribute("text").Equals(""))
                field.Clear();
            field.SendKeys(text);
            RealGreenMobileSupport.HideKeyboard();
        }

        public string GetAlertPopupText() => MessagePopup.GetAttribute("text");

        public bool getCheckedStatus(IWebElement button)
        {
            if (button.GetAttribute("checked").Equals("true"))
                return true;
            return false;
        }

        public bool ProgressBarVisible(int time)
        {
            try
            {
                return SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(ProgressBar), TimeSpan.FromSeconds(time));
            }
            catch
            {
                return ProgressBar.Displayed;
            }
        }

        public bool AlertPopupVisible(int time) => SeleniumUtility.WaitFor(CustomExpectedConditions.ElementIsVisible(AlertPopup), TimeSpan.FromSeconds(time));

        public void BackOutToPage(int time)
        {
            while (!VerifyViewLoaded(time))
                RealGreenMobileSupport.GoBackApp();
        }
        /// <summary>
        /// This is a fast way of finding an item in a list where the ID of the list entries is "Title" since
        /// this is typically the default id used for list entries.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public IWebElement findGenericListItem(string name)
        {
            return findListElement(name, "Title", "id");
        }
        #endregion Behavior

        #region Behavior Support

        public IWebElement findElementGivenByType(string id, string byType)
        {
            IWebElement elem = null;
            switch (byType)
            {
                case "xpath":
                    elem = WebApplication.Instance.WebDriver.FindElement(By.XPath(id));
                    break;
                case "id":
                    elem = WebApplication.Instance.WebDriver.FindElement(By.Id(id));
                    break;
                case "class":
                    elem = WebApplication.Instance.WebDriver.FindElement(By.ClassName(id));
                    break;
            }
            return elem;
        }

        public IWebElement findElementGivenByType(string id, string byType, IWebElement container)
        {
            IWebElement elem = null;
            switch (byType)
            {
                case "xpath":
                    elem = container.FindElement(By.XPath(id));
                    break;
                case "id":
                    elem = container.FindElement(By.Id(id));
                    break;
                case "class":
                    elem = container.FindElement(By.ClassName(id));
                    break;
            }
            return elem;
        }

        public IList<IWebElement> findElementsGivenByType(string id, string byType)
        {
            IList<IWebElement> elems = null;
            switch (byType)
            {
                case "xpath":
                    elems = WebApplication.Instance.WebDriver.FindElements(By.XPath(id));
                    break;
                case "id":
                    elems = WebApplication.Instance.WebDriver.FindElements(By.Id(id));
                    break;
                case "class":
                    elems = WebApplication.Instance.WebDriver.FindElements(By.ClassName(id));
                    break;
            }
            return elems;
        }

        public IWebElement FindDropdownElement(string type)
        {

            IList<IWebElement> allTypes = WebApplication.Instance.WebDriver.FindElements(By.Id("text1"));
            int index = 1;
            IWebElement currType = null;
            string prevType = "";
            while (index < allTypes.Count + 1)
            {
                try
                {
                    currType = allTypes[index - 1];

                    if (index == allTypes.Count && prevType.Equals(currType.GetAttribute("text")))
                        break;

                    if (currType.GetAttribute("text").Equals(type))
                        return currType;

                    if (index == allTypes.Count)
                    {
                        prevType = currType.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(DropDownView.Location.X + DropDownView.Size.Width / 2, DropDownView.Location.Y + DropDownView.Size.Height - 1, DropDownView.Location.X + DropDownView.Size.Width / 2, DropDownView.Location.Y);
                        allTypes = WebApplication.Instance.WebDriver.FindElements(By.Id("text1"));
                        index = 1;
                    }
                    else
                        index++;
                }
                catch
                {
                    break;
                }

            }

            return null;
        }

        /// <summary>
        /// Find an element with a specific text attribute in a list of elements with a given id.
        /// </summary>
        /// <param name="name"> Name of the element to be found in the list</param>
        /// <param name="id"> identifier for the elements in the list being searched</param>
        /// <param name="byType"> By type used to find the id (id, xpath, class)</param>
        /// <returns></returns>
        public IWebElement findListElement(string name, string id, string byType)
        {
            int index = 1;
            IWebElement currElem = null;
            IList<IWebElement> allElements = null;
            string prevLastFoundElem = "";
            try
            {
                allElements = findElementsGivenByType(id, byType);                
            }
            catch
            {
                return null;
            }

            if (allElements.Count == 0)
                return null;

            if (name.Equals("") || name.Equals("ANY"))
                return allElements[index - 1];

            while (index < allElements.Count + 1)
            {
                try
                {
                    currElem = allElements[index - 1];

                    if (index == allElements.Count && prevLastFoundElem.Equals(currElem.GetAttribute("text")))
                        break;

                    if (currElem.GetAttribute("text").Equals(name))
                        return currElem;

                    if (index == allElements.Count)
                    {
                        prevLastFoundElem = currElem.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(-1139);
                        allElements = findElementsGivenByType(id, byType);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Find an element with a specific text attribute in a list of elements with a given id. Use this method
        /// specifically when there is an irregular recycler view that needs to be swiped through according to its
        /// dimensions.
        /// </summary>
        /// <param name="name"> Name of the element to be found in the list</param>
        /// <param name="id"> identifier for the elements in the list being searched</param>
        /// <param name="byType"> By type used to find the id (id, xpath, class)</param>
        /// <param name="rv"> recyclerview that contains the list being cycled through
        /// <returns></returns>
        public IWebElement findListElement(string name, string id, string byType, IWebElement rv)
        {
            int index = 1;
            IWebElement currElem = null;
            IList<IWebElement> allElements = null;
            string prevLastFoundElem = "";
            try
            {
                allElements = findElementsGivenByType(id, byType);
            }
            catch
            {
                return null;
            }

            if (allElements.Count == 0)
                return null;

            if (name.Equals(""))
                return allElements[index - 1];

            while (index < allElements.Count + 1)
            {
                try
                {
                    currElem = allElements[index - 1];

                    if (index == allElements.Count && prevLastFoundElem.Equals(currElem.GetAttribute("text")))
                        break;

                    if (currElem.GetAttribute("text").Equals(name))
                        return currElem;

                    if (index == allElements.Count)
                    {
                        prevLastFoundElem = currElem.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(rv.Location.X+rv.Size.Width/2, rv.Location.Y + rv.Size.Height-1, rv.Location.X+rv.Size.Width / 2, rv.Location.Y+1);
                        allElements = findElementsGivenByType(id, byType);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Find an element with two specific text attributes in a list of elements matching an id and sub-id.
        /// </summary>
        /// <param name="name1"> Text attribute to find using id1 </param>
        /// <param name="name2"> Text attribute to find using id2 </param>
        /// <param name="id1"> id of elements in the list to be parsed </param>
        /// <param name="id2"> element found within id1 in the list to validate against name2</param>
        /// <returns></returns>
        public IWebElement findListElement(string name1, string name2, string id1, string id2, string byType1, string byType2)
        {
            int index = 1;
            IWebElement currElem = null;
            IList<IWebElement> allElements1 = null;
            string prevLastFoundElem = "";
            try
            {
                allElements1 = findElementsGivenByType(id1, byType1);
            }
            catch
            {
                return null;
            }

            while (index < allElements1.Count + 1)
            {
                try
                {
                    currElem = allElements1[index - 1];

                    if (index == allElements1.Count && prevLastFoundElem.Equals(currElem.GetAttribute("text")))
                        break;

                    if (currElem.GetAttribute("text").Equals(name1))
                    {
                        IWebElement subElement = null;
                        subElement = findElementGivenByType(id2, byType2, currElem);
                        if (subElement.GetAttribute("text").Equals(name2))
                            return currElem;
                        
                    }

                    if (index == allElements1.Count)
                    {
                        prevLastFoundElem = currElem.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(-1139);
                        allElements1 = findElementsGivenByType(id1, byType1);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return currElem;
        }

        /// <summary>
        /// Find an element within a container in a list.
        /// </summary>
        /// <param name="name"> Field to match </param>
        /// <param name="container"> ID of the container element from which element with id can be found </param>
        /// <param name="id"> ID of the element to compare to name </param>
        /// <param name="containerByType"> Find By type for the containers in the list </param>
        /// <param name="byType"> Find by type for the element found with id </param>
        /// <returns></returns>
        public IWebElement findListElement(string name, string container, string id, string containerByType, string byType)
        {
            int index = 1;
            IWebElement currElem = null;
            IList<IWebElement> allElements = null;
            string prevLastFoundElem = "";
            try
            {
                allElements = findElementsGivenByType(container, containerByType);
            }
            catch
            {
                return null;
            }

            while (index < allElements.Count + 1)
            {
                try
                {
                    currElem = findElementGivenByType(id, byType, allElements[index - 1]);

                    if (index == allElements.Count && prevLastFoundElem.Equals(currElem.GetAttribute("text")))
                        break;

                    if (currElem.GetAttribute("text").Equals(name))
                        return currElem;

                    if (index == allElements.Count)
                    {
                        prevLastFoundElem = currElem.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(-1139);
                        allElements = findElementsGivenByType(container, containerByType);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Find an the container for a given element in a list. This is useful when verifying multiple elements
        /// within the same container.
        /// </summary>
        /// <param name="name"></param> Text attribute to find within the container
        /// <param name="container"></param> Identifier for the containers holding entries in the list
        /// <param name="id"></param> Identifier for the text attribute in the container
        /// <param name="containerByType"></param> By type for the container's identifier
        /// <param name="byType"></param> By type for the text attribute's identifier
        /// <returns></returns>
        public IWebElement findListElementContainer(string name, string container, string id, string containerByType, string byType)
        {
            int index = 1;
            IWebElement currElem = null;
            IList<IWebElement> allElements = null;
            string prevLastFoundElem = "";
            try
            {
                allElements = findElementsGivenByType(container, containerByType);
                if (allElements.Count == 0)
                    return null;
            }
            catch
            {
                return null;
            }

            if (name.Equals("") || name.Equals("ANY"))
                return allElements[index - 1];

            while (index < allElements.Count + 1)
            {
                try
                {
                    currElem = findElementGivenByType(id, byType, allElements[index - 1]);

                    if (index == allElements.Count && prevLastFoundElem.Equals(currElem.GetAttribute("text")))
                        break;

                    if (currElem.GetAttribute("text").Equals(name))
                        return allElements[index-1];

                    if (index == allElements.Count)
                    {
                        prevLastFoundElem = currElem.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(-1139);
                        allElements = findElementsGivenByType(container, containerByType);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Find an the container for a given element in a list. This is useful when verifying multiple elements
        /// within the same container. Use this method when there is an irregular recyclerview.
        /// </summary>
        /// <param name="name"></param> Text attribute to find within the container
        /// <param name="container"></param> Identifier for the containers holding entries in the list
        /// <param name="id"></param> Identifier for the text attribute in the container
        /// <param name="containerByType"></param> By type for the container's identifier
        /// <param name="byType"></param> By type for the text attribute's identifier
        /// <param name="rv"></param> Recyclerview containing the containers being searched through.
        /// <returns></returns>
        public IWebElement findListElementContainer(string name, string container, string id, string containerByType, string byType, IWebElement rv)
        {
            int index = 1;
            IWebElement currElem = null;
            IList<IWebElement> allElements = null;
            string prevLastFoundElem = "";
            try
            {
                allElements = findElementsGivenByType(container, containerByType);
                if (allElements.Count == 0)
                    return null;
            }
            catch
            {
                return null;
            }

            if (name.Equals(""))
                return allElements[index - 1];

            while (index < allElements.Count + 1)
            {
                try
                {
                    currElem = findElementGivenByType(id, byType, allElements[index - 1]);

                    if (index == allElements.Count && prevLastFoundElem.Equals(currElem.GetAttribute("text")))
                        break;

                    if (currElem.GetAttribute("text").Equals(name))
                        return allElements[index - 1];

                    if (index == allElements.Count)
                    {
                        prevLastFoundElem = currElem.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(rv.Location.X, rv.Location.Y + rv.Size.Height, rv.Location.X, rv.Location.Y);
                        allElements = findElementsGivenByType(container, containerByType);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return null;
        }

        /// <summary>
        /// Find a container entry that holds two specific elements
        /// </summary>
        /// <param name="name1"> First field to match </param>
        /// <param name="name2"> Second field to match </param>
        /// <param name="containerID"> ID for the containers that make up the list being parsed </param>
        /// <param name="name1ID"> ID the element to compare to name1 </param>
        /// <param name="name2ID"> ID the element to compare to name2 </param>
        /// <param name="containerByType"> Find By type for the containers in the list </param>
        /// <param name="name1ByType"> Find by type for the element found with id1 </param>
        /// <param name="name2ByType"> Find by type for the element foudn with id2 </param>
        /// <returns></returns>
        public IWebElement findListElementsContainer(string name1, string name2, string containerID, string name1ID, string name2ID, string containerByType, string name1ByType, string name2ByType)
        {
            int index = 1;
            IWebElement currElem1 = null;
            IWebElement currElem2 = null;
            IList<IWebElement> allElements = null;
            string prevLastFoundElem1 = "";
            string prevLastFoundElem2 = "";

            try
            {
                allElements = findElementsGivenByType(containerID, containerByType);
            }
            catch
            {
                return null;
            }

            if (allElements.Count == 0)
            {
                return null;
            }
            else if ((name1.Equals("") || name1.Equals("ANY")) && (name2.Equals("") || name2.Equals("ANY")))
                return allElements[index - 1];

            while (index < allElements.Count + 1)
            {
                try
                {
                    currElem1 = findElementGivenByType(name1ID, name1ByType, allElements[index - 1]);
                    currElem2 = findElementGivenByType(name2ID, name2ByType, allElements[index - 1]);

                    Debug.WriteLine(currElem1.GetAttribute("text") + ":" + name1);
                    Debug.WriteLine(currElem2.GetAttribute("text") + ":" + name2);

                    if (index == allElements.Count && prevLastFoundElem1.Equals(currElem1.GetAttribute("text")) && prevLastFoundElem2.Equals(currElem2.GetAttribute("text")))
                        break;

                    if (currElem1.GetAttribute("text").Contains(name1) && currElem2.GetAttribute("text").Contains(name2))
                        return allElements[index - 1];
                    else if (name1.Equals("ANY") && currElem2.GetAttribute("text").Contains(name2))
                        return allElements[index - 1];
                    else if (currElem1.GetAttribute("text").Contains(name1) && name2.Equals("ANY"))
                        return allElements[index - 1];

                    if (index == allElements.Count)
                    {
                        prevLastFoundElem1 = currElem1.GetAttribute("text");
                        prevLastFoundElem2 = currElem2.GetAttribute("text");
                        RealGreenMobileSupport.Swipe(-1139);
                        allElements = findElementsGivenByType(containerID, containerByType);
                        index = 1;
                    }
                    else
                        index++;

                }
                catch
                {
                    break;
                }
            }

            return null;
        }

        #endregion Behavior Support

    }
}
