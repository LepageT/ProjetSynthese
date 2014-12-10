using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class CreateCoordinatorPage
    {
        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Create?token=123456");
        }

        public static void FillFieldsAndSend(string firstName, string lastName, string email, string password)
        {
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(firstName);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(lastName);
            Driver.Instance.FindElement(By.Id("Email")).Clear();
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(email);
            Driver.Instance.FindElement(By.Id("ConfirmEmail")).SendKeys(email);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(password);
            Driver.Instance.FindElement(By.Id("ConfirmedPassword")).SendKeys(password);
            Driver.Instance.FindElement(By.Id("btn-create")).Click();
        }


        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationCreateCoordinator-page")) != null; }
        }
    }
}