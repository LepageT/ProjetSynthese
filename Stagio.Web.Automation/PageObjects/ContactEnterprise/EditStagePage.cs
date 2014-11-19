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
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Edit/1");
        }

        public static void EditAStage(string newResponsableName)
        {
           
            Driver.Instance.FindElement(By.Id("Password")).Clear();
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(newResponsableName);

            Driver.Instance.FindElement(By.Id("edit-button")).Click();
        }

        public static bool EditVerification(string newResponsableName)
        {
            throw new NotImplementedException();
        }
    }
}