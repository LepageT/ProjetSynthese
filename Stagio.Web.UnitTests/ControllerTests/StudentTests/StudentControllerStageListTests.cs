using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerStageListTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void stageList_should_return_list_with_stages()
        {
            var stages = _fixture.CreateMany<Stage>(3).ToList();
            foreach (var stage in stages)
            {
                stage.Status = StageStatus.Accepted;
            }
            stages[0].LimitDate = DateTime.Today.AddDays(3).ToShortDateString();
            stages[1].LimitDate = DateTime.Today.AddDays(3).ToShortDateString();
            stages[2].LimitDate = DateTime.Today.AddDays(3).ToShortDateString();
         
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = studentController.DisplayStageList() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Student.StageList>;

            model.ShouldBeEquivalentTo(stages, options => options.ExcludingMissingProperties());
        }

        [TestMethod]
        public void stageList_should_not_return_stages_when_limitDate_is_past()
        {
            var stages = _fixture.CreateMany<Stage>(2).ToList();
            foreach (var stage in stages)
            {
                stage.Status = StageStatus.Accepted;
            }
            stages[0].LimitDate = DateTime.Today.AddDays(3).ToShortDateString();
            stages[1].LimitDate = new DateTime(2013, 12, 12).ToShortDateString();
            stageRepository.GetAll().Returns(stages.AsQueryable());

            var result = studentController.DisplayStageList() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Student.StageList>;

            
            model.Should().NotBeEquivalentTo(stages);
        }
    }
}
