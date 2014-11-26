using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Interviews;

namespace Stagio.Web.UnitTests.ControllerTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerCreateTests : InterviewControllerBaseClassTests
    {
        [TestMethod]
        public void interview_create_get_should_return_create_view()
        {
            var student = _fixture.Create<Student>();
            httpContextService.GetUserId().Returns(student.Id);

            var appliedList = _fixture.CreateMany<Apply>(3);
            applyRepository.GetAll().Returns(appliedList.AsQueryable());
            var result = interviewController.Create() as ViewResult;

            result.ViewName.Should().Be(""); 
        }

        [TestMethod]
        public void interview_create_post_should_return_default_view_when_modelState_is_not_valid()
        {

            var interview = _fixture.Create<ViewModels.Interviews.Create>();
            interviewController.ModelState.AddModelError("Error", "Error");

            var result = interviewController.Create(interview) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void interview_create_post_should_return_confirmation_on_success()
        {
            var interview = _fixture.Create<ViewModels.Interviews.Create>();
            var idStudent = userlogin();
            var stage = _fixture.Create <Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);
            var student = _fixture.Create<Student>();
            student.Id = idStudent;
            studentRepository.GetById(student.Id).Returns(student);
            interview.Date = DateTime.Now.ToLongDateString();
            interview.StageId = stage.Id;
            interview.StudentId = idStudent;

            var result = interviewController.Create(interview) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.Interview.Views.ViewNames.InterviewCreateConfirmation);
        }

        [TestMethod]
        public void interview_create_should_have_many_stageTitles_in_list()
        {
            var interview = _fixture.Create<ViewModels.Interviews.Create>();
            var applies = _fixture.CreateMany<Apply>(3).ToList();
            int idStudent = userlogin();
            applies[0].IdStudent = idStudent;
            applies[1].IdStudent = idStudent;
            var stage1 = _fixture.Create<Stage>();
            var stage2 = _fixture.Create<Stage>();
            stageRepository.GetById(applies[0].IdStage).Returns(stage1);
            stageRepository.GetById(applies[1].IdStage).Returns(stage2);
            applyRepository.GetAll().Returns(applies.AsQueryable());

            var result = interviewController.Create() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void interview_already_exist_for_a_stage_return_default_view()
        {
            var interview = _fixture.CreateMany<Interview>(1).ToList();
            var applies = _fixture.CreateMany<Apply>(3).ToList();
            int idStudent = userlogin();
            applies[0].IdStudent = idStudent;
            applies[1].IdStudent = idStudent;
            var stage1 = _fixture.Create<Stage>();
            var stage2 = _fixture.Create<Stage>();
            stageRepository.GetById(applies[0].IdStage).Returns(stage1);
            stageRepository.GetById(applies[1].IdStage).Returns(stage2);
            applyRepository.GetAll().Returns(applies.AsQueryable());
            interview[0].Date = DateTime.Now.ToLongDateString();
            interview[0].StageId = applies[0].IdStage;
            interview[0].StudentId = idStudent;
            var interviews = _fixture.CreateMany<ViewModels.Interviews.Create>(1).ToList();
            foreach (var inte in interviews)
            {
                inte.StageId = applies[0].IdStage;
                inte.StudentId = idStudent;
            }
            var interviewCreated = Mapper.Map<Create>(interview[0]);
            interviewRepository.GetAll().Returns(interview.AsQueryable());

            var result = interviewController.Create(interviewCreated) as ViewResult;

            result.ViewName.Should().Be("");
        }

        public int userlogin()
        {
            var user = _fixture.Create<ApplicationUser>();
            user.Roles = new List<UserRole>()
            {
                new UserRole() {RoleName = RoleName.Coordinator}
            };
            var loginViewModel = new ViewModels.Account.Login()
            {
                Username = user.UserName,
                Password = user.Password

            };
            var valideUser = new MayBe<ApplicationUser>(user);
            accountService.ValidateUser(loginViewModel.Username, loginViewModel.Password).Returns(valideUser);
            httpContextService.GetUserId().Returns(user.Id);
            accountController.Login(loginViewModel);

            return user.Id;
        }

       
    }
}
