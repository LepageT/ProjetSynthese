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
        public static void GoToByUrl()
        {
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
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