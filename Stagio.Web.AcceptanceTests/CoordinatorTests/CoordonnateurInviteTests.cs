using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorInviteTests : BaseTests
    {

        [TestMethod]
        public void coordinator_should_be_able_to_send_invitation()
        {
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
        public void coordinator_invite_should_create_an_invitation()
        {
            const string EMAIL = "thomarelau@hotmail.com";
            const string TEXT = "Tremblay";


            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/Invite");
            _driver.FindElement(By.Id("Email")).Clear();
            _driver.FindElement(By.Id("Email")).SendKeys(EMAIL);
            _driver.FindElement(By.Id("Message")).Clear();
            _driver.FindElement(By.Id("Message")).SendKeys(TEXT);
            _driver.FindElement(By.Id("btn-invite")).Click();
            try
            {
                _driver.FindElement(By.Id("coordinator-home"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant coordinator-home non trouvé sur la page");
            }
        }
    }
}
