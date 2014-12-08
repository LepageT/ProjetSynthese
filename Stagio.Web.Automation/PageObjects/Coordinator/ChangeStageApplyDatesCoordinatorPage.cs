using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class ChangeStageApplyDatesCoordinatorPage
    {
        public static void GoTo()
        {
            Navigation.Coordinator.ChangeStageDates.Select();
        }

        public static void AddDates()
        {
            const string DATE = "2014-12-21 10:30 AM";
            const string DATE2 = "2014-12-25 10:30 AM";

            Driver.Instance.FindElement(By.Id("datetimepickerStart")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepickerStart")).SendKeys(DATE);

            Driver.Instance.FindElement(By.Id("datetimepickerEnd")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepickerEnd")).SendKeys(DATE2);
            Driver.Instance.FindElement(By.Id("datetimepickerEnd")).Submit();


        }

        public static void ChangeDates()
        {
            const string DATE = "2014-12-25 10:30 AM";
            const string DATE2 = "2014-12-28 10:30 AM";

            Driver.Instance.FindElement(By.Id("datetimepickerStart")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepickerStart")).SendKeys(DATE);

            Driver.Instance.FindElement(By.Id("datetimepickerEnd")).Clear();
            Driver.Instance.FindElement(By.Id("datetimepickerEnd")).SendKeys(DATE2);
            Driver.Instance.FindElement(By.Id("datetimepickerEnd")).Submit();
        }


    }
}