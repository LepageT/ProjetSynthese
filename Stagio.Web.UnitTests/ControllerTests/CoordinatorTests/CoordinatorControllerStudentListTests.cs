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
        public void coordinator_StudentList_should_return_empty_list_when_there_is_no_student()
        {
            var result = coordinatorController.StudentList() as ViewResult;
            var model = result.Model as List<StudentList>;

            model.Count.Should().Be(0);
        }
    }
}
