using System;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerDraftEdit : StageControllerBaseClassTests
    {
        [TestMethod]
        public void edit_draft_should_return_view_with_stageViewModel_when_stageId_is_valid()
        {
            var user = _fixture.Create<ContactEnterprise>();
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            contactEnterpriseRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            stage.CompanyName = user.EnterpriseName;
            var viewModelExpected = Mapper.Map<ViewModels.Stage.Edit>(stage);

            var viewResult = stageController.DraftEdit(stage.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Stage.Edit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected);

        }

        [TestMethod]
        public void edit_draft_should_return_http_not_found_when_studentId_is_not_valid()
        {
            var result = stageController.DraftEdit(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_draft_post_should_update_stage_when_stageId_is_valid()
        {
            var user = _fixture.Create<ContactEnterprise>();
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            contactEnterpriseRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            stage.CompanyName = user.EnterpriseName;
            var stageViewModel = Mapper.Map<ViewModels.Stage.Edit>(stage);
            stageViewModel.ContactToName = "Bobino";

            stageController.DraftEdit(stageViewModel, "Enregistrer");

            stageRepository.Received().Update(Arg.Is<Stage>(x => x.Id == stage.Id));
        }

        [TestMethod]
        public void edit_save_draft_post_should_redirect_to_index_on_success()
        {
            var user = _fixture.Create<ContactEnterprise>();
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            contactEnterpriseRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            stage.CompanyName = user.EnterpriseName;
            var stageEditPageViewModel = Mapper.Map<Stage, ViewModels.Stage.Edit>(stage);
            stageEditPageViewModel.ContactToName = "Bobino";

            var routeResult = stageController.DraftEdit(stageEditPageViewModel, "Enregistrer") as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.ContactEnterprise.Views.ViewNames.DraftList);
        }

        [TestMethod]
        public void edit_publish_draft_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var stageEditPageViewModel = _fixture.Build<ViewModels.Stage.Edit>()
                                                      .With(x => x.Id, stage.Id)
                                                      .Create();
            stageRepository.GetById(stage.Id).Returns(stage);
            stageController.ModelState.AddModelError("Error", "Error");

            var result = stageController.DraftEdit(stageEditPageViewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void edit_draft_post_should_return_http_not_found_when_stageID_is_not_valid()
        {
            var user = _fixture.Create<ContactEnterprise>();
            var stage = _fixture.Create<ViewModels.Stage.Edit>();
            stageRepository.GetById(Arg.Any<int>()).Returns(a => null);
            contactEnterpriseRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            var result = stageController.DraftEdit(stage, "Enregistrer");

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_publish_draft_post_should_redirect_to_index_on_success()
        {
            var user = _fixture.Create<ContactEnterprise>();
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            contactEnterpriseRepository.GetById(user.Id).Returns(user);
            httpContextService.GetUserId().Returns(user.Id);
            stage.CompanyName = user.EnterpriseName;
            var stageEditPageViewModel = Mapper.Map<Stage, ViewModels.Stage.Edit>(stage);
            stageEditPageViewModel.ContactToName = "Bobino";

            var routeResult = stageController.DraftEdit(stageEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.ContactEnterprise.Views.ViewNames.CreateStageSucceed);
        }

    }
}
