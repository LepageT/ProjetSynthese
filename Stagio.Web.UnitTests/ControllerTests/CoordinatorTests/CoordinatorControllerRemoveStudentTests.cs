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

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerRemoveStudentTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_RemoveStudents_should_render_view()
        {
            var result = coordinatorController.RemoveStudent() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_RemoveStudents_should_return_list_with_students()
        {
            var students = _fixture.CreateMany<Student>(3);
            studentRepository.GetAll().Returns(students.AsQueryable());

            var result = coordinatorController.RemoveStudent() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Coordinator.RemoveStudent>;

            model.Count().Should().NotBe(0);
        }

        [TestMethod]
        public void coordinator_RemoveStudents_should_return_empty_list_when_there_is_no_student()
        {

            var result = coordinatorController.RemoveStudent() as ViewResult;
            var model = result.Model as IEnumerable<ViewModels.Coordinator.RemoveStudent>;

            model.Count().Should().Be(0);

        }

        [TestMethod]
        public void coordinator_RemoveStudents_should_delete_selected_students()
        {
            var students = _fixture.CreateMany<Student>(3);
            var studentsList = students.ToList();
            List<int> idStudentsList = new List<int>();
            idStudentsList.Add(studentsList[1].Id);
            idStudentsList.Add(studentsList[2].Id);
            foreach (var student in students)
            {
                studentRepository.GetById(student.Id).Returns(student);
            }

            coordinatorController.RemoveStudent(idStudentsList);

            studentRepository.Received().Delete(Arg.Is<Student>(x => x.Id == studentsList[1].Id));
            studentRepository.Received().Delete(Arg.Is<Student>(x => x.Id == studentsList[2].Id));
            studentRepository.DidNotReceive().Delete(Arg.Is<Student>(x => x.Id == studentsList[3].Id));

        }

        [TestMethod]
        public void coordinator_RemoveStudents_post_should_redirect_confirmation_on_success()
        {
            var students = _fixture.CreateMany<Student>(3);
            var studentsList = students.ToList();
            List<int> idStudentsList = new List<int>();
            idStudentsList.Add(studentsList[1].Id);
            idStudentsList.Add(studentsList[2].Id);
            foreach (var student in students)
            {
                studentRepository.GetById(student.Id).Returns(student);
            }

            var routeResult = coordinatorController.RemoveStudent(idStudentsList) as RedirectToRouteResult;
            var routeAction = routeResult.RouteValues["Action"];

            routeAction.Should().Be(MVC.Coordinator.Views.ViewNames.RemoveStudentConfirmation);

        }

        [TestMethod]
        public void coordinator_inviteSucceed_should_render_view()
        {
            var result = coordinatorController.RemoveStudentConfirmation() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
