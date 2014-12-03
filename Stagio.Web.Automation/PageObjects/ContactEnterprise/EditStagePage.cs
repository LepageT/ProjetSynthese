using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class EditStagePage
    {
        public static void GoToByUrl()
        {
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Stage/Edit/1");
        }

        public static void EditAStage(string newResponsableName)
        {

            Driver.Instance.FindElement(By.Id("ResponsableToName")).Clear();
            Driver.Instance.FindElement(By.Id("ResponsableToName")).SendKeys(newResponsableName);

            Driver.Instance.FindElement(By.Id("edit-button")).Click();
        }

        public static bool EditVerification(string newResponsableName)
        {
            GoToByUrl();
          
            var responsableNameDisplayed = Driver.Instance.FindElement(By.Id("ResponsableToName")).GetAttribute("value");
            if (responsableNameDisplayed == newResponsableName)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}