using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;
using Ploeh;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Stage;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerListNewStagesTests : AllControllersBaseClassTests
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
            var stages = _fixture.CreateMany<Stage>(5).AsQueryable();

            stageRepository.GetAll().Returns(stages);

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as IEnumerable<ListNewStages>;

            model.Count().Should().NotBe(0);
        }

        [TestMethod]
        public void stage_listNewStages_should_not_render_ListNewStages_whenAcceptedByCoordinator_is_true()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            stages[0].Status = 2;
            stages[1].Status = 0;

            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as IEnumerable<ListNewStages>;

            model.Count().Should().Be(1);
        }

        [TestMethod]
        public void stage_listNewStages_should_render_ListNewStages_whenAcceptedByCoordinator_is_false()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            stages[0].Status = 0;
            stages[1].Status = 0;

            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as IEnumerable<ListNewStages>;

            model.Count().Should().Be(2);
        }
    }
}
