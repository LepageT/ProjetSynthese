using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ListInterview
    {
        public static void GoTo()
        {
            Navigation.Student.ListInterview.Select();
        }

        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("list-page")) != null; }
        }

        public static bool InterviewIsDisplayed()
        {
            try
            {
                Driver.Instance.FindElement(By.Id("list-interview1"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
            
        }
 
    }
}