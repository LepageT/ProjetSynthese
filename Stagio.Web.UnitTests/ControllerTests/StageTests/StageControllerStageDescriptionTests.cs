using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerStageDescriptionTests : StageControllerBaseClassTests
    {
        [TestMethod]
        public void stage_viewStageInfo_should_render_view()
        {
            var stage = _fixture.Create<Stage>();
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);
            studentRepository.GetById(student.Id).Returns(student);
            stageRepository.GetById(stage.Id).Returns(stage);
            stage.Status = StageStatus.Accepted;
            var result = stageController.ViewStageInfo(stage.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void stage_viewStageInfo_should_return_httpnotfound_if_stageId_is_not_valid()
        {
            var result = stageController.ViewStageInfo(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
