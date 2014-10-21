using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.UI.WebControls;
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
        public void coordonnateur_create_get_should_return_view_with_createCoordonnateur_viewModels_when_invitation_is_valid()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);

            var viewResult = coordonnateurController.Create(invitation.Token) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Coordonnateur.Create;

            //Assert 
            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 

        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_httpnotfound_when_invitation_is_empty()
        {
            var result = coordonnateurController.Create("");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_httpnotfound_when_invitation_dont_exist()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var result = coordonnateurController.Create("1");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_httpnotfound_when_invitation_is_already_used()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = true;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);

            var result = coordonnateurController.Create(invitation.Token);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordonnateur_create_get_should_return_create_view_when_invitation_is_unsued()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);

            var viewResult = coordonnateurController.Create(invitation.Token) as ViewResult;
            //Assert 
            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            coordonnateurController.ModelState.AddModelError("Error", "Error");
            var viewResult = coordonnateurController.Create(invitation.Token) as ViewResult;

            //Assert 
            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_default_view_when_email_is_already_used()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var coordonnateurs = _fixture.CreateMany<Coordonnateur>(2);
            var coordonnateur = coordonnateurs.First();
            coordonnateur.Email = invitation.Email;
            coordonnateurRepository.GetAll().Returns(coordonnateurs.AsQueryable());



            var viewModel = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);
            var viewResult = coordonnateurController.Create(viewModel) as ViewResult;

            //Assert 
            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_httpnotfound_if_invitation_is_not_found()
        {
            var invitation = _fixture.Create<Invitation>();
            var coordonnateurs = _fixture.CreateMany<Coordonnateur>(2);
            coordonnateurRepository.GetAll().Returns(coordonnateurs.AsQueryable());

            var viewModel = Mapper.Map<ViewModels.Coordonnateur.Create>(invitation);
            var result = coordonnateurController.Create(viewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_httpnotfound_if_invitation_email_is_different_of_the_email_entered()
        {
            var invitations = _fixture.CreateMany<Invitation>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
           
            var coordonnateurs = _fixture.CreateMany<Coordonnateur>(2);
            coordonnateurRepository.GetAll().Returns(coordonnateurs.AsQueryable());

            var viewModel = _fixture.Create<ViewModels.Coordonnateur.Create>();
            viewModel.Email = "1234567";

            var result = coordonnateurController.Create(viewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void coordonnateur_create_post_should_return_index_on_success()
        {
            var invitation = _fixture.Create<Invitation>();
            invitation.Used = false;

            invitationRepository.GetById(invitation.Id).Returns(invitation);

            var coordonnateurs = _fixture.CreateMany<Coordonnateur>(2);
            coordonnateurRepository.GetAll().Returns(coordonnateurs.AsQueryable());

            var viewModel = _fixture.Create<ViewModels.Coordonnateur.Create>();
            viewModel.InvitationId = invitation.Id;
            viewModel.Email = invitation.Email;

            viewModel.ConfirmedPassword = viewModel.Password;


            var routeResult = coordonnateurController.Create(viewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            //Assert
            routeAction.Should().Be(MVC.Coordonnateur.Views.ViewNames.Index);
        }
    }
}
