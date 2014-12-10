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
        public static void ClickResultButton()
        {
            Driver.Instance.FindElement(By.Id("resultCreateList-button")).Click();
        }

    }
}