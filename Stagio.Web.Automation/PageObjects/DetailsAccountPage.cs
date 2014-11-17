using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects
{
    public class DetailsAccountPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("details-user-page")) != null; }
        }

        public static void GoToByUrl1()
        {

            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Account/Details/1");
        }
    }
}