using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;

namespace Stagio.Web.AcceptanceTests.AccountTests
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
            var user = TestData.applicationUser;

            var loginInput = _driver.FindElement(By.Id("Username"));
            loginInput.SendKeys(user.UserName);

            var passwordInput = _driver.FindElement(By.Id("Password"));
            passwordInput.SendKeys("test4test");

            var loginButton = _driver.FindElement(By.Id("login-submit"));
            loginButton.Click();

            var logOut = _driver.FindElement(By.Id("logout-link"));
            logOut.Click();
            var body = _driver.FindElement(By.ClassName("navbar"));
            

            Assert.IsTrue(body.Text.Contains("Se connecter"), "Déconnexion à échoué");
        }
    
    }
}
