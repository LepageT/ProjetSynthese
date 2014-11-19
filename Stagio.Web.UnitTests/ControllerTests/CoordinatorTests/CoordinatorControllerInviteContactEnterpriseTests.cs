
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FluentAssertions;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteContactEnterpriseTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void invite_get_should_render_default_view()
        {
            var result = coordinatorController.InviteContactEnterprise() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void invite_post_should_return_default_view_when_modelState_is_not_valid()
        {
            IEnumerable<int> selectedIdContactEnterprise = new int[] { 1, 2 };
            const string MESSAGE_INVITATION = "test";
            coordinatorController.ModelState.AddModelError("Error", "Error");

            var result = coordinatorController.InviteContactEnterprise(selectedIdContactEnterprise, MESSAGE_INVITATION) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void invite__post_should_return_index_view_after_sending_if_email_is_valid()
        {
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.Email = "test@test.com";
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
            IEnumerable<int> selectedIdContactEnterprise = new int[] { contactEnterprise.Id };
            const string MESSAGE_INVITATION = "test";
            mailler.SendEmail(contactEnterprise.Email, "Test", MESSAGE_INVITATION).ReturnsForAnyArgs(true);

            var routeResult = coordinatorController.InviteContactEnterprise(selectedIdContactEnterprise, MESSAGE_INVITATION) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("InviteContactEnterpriseConfirmation");
        }

        [TestMethod]
        public void invite__post_should_return_default_view_if_email_is_invalid()
        {
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.Email = "invalidEmail";
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
            IEnumerable<int> selectedIdContactEnterprise = new int[] { contactEnterprise.Id };
            const string MESSAGE_INVITATION = "test";

            var result = coordinatorController.InviteContactEnterprise(selectedIdContactEnterprise, MESSAGE_INVITATION) as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
