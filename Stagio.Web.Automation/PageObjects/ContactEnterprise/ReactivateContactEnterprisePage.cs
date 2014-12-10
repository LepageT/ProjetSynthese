using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;


namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class ReactivateContactEnterprisePage
    {
        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Reactivate?token=123456");
        }

        public static void FillFieldsAndSend(string email, string password, string firstName, string lastName, string enterpriseName, string telephone)
        {
            Driver.Instance.FindElement(By.Id("Email")).Clear();
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(email);
            Driver.Instance.FindElement(By.Id("ConfirmEmail")).SendKeys(email);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(password);
            Driver.Instance.FindElement(By.Id("PasswordConfirmation")).SendKeys(password);
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(firstName);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(lastName);
            Driver.Instance.FindElement(By.Id("EnterpriseName")).SendKeys(enterpriseName);
            Driver.Instance.FindElement(By.Id("Telephone")).SendKeys(telephone);
            Driver.Instance.FindElement(By.Id("create-button")).Click();
        }

        public static bool ConfirmationIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationCreateContact-page")) != null; }
        }
    }
}