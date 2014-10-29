using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Apply;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerListStudentApplyTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contactEnterpriseController_listStudentApply_should_render_view()
        {
            var applies = _fixture.CreateMany<Apply>(2).ToList();
            var students = _fixture.CreateMany<Student>(2).ToList();
            var stage = _fixture.CreateMany<Stage>(1).ToList();
            applies[0].IdStudent = students[0].Id;
            applies[0].IdStage = stage[0].Id;
            applies[1].IdStudent = students[1].Id;
            applies[1].IdStage = stage[0].Id;
            studentRepository.GetAll().Returns(students.AsQueryable());
            stageRepository.GetAll().Returns(stage.AsQueryable());
            applyRepository.GetAll().Returns(applies.AsQueryable());

            var result = enterpriseController.ListStudentApply(stage[0].Id) as ViewResult;

            result.ViewName.Should().Be("");

        }


        [TestMethod]
        public void contactEnterpriseController_listStudentApply_should_render_view_with_apply()
        {
            var applies = _fixture.CreateMany<Apply>(2).ToList();
            var students = _fixture.CreateMany<Student>(2).ToList();
            var stage = _fixture.CreateMany<Stage>(1).ToList();
            applies[0].IdStudent = students[0].Id;
            applies[0].IdStage = stage[0].Id;
            applies[1].IdStudent = students[1].Id;
            applies[1].IdStage = stage[0].Id;
            studentRepository.GetAll().Returns(students.AsQueryable());
            stageRepository.GetAll().Returns(stage.AsQueryable());
            applyRepository.GetAll().Returns(applies.AsQueryable());

            var result = enterpriseController.ListStudentApply(stage[0].Id) as ViewResult;
            var model = result.Model as List<StudentApply>;

            model.Count.Should().NotBe(0);
        }


        [TestMethod]
        public void contactEnterpriseController_listStudentApply_with_invalid_id_should_return_httpnotfound()
        {
            var result = enterpriseController.ListStudentApply(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();

        }
    }
}
