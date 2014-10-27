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
        public void details_stage_should_redirect_list_if_stage_removed_by_coordinator()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var result = stageController.Details("Retirer", stage.Id) as RedirectToRouteResult;
            var routeAction = result.RouteValues["Action"];
            routeAction.Should().Be(MVC.Stage.Views.ViewNames.ListNewStages);
        }



    }
}
