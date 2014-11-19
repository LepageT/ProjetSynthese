using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Notification
{
    public class DetailNotificationPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("notification-detail")) != null; }
        }

        public static void GoToNotification(int i)
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Notification/Detail/" + i);
        }

        public static bool ErrorPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("erreur-notification")) != null; }
        }
    }
}