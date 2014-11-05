using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorInviteTests : BaseTests
    {

        [TestMethod]
        public void coordinator_should_be_able_to_send_invitation_if_logged_in()
        {
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);
            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Invite");
           
            try
            {
                _driver.FindElement(By.Id("coordinator-invite"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant coordinator-invite non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_send_invitation_if_not_logged_in()
        {
           
            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Invite");

            try
            {
                _driver.FindElement(By.Id("login-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant coordinator-invite non trouvé sur la page.");
            }
        }

        [TestMethod]
        public void coordinator_invite_should_create_an_invitation()
        {
            const string EMAIL = "thomarelau@hotmail.com";
            const string TEXT = "Tremblay";
            AuthentificateTestUser(CoordonatorUsername, CoordonatorPassword);

            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Invite");
            _driver.FindElement(By.Id("Email")).Clear();
            _driver.FindElement(By.Id("Email")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("Message")).Clear();
            _driver.FindElement(By.Id("Message")).SendKeys(TEXT);
            _driver.FindElement(By.Id("btn-invite")).Click();
            try
            {
                _driver.FindElement(By.Id("invite-succeed"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant invite-succeed non trouvé sur la page");
            }
        }
    }
}
