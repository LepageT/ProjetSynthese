using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class DetailsStudentApplyCoordinatorPage
    {
        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/DetailsApplyStudent/1?error=False");
        }

        public static void DownloadPage()
        {
            Driver.Instance.FindElement(By.Id("download-cv")).Click();
        }

        public static bool ErrorDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("error-message")) != null; }
        }
    }
}