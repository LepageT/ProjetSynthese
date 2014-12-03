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
            var user = _fixture.Create<Domain.Entities.ContactEnterprise>();
            stage[0].CompanyName = user.EnterpriseName;
            applies[0].IdStudent = students[0].Id;
            applies[0].IdStage = stage[0].Id;
            applies[1].IdStudent = students[1].Id;
            applies[1].IdStage = stage[0].Id;
            httpContext.GetUserId().Returns(user.Id);
            enterpriseRepository.GetById(user.Id).Returns(user);
            studentRepository.GetAll().Returns(students.AsQueryable());
            stageRepository.GetById(stage[0].Id).Returns(stage[0]);
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
            var user = _fixture.Create<Domain.Entities.ContactEnterprise>();
            stage[0].CompanyName = user.EnterpriseName;
            applies[0].IdStudent = students[0].Id;
            applies[0].IdStage = stage[0].Id;
            applies[1].IdStudent = students[1].Id;
            applies[1].IdStage = stage[0].Id;
            httpContext.GetUserId().Returns(user.Id);
            enterpriseRepository.GetById(user.Id).Returns(user);
            studentRepository.GetAll().Returns(students.AsQueryable());
            stageRepository.GetById(stage[0].Id).Returns(stage[0]);
            applyRepository.GetAll().Returns(applies.AsQueryable());

            var result = enterpriseController.ListStudentApply(stage[0].Id) as ViewResult;
            var model = result.Model as List<StudentApply>;

            model.Count.Should().NotBe(0);
        }


        [TestMethod]
        public void contactEnterpriseController_listStudentApply_with_invalid_id_should_return_httpnotfound()
        {
            var user = _fixture.Create<Domain.Entities.ContactEnterprise>();
            var stage = _fixture.Create<Domain.Entities.Stage>();
            stage.Id = INVALID_ID;
            httpContext.GetUserId().Returns(user.Id);
            enterpriseRepository.GetById(user.Id).Returns(user);
            stageRepository.GetById(stage.Id).Returns(stage);
            
            var routeResult = enterpriseController.ListStudentApply(INVALID_ID) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be("ListStage");

        }
    }
}
