using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.ContactEnterprise
{
    public class EditContactEnterprisePage
    {
        public static void GoTo()
        {
            Navigation.ContactEnterprise.EditProfil.Select();
        }

        public static void GoToByUrl()
        {

            Driver.Instance.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/Edit?id=8");
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
            Navigation.ContactEnterprise.EditProfilInIndex.Select();
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