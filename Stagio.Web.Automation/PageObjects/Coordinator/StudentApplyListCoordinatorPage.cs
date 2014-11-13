using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class StudentApplyListCoordinatorPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("studentApply-list")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Coordinator.StudentApplyList1.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/StudentApplyList");
        }

        
        public static int CountNbApplies()
        {
            var countText = Driver.Instance.FindElement(By.Id("stage-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}