using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class InviteContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("inviteContact-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.ContactEnterprise.InviteContactEnterprise.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/InviteContactEnterprise");
        }

        public static void InviteContactEnterprise()
        {
            
        }
    }
}