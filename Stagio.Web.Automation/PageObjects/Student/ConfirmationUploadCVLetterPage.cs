using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ConfirmationUploadCVLetterPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationApplyStudent-page")) != null; }
        }
    }
}