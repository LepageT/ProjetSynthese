using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerEditTests : StageControllerBaseClassTests
    {
         
        [TestMethod]
        public void edit_should_return_view_with_stageViewModel_when_stageId_is_valid()
        {
            var stage = _fixture.Create<Domain.Entities.Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var viewModelExpected = Mapper.Map<ViewModels.Stage.Edit>(stage);
            
            var viewResult = stageController.Edit(stage.Id) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Stage.Edit;

            viewModelObtained.ShouldBeEquivalentTo(viewModelExpected); 

        }

        [TestMethod]
        public void edit_should_return_http_not_found_when_studentId_is_not_valid()
        {
            var result = stageController.Edit(INVALID_ID);
            
            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void edit_post_should_update_stage_when_stageId_is_valid()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var stageViewModel = Mapper.Map<ViewModels.Stage.Edit>(stage);
            stageViewModel.ContactToName = "Bobino";

            stageController.Edit(stageViewModel);

            stageRepository.Received().Update(Arg.Is<Stage>(x => x.Id == stage.Id));
        }

        [TestMethod]
        public void edit_post_should_redirect_to_index_on_success()
        {

       
            
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var stageEditPageViewModel = Mapper.Map<Stage, ViewModels.Stage.Edit>(stage);
            stageEditPageViewModel.ContactToName = "Bobino";

            var routeResult = stageController.Edit(stageEditPageViewModel) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.ContactEnterprise.Views.ViewNames.ListStage);
        }

        [TestMethod]
        public void edit_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var stageEditPageViewModel = _fixture.Build<ViewModels.Stage.Edit>()
                                                      .With(x => x.Id, stage.Id)
                                                      .Create();
           stageRepository.GetById(stage.Id).Returns(stage);
           stageController.ModelState.AddModelError("Error", "Error");
            
            var result = stageController.Edit(stageEditPageViewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void edit_post_should_return_http_not_found_when_stageID_is_not_valid()
        {
            var stage = _fixture.Create<ViewModels.Stage.Edit>();
            stageRepository.GetById(Arg.Any<int>()).Returns(a => null);

            var result = stageController.Edit(stage);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
