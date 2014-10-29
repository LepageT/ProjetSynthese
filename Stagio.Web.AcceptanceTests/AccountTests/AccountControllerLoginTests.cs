using System;
using System.Drawing.Imaging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;

namespace Stagio.Web.AcceptanceTests.AccountTests
{
    [TestClass]
    public class AccountControllerLoginTests : BaseTests
    {
        [TestInitialize]
        public void InitializeAccountController()
        {
            var menuElement = _driver.FindElement(By.Id("login-link"));
            menuElement.Click();

        }

        [TestMethod]
        public void application_user_can_log_in()
        {
           AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);

            var body = _driver.FindElement(By.ClassName("navbar"));
           
            Assert.IsTrue(body.Text.Contains("Super admin coordonnateur Tux"), "L'administrateur n'est pas connecté.");
        }

        [TestMethod]
        public void application_user_should_be_able_to_view_the_login_page()
        {
            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant login-page non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void authentificated_user_should_be_able_to_logout_after_valid_login()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);

            var logOut = _driver.FindElement(By.Id("logout-link"));
            logOut.Click();
            var body = _driver.FindElement(By.ClassName("navbar"));
            

            Assert.IsTrue(body.Text.Contains("Se connecter"), "Déconnexion à échoué");
        }
    
    }
}
