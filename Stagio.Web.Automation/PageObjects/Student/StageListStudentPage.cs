using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class StageListStudentPage
    {
        public static void GoTo()
        {
            Navigation.Student.SeeStages.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/DisplayStageList");
        }

        public static bool AccessStageDescription()
        {
            Driver.Instance.FindElement(By.Id("details-stages3")).Click();
            try
            {
                Driver.Instance.FindElement(By.Id("view-stage-info"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
           
        }
    }
}