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
using Stagio.Web.ViewModels.Coordinator;


namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerStudentListTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_StudentList_should_render_view()
        {
            var result = coordinatorController.StudentList() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void coordinator_StudentList_should_return_list_with_students()
        {
            var students = _fixture.CreateMany<Student>(3);
            studentRepository.GetAll().Returns(students.AsQueryable());

            var result = coordinatorController.StudentList() as ViewResult;
            var model = result.Model as List<StudentList>;

            model.Count.Should().NotBe(0);
        }

        [TestMethod]
        public void coordinator_StudentList_should_return_list_with_students_with_element_of_apply()
        {
            var students = _fixture.CreateMany<Student>(3).ToList();
            var applies = _fixture.CreateMany<Apply>(3).ToList();
            applies[0].IdStudent = students[0].Id;
            applyRepository.GetAll().Returns(applies.AsQueryable());
            studentRepository.GetAll().Returns(students.AsQueryable());

            var result = coordinatorController.StudentList() as ViewResult;
            var model = result.Model as List<StudentList>;

            model.Count.Should().NotBe(0);
        }

        [TestMethod]
        public void coordinator_StudentList_should_return_list_with_students_with_nb_of_interview()
        {
            var students = _fixture.CreateMany<Student>(3).ToList();
            var interviews = _fixture.CreateMany<Interview>(3).ToList();
            interviews[0].StudentId = students[0].Id;
            interviewRepository.GetAll().Returns(interviews.AsQueryable());
            studentRepository.GetAll().Returns(students.AsQueryable());

            var result = coordinatorController.StudentList() as ViewResult;
            var model = result.Model as List<StudentList>;

            model.Count.Should().NotBe(0);
        }

        [TestMethod]
        public void coordinator_StudentList_should_return_empty_list_when_there_is_no_student()
        {
            var result = coordinatorController.StudentList() as ViewResult;
            var model = result.Model as List<StudentList>;

            model.Count.Should().Be(0);
        }
    }
}
