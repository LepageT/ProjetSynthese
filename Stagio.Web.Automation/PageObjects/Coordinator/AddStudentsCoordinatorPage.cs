using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class AddStudentsCoordinatorPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("upload-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Coordinator.AddStudents.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Upload");
        }

        public static bool SelectCsvFile(string url)
        {
            try
            {

                Driver.Instance.FindElement(By.Id("file")).SendKeys(url);

            }
            catch (Exception)
            {

                return false;
            }
            Driver.Instance.FindElement(By.Id("button-upload")).Click();
            return true;
        }
    }
}