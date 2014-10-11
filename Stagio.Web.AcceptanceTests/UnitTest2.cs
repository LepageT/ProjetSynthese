using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.Database;


namespace Stagio.Web.AcceptanceTests
{
    [TestClass]
    public class AccountControllerLoginTests : BaseTests
    {
        [TestInitialize]
        public void initialize()
        {
            var menuElement = _driver.FindElement(By.Id("login-link"));
            menuElement.Click();
        }

        [TestMethod]
        public void application_user_can_log_in()
        {
            var user = TestData.applicationUser;

            var loginInput = _driver.FindElement(By.Id("Username"));
            loginInput.SendKeys(user.UserName);

            var passwordInput = _driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("test4test");

            var loginButton = _driver.FindElement(By.Id("login-submit"));
            loginButton.Click();

            var body = _driver.FindElement(By.ClassName("navbar"));
           
            Assert.IsTrue(body.Text.Contains("Super admin coordonnateur Tux"), "L'administrateur n'est pas connecté.");
        }
    }
}
