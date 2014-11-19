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
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseCreateTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contactEnterprise_create_get_should_return_create_view()
        {
            var result = enterpriseController.Create() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contactEnterprise_create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(3);
            var contactEnterprise = contactsEnterprise.First();
            contactEnterprise.Active = false;
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.ContactEnterprise.Create>();
            viewModel.Email = contactEnterprise.Email;
            viewModel.FirstName = contactEnterprise.FirstName;
            viewModel.LastName = contactEnterprise.LastName;
            viewModel.PasswordConfirmation = viewModel.Password;
            enterpriseController.ModelState.AddModelError("Error", "Error");

            var result = enterpriseController.Create(viewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contactEnterprise_create_post_should_return_default_view_when_email_is_already_used()
        {
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(2);
            var contactEnterprise1 = contactsEnterprise.First();
            contactEnterprise1.Email = "test@blabla.com";
            var contactEnterprise2 = _fixture.Create<ViewModels.ContactEnterprise.Create>();
            contactEnterprise2.Email = contactEnterprise1.Email;
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());

            var viewResult = enterpriseController.Create(contactEnterprise2) as ViewResult;

            viewResult.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contactEnterprise_create_post_should_return_index_on_success()
        {
            var contactsEnterprise = _fixture.CreateMany<ContactEnterprise>(3);
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            contactEnterprise.Active = false;
            enterpriseRepository.GetAll().Returns(contactsEnterprise.AsQueryable());
            var viewModel = _fixture.Create<ViewModels.ContactEnterprise.Create>();
            viewModel.Email = contactEnterprise.Email;
            viewModel.FirstName = contactEnterprise.FirstName;
            viewModel.LastName = contactEnterprise.LastName;
            viewModel.PasswordConfirmation = viewModel.Password;

            var routeResult = enterpriseController.Create(viewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.ContactEnterprise.Views.ViewNames.CreateConfirmation);
        }

        
    }
}
