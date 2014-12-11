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
using Stagio.Utilities.Encryption;

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
     public class StageAgreementControllerEdit : StageAgreementControllerBaseClassTests
    {
        [TestMethod]
        public void edit_stageAgreement_should_render_view_when_id_is_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var stage = _fixture.Create<Stage>();
            var student = _fixture.Create<ApplicationUser>();
            var contactenterprise = _fixture.Create<ApplicationUser>();
            var coordinator = _fixture.Create<ApplicationUser>();
            student.UserName = "11111111";
            accountRepository.GetById(student.Id).Returns(student);
            accountRepository.GetById(contactenterprise.Id).Returns(contactenterprise);
            accountRepository.GetById(coordinator.Id).Returns(coordinator);
            stageRepository.GetById(stage.Id).Returns(stage);
            stageAgreement.IdStage = stage.Id;
            stageAgreement.IdContactEnterpriseSigned = contactenterprise.Id;
            stageAgreement.IdCoordinatorSigned = coordinator.Id;
            stageAgreement.IdStudentSigned = student.Id;
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageAgreement.Renumeration = true;
            
            var viewResult = stageAgreementController.Edit(stageAgreement.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.StageAgreement.EditStageAgreement;

            viewModelObtained.Renumeration.ShouldBeEquivalentTo(true); 
        }


        [TestMethod]
        public void edit_should_return_http_not_found_when_stageAgreementId_is_not_valid()
        {
            var result = stageAgreementController.Edit(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_stageAgreement_when_stageAgreementId_is_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            var stageAgreementViewModel = Mapper.Map<ViewModels.StageAgreement.EditStageAgreement>(stageAgreement);
            stageAgreementViewModel.Adresse = "27 rang Matalick Sud, Causapscal";
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageRepository.GetById(stage.Id).Returns(stage);


            stageAgreementController.Edit(stageAgreementViewModel);

            stageAgreementRepository.Received().Update(Arg.Is<StageAgreement>(x => x.Id == stageAgreementViewModel.Id));
        }
        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            accountRepository.GetById(student.Id).Returns(student);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageAgreementController.ModelState.AddModelError("Error", "Error");
            stageRepository.GetById(stage.Id).Returns(stage);

            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.StageAgreement.Views.ViewNames.Edit);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_coordinator_signature_is_not_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var coordinator = _fixture.Create<Coordinator>();
            httpContextService.GetUserId().Returns(coordinator.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageAgreement.CoordinatorHasSigned = false;
            stageAgreementEditPageViewModel.StudentSignature = null;
            stageAgreementEditPageViewModel.ContactEnterpriseSignature= null;
            stageAgreementEditPageViewModel.CoordinatorSignature = "ABC";
            accountRepository.GetById(coordinator.Id).Returns(coordinator);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageRepository.GetById(stage.Id).Returns(stage);

            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.StageAgreement.Views.ViewNames.Edit);
        }


        [TestMethod]
        public void edit_post_should_return_index_when_coordinator_signature_is_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var coordinator = _fixture.Create<Coordinator>();
            httpContextService.GetUserId().Returns(coordinator.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageAgreement.CoordinatorHasSigned = false;
            stageAgreementEditPageViewModel.StudentSignature = null;
            stageAgreementEditPageViewModel.ContactEnterpriseSignature = null;
            accountService.ValidatePassword(coordinator.Password, stageAgreementEditPageViewModel.CoordinatorSignature)
                .Returns(true);
            accountRepository.GetById(coordinator.Id).Returns(coordinator);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            coordinatorRepository.GetById(stageAgreement.IdCoordinatorSigned).Returns(coordinator);
            stageRepository.GetById(stage.Id).Returns(stage);

            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_student_signature_is_not_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageAgreement.StudentHasSigned = false;
            stageAgreementEditPageViewModel.ContactEnterpriseSignature = null;
            stageAgreementEditPageViewModel.CoordinatorSignature = null;
            stageAgreementEditPageViewModel.StudentSignature = "ABC";
            accountRepository.GetById(student.Id).Returns(student);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageRepository.GetById(stage.Id).Returns(stage);

            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.StageAgreement.Views.ViewNames.Edit);
        }


        [TestMethod]
        public void edit_post_should_return_index_when_student_signature_is_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageAgreement.StudentHasSigned = false;
            stageAgreementEditPageViewModel.CoordinatorSignature = null;
            stageAgreementEditPageViewModel.ContactEnterpriseSignature = null;
            accountService.ValidatePassword(student.Password, stageAgreementEditPageViewModel.StudentSignature)
                .Returns(true);
            accountRepository.GetById(student.Id).Returns(student);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageRepository.GetById(stage.Id).Returns(stage);
            studentRepository.GetById(stageAgreement.IdStudentSigned).Returns(student);

            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_contactEnterprise_signature_is_not_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            httpContextService.GetUserId().Returns(contactEnterprise.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageAgreement.ContactEnterpriseHasSigned = false;
            stageAgreementEditPageViewModel.StudentSignature = null;
            stageAgreementEditPageViewModel.CoordinatorSignature = null;
            stageAgreementEditPageViewModel.ContactEnterpriseSignature = "ABC";
            accountRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageRepository.GetById(stage.Id).Returns(stage);


            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.StageAgreement.Views.ViewNames.Edit);
        }


        [TestMethod]
        public void edit_post_should_return_index_when_contactEnterprise_signature_is_valid()
        {
            var stageAgreement = _fixture.Create<StageAgreement>();
            var contactEnterprise = _fixture.Create<ContactEnterprise>();
            httpContextService.GetUserId().Returns(contactEnterprise.Id);
            var stageAgreementEditPageViewModel = _fixture.Build<ViewModels.StageAgreement.EditStageAgreement>()
                                                      .With(x => x.Id, stageAgreement.Id)
                                                      .Create();
            var stage = _fixture.Create<Stage>();
            stage.Id = stageAgreement.IdStage;
            stageAgreement.ContactEnterpriseHasSigned = false;
            stageAgreementEditPageViewModel.CoordinatorSignature = null;
            stageAgreementEditPageViewModel.StudentSignature = null;
            accountService.ValidatePassword(contactEnterprise.Password, stageAgreementEditPageViewModel.ContactEnterpriseSignature)
                .Returns(true);
            accountRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);
            stageAgreementRepository.GetById(stageAgreement.Id).Returns(stageAgreement);
            stageRepository.GetById(stage.Id).Returns(stage);
            contactEnterpriseRepository.GetById(contactEnterprise.Id).Returns(contactEnterprise);


            var routeResult = stageAgreementController.Edit(stageAgreementEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Home.Views.ViewNames.Index);
        }


    }
}
