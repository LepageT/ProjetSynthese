using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class ListStageContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("list-stage")) != null; }
        }

        public static void GoTo()
        {
            Navigation.ContactEnterprise.ListStages.Select();
        }

        public static void ClickRemoveStage1()
        {
            Driver.Instance.FindElement(By.Id("remove-stage1")).Click();
           
        }

        public static bool RemoveStageConfirmationIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("removeStage-page")) != null; }
        }

        public static void ClickReactivateStage1()
        {
            Driver.Instance.FindElement(By.Id("reactivate-stage1")).Click();
           
        }

        public static bool ReactivateStageConfirmationIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("reactivateStage-page")) != null; }
        }

    }
}