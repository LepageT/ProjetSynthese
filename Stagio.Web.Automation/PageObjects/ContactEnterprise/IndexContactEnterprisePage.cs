using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class IndexContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("contact-index-page")) != null; }

        }

        public static void Goto()
        {
            Navigation.ContactEnterprise.Index.Select();
        }

        public static bool IsNotificationShowing
        {
            get { return Driver.Instance.FindElement(By.Id("notification-detail4")) != null; }
        }
    }
}