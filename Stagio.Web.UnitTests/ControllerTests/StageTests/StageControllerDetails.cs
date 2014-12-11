using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Ploeh;
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerDetails : StageControllerBaseClassTests
    {
        [TestMethod]
        public void details_stage_should_render_a_view_details()
        {
            var stage = _fixture.Create<Stage>();

            var result = stageController.Details(stage.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void details_accept_stage_should_render_listStagesViews()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            var result = stageController.Details("Accepter", stage.Id) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.Stage.Views.ViewNames.ListNewStages);
        }

        [TestMethod]
        public void details_accept_stage_should_render_default_view_if_invalid_id()
        {
            var result = stageController.Details("Accepter", INVALID_ID) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void details_refuse_stage_should_render_listStagesViews()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var user = _fixture.Create<Domain.Entities.Coordinator>();
            httpContextService.GetUserId().Returns(user.Id);
            coordinatorRepository.GetById(user.Id).Returns(user);

            var result = stageController.Details("Refuser", stage.Id) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];
            
            routeAction.Should().Be(MVC.Stage.Views.ViewNames.ListNewStages);
        }

        [TestMethod]
        public void details_refuse_stage_should_render_default_view_if_invalid_id()
        {
            var result = stageController.Details("Refuser", INVALID_ID) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void details_remove_stage_should_render_listStagesViews()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            var result = stageController.Details("Retirer", stage.Id) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];

            routeAction.Should().Be(MVC.Stage.Views.ViewNames.ListNewStages);
        }


    }
}
