using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Student
{
    public class ApplyStudentPage
    {
        public static bool IsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("apply-page")) != null; }
        }

        public static void GoTo()
        {
            Navigation.Student.ApplyStage3.Select();
        }

        public static void GoToByUrl()
        {
            Driver.Instance.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(2));
            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/Student/Apply/3");
        }

        public static void ApplyStudent(string cv, string letter)
        {
            Driver.Instance.FindElement(By.Id("file1")).SendKeys(cv);
            Driver.Instance.FindElement(By.Id("file2")).SendKeys(letter);
            Driver.Instance.FindElement(By.Id("apply-button")).Click();
        }

        public static bool ConfirmationPageIsDisplayed
        {
            get { return Driver.Instance.FindElement(By.Id("confirmationApplyStudent-page")) != null; }
        }

        public static bool SelectFiles(string file1, string file2)
        {
            try
            {

                var towFoldersUp = Path.GetFullPath("../../../");
                var testFilesPath = Directory.GetDirectories(towFoldersUp, "TestFiles", SearchOption.AllDirectories)
                                                   .FirstOrDefault();
                var fullPath1 = Path.Combine(testFilesPath, file1);
                var fullPath2 = Path.Combine(testFilesPath, file2);

                Driver.Instance.FindElement(By.Id("file1")).SendKeys(fullPath1);
                Driver.Instance.FindElement(By.Id("file2")).SendKeys(fullPath2);
                Driver.Instance.FindElement(By.Id("apply-button")).Click();

            }
            catch (Exception)
            {

                return false;
            }
           
            return true;
        }

        public static void Goto()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress + "/File/Upload");
        }
    }
}