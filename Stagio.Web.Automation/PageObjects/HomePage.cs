using System;
using Stagio.Web.Automation.Selenium;
using OpenQA.Selenium;

namespace Stagio.Web.Automation.PageObjects
{
    public class HomePage
    {
       
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("home-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.AllUsers.Home.Select();
        }
    }
}