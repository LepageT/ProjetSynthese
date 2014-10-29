using System;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contactEnterprise_detailsStudentApply_should_render_view_with_student_details()
        {
            var apply = _fixture.CreateMany<Apply>(1).ToList();
            var student = _fixture.CreateMany<Student>(1).ToList();
            var stage = _fixture.CreateMany<Stage>(1).ToList();

            apply[0].IdStudent = student[0].Id;
            apply[0].IdStage = stage[0].Id;

            applyRepository.GetAll().Returns(apply.AsQueryable());
            studentRepository.GetAll().Returns(student.AsQueryable());
            stageRepository.GetAll().Returns(stage.AsQueryable());

            var result = enterpriseController.DetailsStudentApply(apply[0].Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contactEnterpriseController_detailsStudentApply_with_invalid_id_should_return_httpnotfound()
        {
            var result = enterpriseController.DetailsStudentApply(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();

        }
    }
}
