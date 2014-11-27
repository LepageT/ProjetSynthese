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
namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_return_confirmation_accept_view_on_accept()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            var student = _fixture.Create<Student>();
            studentRepository.GetById(apply.IdStudent).Returns(student);
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(apply.IdStage).Returns(stage);
            applyRepository.GetById(apply.Id).Returns(apply);
            
            var result = enterpriseController.DetailsStudentApplyPost("Je suis intéressé", apply.Id) as ViewResult;

            result.ViewName.Should().Be(MVC.ContactEnterprise.Views.ViewNames.AcceptApplyConfirmation);
        }
        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_return_confirmation_refuse_view_on_refuse()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            var student = _fixture.Create<Student>();
            studentRepository.GetById(apply.IdStudent).Returns(student);
            applyRepository.GetById(apply.Id).Returns(apply);
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(apply.IdStage).Returns(stage);

            var result = enterpriseController.DetailsStudentApplyPost("Je ne suis pas intéressé", apply.Id) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.RefuseApplyConfirmation);
        }
        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_update_apply_status_on_accept()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            var student = _fixture.Create<Student>();
            studentRepository.GetById(apply.IdStudent).Returns(student);
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(apply.IdStage).Returns(stage);
            applyRepository.GetById(apply.Id).Returns(apply);

            var result = enterpriseController.DetailsStudentApplyPost("Accepter", apply.Id) as ViewResult;

            applyRepository.Update(Arg.Is<Apply>(x => x.Status == StatusApply.Accepted));
        }
        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_update_apply_status_on_refuse()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.Add(apply);
            applyRepository.GetById(apply.Id).Returns(apply);
            var student = _fixture.Create<Student>();
            studentRepository.GetById(apply.IdStudent).Returns(student);

            var result = enterpriseController.DetailsStudentApplyPost("Accepter", apply.Id) as ViewResult;

            applyRepository.Update(Arg.Is<Apply>(x => x.Status == StatusApply.Refused));

            
        }
        [TestMethod]
        public void contact_enterprise_DetailsStudentApply_post_should_return_default_view_when_apply_is_invalid()
        {
            var viewResult = enterpriseController.DetailsStudentApplyPost("Accepter", INVALID_ID) as ViewResult;
            var viewModelObtained = viewResult.ViewData.Model as ViewModels.Apply.StudentApply;

            viewResult.ViewName.Should().Be("");
        }

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

            var result = enterpriseController.DetailsStudentApply(apply[0].Id, false) as ViewResult;

            result.ViewName.Should().Be("");
        }
        [TestMethod]
        public void contactEnterpriseController_detailsStudentApply_with_invalid_id_should_return_httpnotfound()
        {
            var result = enterpriseController.DetailsStudentApply(INVALID_ID, false);

            result.Should().BeOfType<HttpNotFoundResult>();
        }

        [TestMethod]
        public void contactEnterpriseController_detailsStudentApply_with_invalid_files_return_default_view()
        {
            var apply = _fixture.CreateMany<Apply>(1).ToList();
            var student = _fixture.CreateMany<Student>(1).ToList();
            var stage = _fixture.CreateMany<Stage>(1).ToList();
            apply[0].IdStudent = student[0].Id;
            apply[0].IdStage = stage[0].Id;
            applyRepository.GetAll().Returns(apply.AsQueryable());
            studentRepository.GetAll().Returns(student.AsQueryable());
            stageRepository.GetAll().Returns(stage.AsQueryable());

            var result = enterpriseController.DetailsStudentApply(apply[0].Id, true) as ViewResult;

            result.ViewName.Should().Be("");
        }

       
    }
}