using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteTests : BaseTests
    {

        [TestMethod]
        public void coordinator_should_be_able_to_invite_enterprise()
        {

            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteContactEnterpriseCoordinatorPage.GoTo();

            InviteContactEnterpriseCoordinatorPage.AddMessageInvitationAndSend("TEST");
           
            InviteContactEnterpriseCoordinatorPage.ConfirmationPageIsDisplayed.Should().BeTrue();

        }
    }
}
