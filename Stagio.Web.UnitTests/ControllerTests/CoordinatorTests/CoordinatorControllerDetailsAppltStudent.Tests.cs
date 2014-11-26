using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerDetailsApplyStudentTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_detailsStudentApply_should_render_view_with_student_details()
        {
            var apply = _fixture.Create<Apply>();
            var student = _fixture.Create<Student>();
            var stage = _fixture.Create<Stage>();
            apply.IdStudent = student.Id;
            apply.IdStage = stage.Id;
            applyRepository.GetById(apply.Id).Returns(apply);
            studentRepository.GetById(student.Id).Returns(student);
            stageRepository.GetById(stage.Id).Returns(stage);

            var result = coordinatorController.DetailsApplyStudent(apply.Id, false) as ViewResult;

            result.ViewName.Should().Be("");
        }
        [TestMethod]
        public void coordinator_detailsStudentApply_with_invalid_id_should_return_httpnotfound()
        {
            var result = coordinatorController.DetailsApplyStudent(INVALID_ID, false);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
