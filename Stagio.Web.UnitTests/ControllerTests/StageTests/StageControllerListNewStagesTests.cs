
using System;
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
            var applies = _fixture.CreateMany<Apply>(2);
            var interviews = _fixture.CreateMany<Interview>(2);
            applyRepository.GetAll().Returns(applies.AsQueryable());
            interviewRepository.GetAll().Returns(interviews.AsQueryable());
            stageRepository.GetAll().Returns(stages);

            var result = stageController.ListNewStages() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void stage_listNewStages_should_render_view_with_ListNewStages()
        {
            var stages = _fixture.CreateMany<Stage>(5).ToList();
            var applies = _fixture.CreateMany<Apply>(2);
            var interviews = _fixture.CreateMany<Interview>(2);
            applyRepository.GetAll().Returns(applies.AsQueryable());
            interviewRepository.GetAll().Returns(interviews.AsQueryable());
            stages[0].Status = 0;
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as ListAllStages;
            int nbStages = model.ListNewStages.Count();

            nbStages.Should().NotBe(0);
        }

        [TestMethod]
        public void stage_listNewStages_should__render_ListNewStages_whenStatus()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            var applies = _fixture.CreateMany<Apply>(2);
            var interviews = _fixture.CreateMany<Interview>(2);
            stages[0].Status = StageStatus.Accepted;
            stages[1].Status = StageStatus.New;
            applyRepository.GetAll().Returns(applies.AsQueryable());
            interviewRepository.GetAll().Returns(interviews.AsQueryable());
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
            var applies = _fixture.CreateMany<Apply>(2).ToList();
            var interviews = _fixture.CreateMany<Interview>(2).ToList();
            applies[1].IdStage = stages[1].Id;
            interviews[1].StageId = stages[1].Id;
            interviews[1].DateAcceptOffer = DateTime.Today.ToShortDateString();
            applyRepository.GetAll().Returns(applies.AsQueryable());
            interviewRepository.GetAll().Returns(interviews.AsQueryable());
            stages[0].Status = StageStatus.New;
            stages[1].Status = StageStatus.Refused;
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = stageController.ListNewStages() as ViewResult;
            var model = result.Model as ListAllStages;
            int nbStages = model.ListStagesRefused.Count();

            nbStages.Should().Be(1);
        }
    }
}
