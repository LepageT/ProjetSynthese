using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteEnterpriseTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_access_invite_enterprise_page()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/InviteContactEnterprise");

            try
            {
                _driver.FindElement(By.Id("invite-enterprise-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant invite-enterprise-page non trouvé sur la page.");
            }
        }


        [TestMethod]
        public void coordinator_should_be_able_to_invite_enterprise()
        {
            const string MESSAGE_INVITATION = "test";
            _driver.Navigate().GoToUrl("http://thomarelau.local/Coordinator/InviteContactEnterprise");
            _driver.FindElement(By.Id("Message")).SendKeys(MESSAGE_INVITATION);
            _driver.FindElement(By.Id("send-button")).Click();
            try
            {
                _driver.FindElement(By.Id("confirmationInvitationContact-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant confirmationInvitationContact-page non trouvé sur la page.");
            }
           

        }
    }
}
