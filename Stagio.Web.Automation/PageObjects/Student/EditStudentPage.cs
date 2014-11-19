using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;
using Stagio.Domain.Entities;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class EditStudentPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("edit-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.EditProfil.Select();
        }

        public static void GoToByUrl()
        {
            
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/Edit?id=1");
        }

        public static void EditAStudent(string telephone, string oldPassword, string newPassword)
        {
            Driver.Instance.FindElement(By.Id("Telephone")).Clear();
            Driver.Instance.FindElement(By.Id("Telephone")).SendKeys(telephone);
            Driver.Instance.FindElement(By.Id("OldPassword")).Clear();
            Driver.Instance.FindElement(By.Id("OldPassword")).SendKeys(oldPassword);
            Driver.Instance.FindElement(By.Id("Password")).Clear();
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(newPassword);
            Driver.Instance.FindElement(By.Id("PasswordConfirmation")).SendKeys(newPassword);

            Driver.Instance.FindElement(By.Id("edit-button")).Click();
        }

        public static bool EditVerification(string telephone)
        {
            Navigation.Student.EditProfilInIndex.Select();
            var telephoneDisplayed = Driver.Instance.FindElement(By.Id("Telephone")).GetAttribute("value");
            if (telephoneDisplayed == telephone)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}