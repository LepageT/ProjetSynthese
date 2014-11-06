using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ApplyStudentPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("apply-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.ApplyStage3.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/Apply/3");
        }

        public static void ApplyStudent(string cv, string letter)
        {
            Driver.Instance.FindElement(By.Id("Cv")).SendKeys(cv);
            Driver.Instance.FindElement(By.Id("Letter")).SendKeys(letter);
            Driver.Instance.FindElement(By.Id("apply-button")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationApplyStudent-page")) != null; }
        }
    }
}