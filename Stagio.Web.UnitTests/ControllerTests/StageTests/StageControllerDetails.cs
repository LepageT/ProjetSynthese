using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Ploeh;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerDetails : AllControllersBaseClassTests
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
            var result = stageController.Details("Accepter", 999999999) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void details_refuse_stage_should_render_listStagesViews()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            var result = stageController.Details("Refuser", stage.Id) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];
            
            routeAction.Should().Be(MVC.Stage.Views.ViewNames.ListNewStages);
        }

        [TestMethod]
        public void details_refuse_stage_should_render_default_view_if_invalid_id()
        {
            var result = stageController.Details("Refuser", 999999999) as ViewResult;

            result.ViewName.Should().Be("");
        }


    }
}
