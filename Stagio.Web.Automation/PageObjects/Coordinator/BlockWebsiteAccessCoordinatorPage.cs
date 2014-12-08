using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class BlockWebsiteAccessCoordinatorPage
    {
        public static void ClickResultButton()
        {
            Driver.Instance.FindElement(By.Id("blockAccess-button")).Click();
        }

        public static void GoTo()
        {
            Navigation.Coordinator.BlockWebsiteAccess.Select();
        }

    }
}