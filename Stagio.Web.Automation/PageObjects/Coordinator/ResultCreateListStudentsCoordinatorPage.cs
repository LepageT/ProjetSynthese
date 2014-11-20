using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class ResultCreateListStudentsCoordinatorPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("resultCreateList-page")) != null; }
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/ResultCreateList");
        }

        public static void ClickResultButton()
        {
            Driver.Instance.FindElement(By.Id("resultCreateList-button")).Click();
        }

    }
}