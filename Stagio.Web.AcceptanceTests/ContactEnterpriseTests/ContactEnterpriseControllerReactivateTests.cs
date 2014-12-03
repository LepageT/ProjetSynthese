using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerReactivateTests : BaseTests
    {

        [TestMethod]
        public void contact_enterprise_should_be_able_to_create_account_if_invitation_is_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

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
