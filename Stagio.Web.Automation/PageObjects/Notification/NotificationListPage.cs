using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Notification
{
    public class NotificationListPage
    {
        public static void GoTo()
        {
           Navigation.AllUsers.Notification.Select();
        }

        public static void GoToNotification(int id)
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Notification/Detail/" + id);
        }

        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("list-notification")) != null; }
        }

        public static bool IsDetailDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("notification-detail")) != null; }
        }

    }
}