using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class EditInterviewPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("edit-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.EditInterview.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Interview/Edit?id=1");
        }
        
        public static void EditAnInterview(DateTime date, bool isPresent)
        {
            Driver.Instance.FindElement(By.Id("Date")).Clear();
            Driver.Instance.FindElement(By.Id("Date")).SendKeys(date.ToLongDateString());
            Driver.Instance.FindElement(By.Id("Present")).SendKeys(isPresent.ToString());
         
            Driver.Instance.FindElement(By.Id("edit-button")).Click();
        }

        public static bool EditVerification(DateTime date)
        {
            GoToByUrl();
            var dateDisplayed = Driver.Instance.FindElement(By.Id("Date")).GetAttribute("value");
            if (dateDisplayed == date.ToString())
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