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
        public void reactivate_action_should_render_view_with_email_and_enterprise_name()
        {
            //Arrange 
            var enterprise = _fixture.Create<Stagio.Domain.Entities.ContactEnterprise>();
            enterpriseRepository.GetById(enterprise.Id).Returns(enterprise);
            var viewModelExpected = Mapper.Map<ViewModels.ContactEnterprise.Create>(enterprise);


            //Action
            var viewResult = enterpriseController.Reactivate(enterprise.Email, null, null, enterprise.EnterpriseName, null, null) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.ContactEnterprise.Create;

            //Assert 
            Assert.AreEqual(viewModelExpected.Email, viewModelObtained.Email);
            Assert.AreEqual(viewModelExpected.EnterpriseName, viewModelObtained.EnterpriseName);
 
        }

        [TestMethod]
        public void reactivate_post_should_update_contact_enterprise_to_repository()
        {
            // Arrange   
            var enterprise = _fixture.CreateMany<ContactEnterprise>(1).ToList();
            var enterpriseViewModel = Mapper.Map<ViewModels.ContactEnterprise.Create>(enterprise[0]);
            enterpriseRepository.GetAll().Returns(enterprise.AsQueryable());


            // Action
            enterpriseController.Reactivate(enterpriseViewModel);

            // Assert
            EnterpriseRepositoryUpdateMethodShouldHaveReceived(enterprise[0]);
        }

        [TestMethod]
        public void reactivate_post_should_add_contact_enterprise_to_repository_if_it_is_not_already_there()
        {
            // Arrange   
            var enterprise1 = _fixture.CreateMany<ContactEnterprise>(1).ToList();
            var enterpriseViewModel = Mapper.Map<ViewModels.ContactEnterprise.Create>(enterprise1[0]);
            var enterprise2 = _fixture.CreateMany<ContactEnterprise>(1).ToList();
            enterpriseRepository.GetAll().Returns(enterprise2.AsQueryable());


            // Action
            enterpriseController.Reactivate(enterpriseViewModel);

            // Assert
            EnterpriseRepositoryAddMethodShouldHaveReceived(enterprise1[0]);
        }

        [TestMethod]
        public void reactivate_post_should_return_default_view_when_modelState_is_not_valid()
        {
            //Arrange
            var enterpriseViewModel = _fixture.Create<ViewModels.ContactEnterprise.Create>();
            enterpriseController.ModelState.AddModelError("Error", "Error");

            //Act
            var result = enterpriseController.Reactivate(enterpriseViewModel) as ViewResult;

            //Assert
            Assert.AreEqual(result.ViewName, "");
        }

        [TestMethod]
        public void reactivate_post_should_redirect_to_confirmation_on_success()
        {
            //Arrange
            var enterpriseViewModel = _fixture.Create<ViewModels.ContactEnterprise.Create>();
            enterpriseViewModel.Email = "blabla@hotmail.com";
            var enterprise = _fixture.CreateMany<ContactEnterprise>(2).ToList();
            var enterpriseToTest = _fixture.Create<ContactEnterprise>();
            enterpriseToTest.Email = "blabla@hotmail.com";
            enterprise.Add(enterpriseToTest);
            enterpriseRepository.GetAll().Returns(enterprise.AsQueryable());

            //Act
            var result = enterpriseController.Reactivate(enterpriseViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];


            //Assert
            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.CreateConfirmation);

        }

        [TestMethod]
        public void reactivate_post_should_not_add_contact_enterprise_to_repository_if_email_already_in_repository()
        {
            // Arrange   
            var enterprise1 = _fixture.Create<ContactEnterprise>();
            var enterpriseViewModel1 = Mapper.Map<ViewModels.ContactEnterprise.Create>(enterprise1);
            var email = enterpriseViewModel1.Email;
            var enterprise2 = _fixture.Create<ContactEnterprise>();
            var enterpriseViewModel2 = Mapper.Map<ViewModels.ContactEnterprise.Create>(enterprise2);
            enterpriseViewModel2.Email = email;
            List<ContactEnterprise> listEnterprises = new List<ContactEnterprise>();
            listEnterprises.Add(enterprise1);
            listEnterprises.Add(enterprise2);
            enterpriseRepository.GetAll().Returns(listEnterprises.AsQueryable());

            // Action
            enterpriseController.Reactivate(enterpriseViewModel1);
            enterpriseController.Reactivate(enterpriseViewModel2);

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


        private void EnterpriseRepositoryUpdateMethodShouldHaveReceived(ContactEnterprise enterprise)
        {
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.Id == enterprise.Id));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.Email == enterprise.Email));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.FirstName == enterprise.FirstName));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.LastName == enterprise.LastName));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.EnterpriseName == enterprise.EnterpriseName));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.Telephone == enterprise.Telephone));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.Poste == enterprise.Poste));
            enterpriseRepository.Received().Update(Arg.Is<ContactEnterprise>(x => x.Password == enterprise.Password));
        }
    }
}
