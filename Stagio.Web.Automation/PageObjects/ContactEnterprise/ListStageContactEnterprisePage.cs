using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class ListStageContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("list-stage")) != null; }
        }

        public static void GoTo()
        {
            Navigation.ContactEnterprise.ListStages.Select();
        }

        public static bool AccessStageDetail()
        {
            try
            {
                Driver.Instance.FindElement(By.Id("list-stages1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}