using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ReplyStageStudentPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("replyStage-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.ReplyApplyStage1.Select();
        }

        public static void GoToByUrlIdApply1()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/ReplyStage?idApply=1");
        }

        public static void ReplyAcceptStage()
        {
            
            Driver.Instance.FindElement(By.Id("accept-stage")).Click();
        }
    }
}