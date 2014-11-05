using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;
using OpenQA.Selenium.Support.UI;




namespace Stagio.Web.Automation.PageObjects.Student
{
    public class CreateInterviewStudentPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("interview-add")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.AddInterview.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Interview/Create");
        }

        public static void AddInterview()
        {
            const string DATE = "2014-12-21";

            IWebElement oSelection = Driver.Instance.FindElement(By.Id("StageId"));
            SelectElement dropdown = new SelectElement(oSelection);
            dropdown.SelectByIndex(1);

            Driver.Instance.FindElement(By.Id("Date")).Clear();
            Driver.Instance.FindElement(By.Id("Date")).SendKeys(DATE);
            Driver.Instance.FindElement(By.Id("create-interview")).Click();
        }

        public static bool ConfirmationIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("interview-confirmation")) != null; }
        }
    }
}