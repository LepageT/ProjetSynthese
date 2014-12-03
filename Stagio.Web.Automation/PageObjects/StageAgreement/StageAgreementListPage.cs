using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.StageAgreement
{
    public class StageAgreementListPage
    {
        public static void StudentGoTo()
        {
            Navigation.Student.StageAgreementList.Select();
        }
        public static void ContactEnterpriseGoTo()
        {
            Navigation.ContactEnterprise.StageAgreementList.Select();
        }

        public static void CoordinatorGoTo()
        {
            Navigation.Coordinator.StageAgreementList.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/StageAgreement/List");
        }

        public static bool HasStageAgreement
        {
            get
            {
                return GetStageAgreementCount() > 0;
            }
        }

        private static int GetStageAgreementCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("stageAgreement-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}