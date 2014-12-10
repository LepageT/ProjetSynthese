using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class RemoveStudentsCoordinatorPage
    {
        public static void GoTo()
        {
            Navigation.Coordinator.RemoveStudents.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Coordinator/RemoveStudent");
        }


        public static int CountNbStudents()
        {
            var countText = Driver.Instance.FindElement(By.Id("student-count")).Text;
            return int.Parse(countText.Split(' ')[0]);
        }

        public static void DeleteStudents()
        {
            Driver.Instance.FindElement(By.Id("remove-button")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmation-RemoveStudent")) != null; }
        }
    }
}