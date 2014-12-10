
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using FluentAssertions;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteTest : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_invite_get_should_returnview_default_view()
        {
            var result = coordinatorController.Invite() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_invite__post_should_return_default_view_when_modelState_is_invalid()
        {
            var invitation = _fixture.Create<ViewModels.Coordinator.Invite>();

            coordinatorController.ModelState.AddModelError("Error", "Error");
            var viewResult = coordinatorController.Invite(invitation) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_invite__post_should_return_default_view_when_email_is_invalid()
        {
            var invitation = _fixture.Create<ViewModels.Coordinator.Invite>();

            var viewResult = coordinatorController.Invite(invitation) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_invite_post_should_return_index_on_success()
        {
            var invitation = _fixture.Create<ViewModels.Coordinator.Invite>();
            invitation.Email = "admin@admin.com";
            mailler.SendEmail(invitation.Email, "Test", invitation.Message).ReturnsForAnyArgs(true);

            var routeResult = coordinatorController.Invite(invitation) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Coordinator.Views.ViewNames.InvitationSucceed);

        }

        [TestMethod]
        public void coordinator_inviteSucceed_should_render_view()
        {
            var result = coordinatorController.InvitationSucceed() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
