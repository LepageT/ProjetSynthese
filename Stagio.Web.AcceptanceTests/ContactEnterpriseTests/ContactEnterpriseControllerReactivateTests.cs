using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerReactivateTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_reactivate_page()
        {
            ReactivateContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(ReactivateContactEnterprisePage.IsDisplayed);

        }

        [TestMethod]
        public void coordinator_create_should_create_account_if_invitation_is_valid()
        {
            ReactivateContactEnterprisePage.GoToByUrl();
            const string EMAIL = "testemail@admin.com";
            const string PASSWORD = "Bobino1234";
            ReactivateContactEnterprisePage.FillFieldsAndSend(EMAIL, PASSWORD);

            Assert.IsTrue(ReactivateContactEnterprisePage.ConfirmationIsDisplayed);

        }
    }
}
