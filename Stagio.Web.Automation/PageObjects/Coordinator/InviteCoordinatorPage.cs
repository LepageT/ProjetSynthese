using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class InviteCoordinatorPage
    {
        public static void GoTo()
        {
            Navigation.Coordinator.InviteCoordinator.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Invite");
        }

        public static void SendInvitation(string email, string invitationText)
        {
            Driver.Instance.FindElement(By.Id("Email")).Clear();
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(email);
            Driver.Instance.FindElement(By.Id("Message")).Clear();
            Driver.Instance.FindElement(By.Id("Message")).SendKeys(invitationText);
            Driver.Instance.FindElement(By.Id("btn-invite")).Click();
        }

        public static bool ConfirmationInvitationIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("invite-succeed")) != null; }
        }
    }
}