using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseInviteTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_invite_another_contact_page()
        {
            _driver.Navigate().GoToUrl("http://thomarelau.local/ContactEnterprise/InviteContactEnterprise");

            try
            {
                _driver.FindElement(By.Id("inviteContact-page"));
            }
            catch (NoSuchElementException)
            {
                Assert.Fail("Identifiant inviteContact-page non trouvé sur la page.");
            }
        }
    }
}
