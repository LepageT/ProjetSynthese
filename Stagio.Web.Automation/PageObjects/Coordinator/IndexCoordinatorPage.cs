using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class IndexCoordinatorPage
    {
        /*public static bool IsDisplayed
        {
            
        }*/

        public static void Goto()
        {
            Navigation.Coordinator.Index.Select();
        }

        public static bool IsNotificationShowing
        {
            get { return Driver.Instance.FindElement(By.Id("notification-detail5")) != null; }
        }
    }
}