using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class CreateStageAgreementCoordinatorPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("create-StageAgreement")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Coordinator.StageAgreementCreate1.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/StageAgreement/CreateConfirmation");
        }
    }
}