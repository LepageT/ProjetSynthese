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

namespace Stagio.Web.UnitTests.ControllerTests.EnterpriseTests
{
    [TestClass]
    public class EnterpriseControllerCreateTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void create_action_should_render_view_with_email_and_enterprise_name()
        {
            //Arrange 
            var enterprise = _fixture.Create<Stagio.Domain.Entities.ContactEnterprise>();
            enterpriseRepository.GetById(enterprise.Id).Returns(enterprise);
            var viewModelExpected = Mapper.Map<ViewModels.Enterprise.Create>(enterprise);


            //Action
            var viewResult = enterpriseController.Create(enterprise.Email, null, null, enterprise.EnterpriseName, null, null) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Enterprise.Create;

            //Assert 
            Assert.AreEqual(viewModelExpected.Email, viewModelObtained.Email);
            Assert.AreEqual(viewModelExpected.EnterpriseName, viewModelObtained.EnterpriseName);
 
        }

        [TestMethod]
        public void create_post_should_add_enterprise_to_repository()
        {
            // Arrange   
            var enterprise = _fixture.Create<ContactEnterprise>();
            var enterpriseViewModel = Mapper.Map<ViewModels.Enterprise.Create>(enterprise);

            // Action
            enterpriseController.Create(enterpriseViewModel);

            // Assert
            EnterpriseRepositoryAddMethodShouldHaveReceived(enterprise);
        }

        [TestMethod]
        public void create_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var enterpriseViewModel = _fixture.Create<ViewModels.Enterprise.Create>();
            enterpriseController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = enterpriseController.Create(enterpriseViewModel) as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void create_post_should_redirect_to_home_index_on_success()
        {
            //Arrange
            var enterpriseViewModel = _fixture.Create<ViewModels.Enterprise.Create>();

            //Act
            var result = enterpriseController.Create(enterpriseViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];


            //Assert
            action.ShouldBeEquivalentTo(MVC.Home.Views.ViewNames.Index);

        }

        [TestMethod]
        public void create_post_should_not_add_enterprise_to_repository_if_email_already_in_repository()
        {
            // Arrange   
            var enterprise1 = _fixture.Create<ContactEnterprise>();
            var enterpriseViewModel1 = Mapper.Map<ViewModels.Enterprise.Create>(enterprise1);
            var email = enterpriseViewModel1.Email;
            var enterprise2 = _fixture.Create<ContactEnterprise>();
            var enterpriseViewModel2 = Mapper.Map<ViewModels.Enterprise.Create>(enterprise2);
            enterpriseViewModel2.Email = email;

            // Action
            enterpriseController.Create(enterpriseViewModel1);
            enterpriseController.Create(enterpriseViewModel2);

            // Assert
            enterpriseRepository.DidNotReceive().Add(Arg.Is<ContactEnterprise>(x => x.Email == enterprise2.Email));
        }

        private void EnterpriseRepositoryAddMethodShouldHaveReceived(ContactEnterprise enterprise)
        {
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.Id == enterprise.Id));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.Email == enterprise.Email));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.FirstName == enterprise.FirstName));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.LastName == enterprise.LastName));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.EnterpriseName == enterprise.EnterpriseName));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.Telephone == enterprise.Telephone));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.Poste == enterprise.Poste));
            enterpriseRepository.Received().Add(Arg.Is<ContactEnterprise>(x => x.Password == enterprise.Password));
        }
    }
}
