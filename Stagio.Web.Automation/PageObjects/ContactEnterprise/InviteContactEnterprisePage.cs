using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class InviteContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("inviteContact-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.ContactEnterprise.InviteContactEnterprise.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/InviteContactEnterprise");
        }

        public static void InviteContactEnterprise()
        {
            const string MESSAGE_INVITATION = "test";
            const string EMAIL = "test@test.com";
            const string FIRST_NAME = "Bob";
            const string LAST_NAME = "Bobby";
            const string TELEPHONE = "111-111-1111";
            Driver.Instance.FindElement(By.Id("Message")).SendKeys(MESSAGE_INVITATION);
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(EMAIL);
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(FIRST_NAME);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(LAST_NAME);
            Driver.Instance.FindElement(By.Id("Telephone")).SendKeys(TELEPHONE);
            
        }

        public static void SendInvite()
        {
            Driver.Instance.FindElement(By.Id("send-button")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationInvitationContact-page")) != null; }
        }
    }
}