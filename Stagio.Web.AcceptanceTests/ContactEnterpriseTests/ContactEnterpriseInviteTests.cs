using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseInviteTests : BaseTests
    {

        [TestMethod]
        public void contact_enterprise_should_not_be_able_to_access_invite_another_contact_page_if_not_logged_in()
        {
            InviteContactEnterprisePage.GoToByUrl();
            
            LoginPage.IsDisplayed.Should().BeTrue();

            }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_invite_another_contact_enterprise()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            InviteContactEnterprisePage.GoTo();
            InviteContactEnterprisePage.InviteContactEnterprise();

            InviteContactEnterprisePage.SendInvite();

            InviteContactEnterprisePage.ConfirmationPageIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void contact_enterprise_should_not_be_able_to_invite_another_contact_enterprise_if_there_is_no_email()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            InviteContactEnterprisePage.GoTo();

            InviteContactEnterprisePage.SendInvite();

            InviteContactEnterprisePage.IsDisplayed.Should().BeTrue();

        }
    }
}
