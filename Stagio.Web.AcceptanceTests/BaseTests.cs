using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Stagio.TestUtilities.Database;


namespace Stagio.Web.AcceptanceTests
{
    [TestClass]
    public class BaseTests
    {
        protected IWebDriver _driver { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            _driver = new FirefoxDriver();

            _driver.Manage().Window.Maximize();

            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            _driver.Navigate().GoToUrl("http://thomarelau.local/Ci");
            _driver.FindElement(By.Id("go_home")).Click();
        }

        [TestCleanup]
        public void Cleanup()
        {
            _driver.Close();
        }

        public void GetScreenShoot(string screenShootName)
        {
            var screenShoot = ((ITakesScreenshot)_driver).GetScreenshot();
            screenShoot.SaveAsFile(screenShootName + "_" +
                                   DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") +
                                   ".png",
                                   ImageFormat.Png);
        }


        public void AuthentificateTestUser()//User with all access for testing purpose on controller with roles authorize
        {
            var menuElement = _driver.FindElement(By.Id("login-link"));
            menuElement.Click();

            var user = TestData.applicationUser;

            var loginInput = _driver.FindElement(By.Id("Username"));
            loginInput.SendKeys(user.UserName);

            var passwordInput = _driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("test4test");

            var loginButton = _driver.FindElement(By.Id("login-submit"));
            loginButton.Click();
        } 
        
        
    }
}
