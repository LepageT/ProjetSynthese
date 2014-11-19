using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerReactivate : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void reactivate_action_should_render_view_with_email_and_enterprise_name()
        {
           
            //Arrange 
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var viewModelExpected = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(invitation);


            //Action
            var viewResult = enterpriseController.Reactivate(invitation.Token) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.ContactEnterprise.Reactive;

            //Assert 
            viewModelExpected.Email.ShouldBeEquivalentTo(viewModelObtained.Email);
            viewModelExpected.EnterpriseName.ShouldBeEquivalentTo(viewModelObtained.EnterpriseName);
 
        }

        [TestMethod]
        public void reactivate_should_return_httpnotfound_when_invitation_is_empty()
        {
            var result = enterpriseController.Reactivate("");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void reactivate_should_return_httpnotfound_when_invitation_dont_exist()
        {
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var result = enterpriseController.Reactivate("1");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void reactivate_should_return_httpnotfound_when_invitation_is_already_used()
        {
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            var invitation = invitations.First();
            invitation.Used = true;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var result = enterpriseController.Reactivate(invitation.Token);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void reactivate_should_return_create_view_when_invitation_is_unsued()
        {
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var viewResult = enterpriseController.Reactivate(invitation.Token) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void reactivate_should_return_default_view_when_modelState_is_not_valid()
        {
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            enterpriseController.ModelState.AddModelError("Error", "Error");
            var viewResult = enterpriseController.Reactivate(invitation.Token) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void reactivate_post_should_return_default_view_when_email_is_already_used()
        {
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(2);
            var contactEnterprise = contactsEnterprise.First();
            contactEnterprise.Email = invitation.Email;
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());
            invitationRepository.GetAll().Returns(invitations.AsQueryable());

            var viewModel = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(invitation);
            var viewResult = enterpriseController.Reactivate(viewModel) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void reactivate_post_should_return_httpnotfound_if_invitation_is_not_found()
        {
            var invitation = _fixture.Create<InvitationContactEnterprise>();
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(2);
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());

            var viewModel = Mapper.Map<ViewModels.ContactEnterprise.Reactive>(invitation);
            var result = enterpriseController.Reactivate(viewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void reactivate_post_should_return_httpnotfound_if_invitation_email_is_different_of_the_email_entered()
        {
            var invitations = _fixture.CreateMany<InvitationContactEnterprise>(3);
            var invitation = invitations.First();
            invitation.Used = false;
            invitationRepository.GetAll().Returns(invitations.AsQueryable());
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(2);
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.ContactEnterprise.Reactive>();
            viewModel.Email = "1234567";

            var result = enterpriseController.Reactivate(viewModel);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void reactivate_post_should_return_index_on_success()
        {
            var invitation = _fixture.Create<InvitationContactEnterprise>();
            invitation.Used = false;
            invitationRepository.GetById(invitation.Id).Returns(invitation);
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(2);
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.ContactEnterprise.Reactive>();
            viewModel.InvitationId = invitation.Id;
            viewModel.Email = invitation.Email;

            var routeResult = enterpriseController.Reactivate(viewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.ContactEnterprise.Views.ViewNames.CreateConfirmation);
        }

        
    }
}
