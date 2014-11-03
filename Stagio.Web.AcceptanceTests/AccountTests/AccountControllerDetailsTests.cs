using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.AccountTests
{
    [TestClass]
    public class AccountControllerDetailsTests : BaseTests
    {
        [TestMethod]
        public void applicationUser_can_see_his_profil()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Account/Details/1");
    
            try
            {
                _driver.FindElement(By.Id("details-user-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant details-user-page non trouvé sur la page.");
            }
        }

    }
}
