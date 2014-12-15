using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OpenQA.Selenium;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.Automation.PageObjects.Coordinator
{
    public class ChangeSMTPOptionsPage
    {
        public static void GoTo()
        {
            Navigation.Coordinator.ChangeSmtpOptions.Select();
        }

        public static void FillFieldsAndSend(string server, string port, string username, string password, string email)
        {
            Driver.Instance.FindElement(By.Id("SmtpServer")).Clear();
            Driver.Instance.FindElement(By.Id("SmtpServer")).SendKeys(server);
            Driver.Instance.FindElement(By.Id("SmtpPort")).Clear();
            Driver.Instance.FindElement(By.Id("SmtpPort")).SendKeys(port);
            Driver.Instance.FindElement(By.Id("SmtpUsername")).Clear();
            Driver.Instance.FindElement(By.Id("SmtpUsername")).SendKeys(username);
            Driver.Instance.FindElement(By.Id("SmtpPassword")).Clear();
            Driver.Instance.FindElement(By.Id("SmtpPassword")).SendKeys(password);
            Driver.Instance.FindElement(By.Id("TestEmail")).Clear();
            Driver.Instance.FindElement(By.Id("TestEmail")).SendKeys(email);
            Driver.Instance.FindElement(By.Id("SaveSmtpOptions")).Click();
        }

        public static void ReturnToDefault()
        {
            Driver.Instance.FindElement(By.Id("SmtpUsername")).Clear();
            Driver.Instance.FindElement(By.Id("SmtpPassword")).Clear();
            Driver.Instance.FindElement(By.Id("DefaultSmtpOptions")).Click();
        }

    }
}