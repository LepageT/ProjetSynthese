using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;


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

        
    }
}
