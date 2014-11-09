using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class DetailsStudentApplyContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("details-apply-student")) != null; }
        }

        public static void GoToApply1()
        {
            Navigation.ContactEnterprise.DetailsApplyStudent1.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/DetailsStudentApply/2");
        }

        public static void AcceptApply()
        {
            Driver.Instance.FindElement(By.Id("accept-stage")).Click();
        }

        public static void RefuseApply()
        {
            Driver.Instance.FindElement(By.Id("refuse-stage")).Click();
        }

        public static bool ConfirmationAccpetIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationAcceptApply-page")) != null; }
        }

        public static bool ConfirmationRefuseIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationRefuseApply-page")) != null; }
        }
    }
}