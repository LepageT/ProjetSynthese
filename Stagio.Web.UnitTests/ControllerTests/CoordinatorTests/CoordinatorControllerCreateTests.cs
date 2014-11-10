
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using AutoMapper;
using FluentAssertions;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerCreateTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_create_get_should_return_view_with_createCoordinator_viewModels_when_invitation_is_valid()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.Create>(invitation);

            var viewResult = coordinatorController.Create(invitation.Token) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Coordinator.Create;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 

        }

        [TestMethod]
        public void coordinator_create_get_should_return_httpnotfound_when_invitation_is_empty()
        {
            var result = coordinatorController.Create("");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordinator_create_get_should_return_httpnotfound_when_invitation_dont_exist()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var result = coordinatorController.Create("1");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordinator_create_get_should_return_httpnotfound_when_invitation_is_already_used()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = true;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.Create>(invitation);

            var result = coordinatorController.Create(invitation.Token);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordinator_create_get_should_return_create_view_when_invitation_is_unsued()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.Coordinator.Create>(invitation);

            var viewResult = coordinatorController.Create(invitation.Token) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            coordinatorController.ModelState.AddModelError("Error", "Error");
            var viewResult = coordinatorController.Create(invitation.Token) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_create_post_should_return_default_view_when_email_is_already_used()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var coordinators = _fixture.CreateMany<Coordinator>(2);
            var coordinator = coordinators.First();
            coordinator.Email = invitation.Email;
            coordinatorRepository.GetAll().Returns(coordinators.AsQueryable());

            var viewModel = Mapper.Map<ViewModels.Coordinator.Create>(invitation);
            var viewResult = coordinatorController.Create(viewModel) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_create_post_should_return_httpnotfound_if_invitation_is_not_found()
        {
            var invitation = _fixture.Create<Invitation>();
            var coordinators = _fixture.CreateMany<Coordinator>(2);
            coordinatorRepository.GetAll().Returns(coordinators.AsQueryable());

            var viewModel = Mapper.Map<ViewModels.Coordinator.Create>(invitation);
            var result = coordinatorController.Create(viewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordinator_create_post_should_return_httpnotfound_if_invitation_email_is_different_of_the_email_entered()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;            
            invitationRepository.GetAll().Returns(invitations.AsQueryable());           
            var coordinators = _fixture.CreateMany<Coordinator>(2);
            coordinatorRepository.GetAll().Returns(coordinators.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.Coordinator.Create>();
            viewModel.Email = "1234567";

            var result = coordinatorController.Create(viewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordinator_create_post_should_return_index_on_success()
        {
            var invitation = _fixture.Create<Invitation>();
            invitation.Used = false;
            invitationRepository.GetById(invitation.Id).Returns(invitation);
            var coordinators = _fixture.CreateMany<Coordinator>(2);
            coordinatorRepository.GetAll().Returns(coordinators.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.Coordinator.Create>();
            viewModel.InvitationId = invitation.Id;
            viewModel.Email = invitation.Email;
            viewModel.ConfirmedPassword = viewModel.Password;

            var routeResult = coordinatorController.Create(viewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Coordinator.Views.ViewNames.CreateConfirmation);
        }
    }
}
