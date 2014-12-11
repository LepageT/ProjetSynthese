using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
   public  class CoordinatorControllerInviteOneContactEnterprise : BaseTests
    {
       
        [TestMethod]
        public void coordinator_should_not_be_able_to_access_invite_one_contact_page_if_not_logged_in()
        {
            InviteContactOneEnterprisePage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_should_be_able_to_invite_one_contact_enterprise()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteContactOneEnterprisePage.GoToByUrl();
            InviteContactOneEnterprisePage.InviteContactEnterprise();

            InviteContactOneEnterprisePage.SendInvite();

            InviteContactOneEnterprisePage.ConfirmationPageIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_should_not_be_able_to_invite_one_contact_enterprise_if_there_is_no_email()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteContactOneEnterprisePage.GoToByUrl();

            InviteContactOneEnterprisePage.SendInvite();

            InviteContactOneEnterprisePage.IsDisplayed.Should().BeTrue();

        }
    }
}
