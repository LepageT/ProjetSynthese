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
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("student-StageList")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.SeeStages.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/StageList");
        }

        public static bool HasStage
        {
            get
            {
                return GetStageCount() > 0;
            }
        }

        private static int GetStageCount()
        {
            var countText = Driver.Instance.FindElement(By.Id("stages-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
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