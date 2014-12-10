using System;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;
using Stagio.Web.Module.Strings.Controller;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerEditTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void edit_should_return_view_with_contactEnterpriseViewModel_when_contactEnterprise_is_valid()
        {
            var contact = _fixture.Create<ContactEnterprise>();
            httpContext.GetUserId().Returns(contact.Id);
            enterpriseRepository.GetById(contact.Id).Returns(contact);
            var viewModelExpected = Mapper.Map<ViewModels.ContactEnterprise.Edit>(contact);

            var viewResult = enterpriseController.Edit() as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.ContactEnterprise.Edit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);

        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_contactEnterprise_is_not_valid()
        {
            httpContext.GetUserId().Returns(INVALID_ID);

            var result = enterpriseController.Edit();

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_student_when_studentId_is_valid()
        {
            var contact = _fixture.Create<ContactEnterprise>();
            httpContext.GetUserId().Returns(contact.Id);
            enterpriseRepository.GetById(contact.Id).Returns(contact);
            var studentViewModel = Mapper.Map<ViewModels.ContactEnterprise.Edit>(contact);
            studentViewModel.OldPassword = contact.Password;
            contact.Password = PasswordHash.CreateHash(contact.Password);

            var actionResult = enterpriseController.Edit(studentViewModel);

            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.Id == contact.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {
            var contact = _fixture.Create<ContactEnterprise>();
            httpContext.GetUserId().Returns(contact.Id);
            enterpriseRepository.GetById(contact.Id).Returns(contact);
            var contactEditPageViewModel = Mapper.Map<ContactEnterprise, ViewModels.ContactEnterprise.Edit>(contact);
            contactEditPageViewModel.OldPassword = contact.Password;
            contact.Password = PasswordHash.CreateHash(contact.Password);
            contactEditPageViewModel.Password = "Qwerty67";
            contactEditPageViewModel.PasswordConfirmation = contactEditPageViewModel.Password;

            var routeResult = enterpriseController.Edit(contactEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var contact = _fixture.Create<ContactEnterprise>();
            httpContext.GetUserId().Returns(contact.Id);
            var contactEditPageViewModel = _fixture.Build<ViewModels.ContactEnterprise.Edit>()
                                                      .With(x => x.Id, contact.Id)
                                                      .Create();
            enterpriseRepository.GetById(contact.Id).Returns(contact);
            enterpriseController.ModelState.AddModelError("Error", "Error");
            contact.Password = PasswordHash.CreateHash(contact.Password);

            var result = enterpriseController.Edit(contactEditPageViewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void edit_post_should_return_http_not_found_when_ID_is_not_valid()
        {
            var contact = _fixture.Create<ViewModels.ContactEnterprise.Edit>();
            httpContext.GetUserId().Returns(contact.Id);
            enterpriseRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = enterpriseController.Edit(contact);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

    }
}
