using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects
{
    public class EditStageAgreementPage
    {
        public static void GoByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/StageAgreement/Edit?idStageAgreement=1");
        }

        public static void EditAStageAgreement(string signature)
        {

            Driver.Instance.FindElement(By.Id("CoordinatorSignature")).Clear();
            Driver.Instance.FindElement(By.Id("CoordinatorSignature")).SendKeys(signature);
     

            Driver.Instance.FindElement(By.Id("edit-button")).Click();
        }
    }
}