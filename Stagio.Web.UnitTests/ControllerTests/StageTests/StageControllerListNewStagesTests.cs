
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Stage;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerListNewStagesTests : StageControllerBaseClassTests
    {
        [TestMethod]
        public void stage_listNewStages_should_render_view()
        {
            var stages = _fixture.CreateMany<Stage>(5).AsQueryable();
            stageRepository.GetAll().Returns(stages);

            var result = stageController.ListNewStages() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void stage_listNewStages_should_render_view_with_ListNewStages()
        {
            var stages = _fixture.CreateMany<Stage>(5).ToList();
            stages[0].AcceptedByCoordinator = 0;
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as ListAllStages;

            int nbStages = model.ListNewStages.Count();

            nbStages.Should().NotBe(0);
        }

        [TestMethod]
        public void stage_listNewStages_should__render_ListNewStages_whenAcceptedByCoordinator()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            stages[0].AcceptedByCoordinator = 1;
            stages[1].AcceptedByCoordinator = 0;

            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as ListAllStages;

            int nbStages = model.ListStagesAccepted.Count();

            nbStages.Should().Be(1);
        }

        [TestMethod]
        public void stage_listNewStages_should_render_ListNewStages_whenRefusedByCoordinator()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            stages[0].AcceptedByCoordinator = 0;
            stages[1].AcceptedByCoordinator = 2;

            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as ListAllStages;

            int nbStages = model.ListStagesRefused.Count();

            nbStages.Should().Be(1);
        }
    }
}
