using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ViewInfoStageStudentPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("view-stage-info")) != null; }
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Stage/ViewStageInfo/1");
        }

    }
}