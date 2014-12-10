using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class CreateStudentPage
    {

        public static void GoTo()
        {
            Navigation.AllUsers.CreateStudent.Select();
        }

        public static void CreateStudent(Domain.Entities.Student newStudent)
        {
            newStudent.Email = "bob@hotmail.com";
            newStudent.Matricule = 1031739;
            Driver.Instance.FindElement(By.Id("Matricule")).SendKeys(newStudent.Matricule.ToString());
            Driver.Instance.FindElement(By.Id("FirstName")).SendKeys(newStudent.FirstName);
            Driver.Instance.FindElement(By.Id("LastName")).SendKeys(newStudent.LastName);
            Driver.Instance.FindElement(By.Id("Telephone")).SendKeys(newStudent.Telephone);
            Driver.Instance.FindElement(By.Id("Password")).SendKeys(newStudent.Password);
            Driver.Instance.FindElement(By.Id("PasswordConfirmation")).SendKeys(newStudent.Password);
            Driver.Instance.FindElement(By.Id("Email")).SendKeys(newStudent.Email);
            Driver.Instance.FindElement(By.Id("ConfirmEmail")).SendKeys(newStudent.Email);

            Driver.Instance.FindElement(By.Id("create-button")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationCreateStudent-page")) != null; }
        }
    }
}