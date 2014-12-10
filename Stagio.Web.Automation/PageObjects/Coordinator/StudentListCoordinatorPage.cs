using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class StudentListCoordinatorPage
    {

        public static void GoTo()
        {
            Navigation.Coordinator.StudentList.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/StudentList");
        }

        public static bool AccessStudent1ApplyList()
        {
            Driver.Instance.FindElement(By.Id("student-stages1")).Click();
            try
            {
                Driver.Instance.FindElement(By.Id("studentApply-list"));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static int CountNbStudents()
        {
            var countText = Driver.Instance.FindElement(By.Id("student-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }
    }
}