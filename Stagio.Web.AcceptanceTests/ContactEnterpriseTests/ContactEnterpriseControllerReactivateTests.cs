using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
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

            ReactivateContactEnterprisePage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_create_account_if_invitation_is_valid()
        {
            ReactivateContactEnterprisePage.GoToByUrl();
            const string EMAIL = "testemail@enterprise.com";
            const string PASSWORD = "Bobino1234";
            const string FIRST_NAME = "Bobino";
            const string LAST_NAME = "Jean";
            const string ENTERPRISE_NAME = "Enterprise";
            const string TELEPHONE = "123-456-7890";

            ReactivateContactEnterprisePage.FillFieldsAndSend(EMAIL, PASSWORD, FIRST_NAME, LAST_NAME, ENTERPRISE_NAME, TELEPHONE);

            ReactivateContactEnterprisePage.ConfirmationIsDisplayed.Should().BeTrue();

        }
    }
}
