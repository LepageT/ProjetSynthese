﻿using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Automation.Selenium;


namespace Stagio.Web.AcceptanceTests
{
    [TestClass]
    public class BaseTests
    {
        //protected IWebDriver _driver { get; set; }

        protected const string CoordonatorUsername = "coordonnateur@stagio.com";
        protected const string CoordonatorPassword = "test4test";

        protected const string StudentUsername = "1234567";
        protected const string StudentPassword = "qwerty12";

        protected Fixture _fixture;

        [TestInitialize]
        public void Initialize()
        {
            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            Driver.Initialize();
            //_driver = new FirefoxDriver();

            //_driver.Manage().Window.Maximize();

            //_driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            //_driver.Navigate().GoToUrl("http://thomarelau.local/Ci");
            //_driver.FindElement(By.Id("go_home")).Click();
        }

        [TestCleanup]
        public void Cleanup()
        {
            Driver.Close();
        }

        /*public void GetScreenShoot(string screenShootName)
        {
            var screenShoot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenShoot.SaveAsFile(screenShootName + "_" +
                                   DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                                   ".png",
                                   ImageFormat.Png);
        }*/


        /*public void AuthentificateTestUser(string username, string password)//User with all access for testing purpose on controller with roles authorize
        {
            var menuElement = _driver.FindElement(By.Id("login-link"));
            menuElement.Click();

           // var user = TestData.applicationUser;

            var loginInput = _driver.FindElement(By.Id("Username"));
            loginInput.SendKeys(username);

            var passwordInput = _driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys(password);

            var loginButton = _driver.FindElement(By.Id("login-submit"));
            loginButton.Click();
        }*/
    }
}
