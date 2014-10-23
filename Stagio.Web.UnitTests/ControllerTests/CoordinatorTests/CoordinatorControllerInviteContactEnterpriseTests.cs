using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteContactEnterpriseTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void invite_get_should_render_default_view()
        {
            //Arrange 
            

            //Action
            var result = coordinatorController.InviteContactEnterprise() as ViewResult;

            //Assert 
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void invite_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            IEnumerable<int> selectedIdContactEnterprise = new int[] { 1, 2 };
            const string MESSAGE_INVITATION = "test";
            coordinatorController.ModelState.AddModelError("Error", "Error");

            //Action
            var result = coordinatorController.InviteContactEnterprise(selectedIdContactEnterprise, MESSAGE_INVITATION) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void invite__post_should_return_index_view_after_sending_if_email_is_valid()
        {
            //Arrange
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.Email = "test@test.com";
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
            IEnumerable<int> selectedIdContactEnterprise = new int[] { contactEnterprise.Id };
            const string MESSAGE_INVITATION = "test";
            mailler.SendEmail(contactEnterprise.Email, "Test", MESSAGE_INVITATION).ReturnsForAnyArgs(true);


            //Action
            var routeResult = coordinatorController.InviteContactEnterprise(selectedIdContactEnterprise, MESSAGE_INVITATION) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be("InviteContactEnterpriseConfirmation");
        }

        [TestMethod]
        public void invite__post_should_return_default_view_if_email_is_invalid()
        {
            //Arrange
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.Email = "invalidEmail";
            enterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
            IEnumerable<int> selectedIdContactEnterprise = new int[] { contactEnterprise.Id };
            const string MESSAGE_INVITATION = "test";

            //Action
            var result = coordinatorController.InviteContactEnterprise(selectedIdContactEnterprise, MESSAGE_INVITATION) as ViewResult;

            //Assert
            result.ViewName.Should().Be("");
        }
    }
}
