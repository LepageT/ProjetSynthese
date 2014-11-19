using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorInviteTests : BaseTests
    {

        [TestMethod]
        public void coordinator_should_be_able_to_send_invitation_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteCoordinatorPage.GoTo();

            InviteCoordinatorPage.IsDisplayed.Should().BeTrue();
           
            }

        [TestMethod]
        public void coordinator_not_should_be_able_to_send_invitation_if_not_logged_in()
        {
            InviteCoordinatorPage.GoToByUrl();
           
            LoginPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_invite_should_create_an_invitation()
        {
            const string EMAIL = "testInvite@hotmail.com";
            const string TEXT = "Tremblay";
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteCoordinatorPage.GoTo();
            InviteCoordinatorPage.SendInvitation(EMAIL, TEXT);

            InviteCoordinatorPage.ConfirmationInvitationIsDisplayed.Should().BeTrue();
            
        }
    }
}
