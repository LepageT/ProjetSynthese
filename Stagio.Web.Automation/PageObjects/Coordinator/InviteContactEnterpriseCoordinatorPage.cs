using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class InviteContactEnterpriseCoordinatorPage
    {
        public static void GoTo()
        {
            Navigation.Coordinator.InviteContactEnterprise.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/InviteContactEnterprise");
        }

        public static void AddMessageInvitationAndSend(string messageInvitation)
        {
            Driver.Instance.FindElement(By.Id("Message")).SendKeys(messageInvitation);
            Driver.Instance.FindElement(By.Id("send-button")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationInvitationContact-page")) != null; }
        }
    }
}