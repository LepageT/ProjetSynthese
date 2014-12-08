using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;


namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteOneContactEnterpriseTests : CoordinatorControllerBaseClassTests
    {

        [TestMethod]
        public void coordinator_inviteOneContactEnteprise_get_should_return_inviteContactEnterprise_view()
        {
            var result = coordinatorController.InviteOneContactEnterprise() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_inviteOneContactEnteprise_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var enterpriseInvalid = _fixture.Create<ViewModels.Coordinator.InviteContactEnterprise>();
            enterpriseInvalid.Email = null;
            coordinatorController.ModelState.AddModelError("Error", "Error");

            var result = coordinatorController.InviteOneContactEnterprise(enterpriseInvalid) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_inviteOneContactEnteprise_post_should_return_confirmation_on_success()
        {
            var enterpriseValid = _fixture.Create<ViewModels.Coordinator.InviteContactEnterprise>();
            enterpriseValid.Email = "test@hotmail.com";
            mailler.SendEmail(enterpriseValid.Email, "Test", "").ReturnsForAnyArgs(true);

            var result = coordinatorController.InviteOneContactEnterprise(enterpriseValid) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.InviteContactEnterpriseConfirmation);
        }

        [TestMethod]
        public void coordinator_inviteOneContactEnteprise_post_should_return_default_view_when_mailler_cant_send()
        {
            var enterprise = _fixture.Create<ViewModels.Coordinator.InviteContactEnterprise>();
            mailler.SendEmail(Arg.Any<String>(), Arg.Any<String>(), Arg.Any<String>()).Returns(false);

            var result = coordinatorController.InviteOneContactEnterprise(enterprise) as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
