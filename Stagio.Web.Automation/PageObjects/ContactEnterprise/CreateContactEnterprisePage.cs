using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class CreateContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("create-page")) != null; }
        }


        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Reactivate");
        }

        public static void CreateContactEnterpriseWithoutInvitation()
        {
            const string EMAIL = "blabla@blabla.com";
            const string FIRST_NAME = "Bill";
            const string LAST_NAME = "Gates";
            const string ENTERPRISE = "Microsost";
            const string TELEPHONE = "111-111-1111";
            const string PASSWORD = "asdfgh12";
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(EMAIL);
            Driver.Instance.FindElement(By.Id("ConfirmEmail")).SendKeys(EMAIL);
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            Driver.Instance.FindElement(By.Id("EnterpriseName")).SendKeys(ENTERPRISE);
            Driver.Instance.FindElement(By.Id("Telephone")).SendKeys(TELEPHONE);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(PASSWORD);
            Driver.Instance.FindElement(By.Id("PasswordConfirmation")).SendKeys(PASSWORD);
            Driver.Instance.FindElement(By.Id("create-button")).Click();
        }

        public static void CreateContactEnterpriseWithInvitation()
        {
            const string FIRST_NAME = "Bill";
            const string LAST_NAME = "Gates";
            const string TELEPHONE = "111-111-1111";
            const string PASSWORD = "asdfgh12";
            const string EMAIL = "thomarelau@hotmail.com";
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Reactivate?Email=thomarelau@hotmail.com&EnterpriseName=test");
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            Driver.Instance.FindElement(By.Id("ConfirmEmail")).SendKeys(EMAIL);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            Driver.Instance.FindElement(By.Id("Telephone")).SendKeys(TELEPHONE);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(PASSWORD);
            Driver.Instance.FindElement(By.Id("PasswordConfirmation")).SendKeys(PASSWORD);
            Driver.Instance.FindElement(By.Id("create-button")).Click();
        }

        public static bool ConfirmationIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationCreateContact-page")) != null; }
        }
    }
}