using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class StudentApplyContactEnterprisePage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("list-student-stage")) != null; }
        }

        public static void GoTo()
        {
            Navigation.ContactEnterprise.ListStages.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/ListStudentApply/1");
        }

        public static bool ButtonIsDisplayed()
        {
             try
            {
                Driver.Instance.FindElement(By.Id("list-student1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}