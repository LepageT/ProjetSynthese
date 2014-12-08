using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;
using System.Collections.Generic;
using System.Linq;


namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerRemovestudentFromListStudentTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_can_remove_student_from_list_student_before_create_student()
        {
            var listStudents = _fixture.CreateMany<ViewModels.Student.ListStudent>(3).ToList() ;
            coordinatorController.TempData["listStudent"] = listStudents;

            coordinatorController.RemoveStudentFromListStudent(listStudents[0].Matricule);
            List<ViewModels.Student.ListStudent> listStudentsAfterRemove = coordinatorController.TempData["listStudent"] as List<ViewModels.Student.ListStudent>;
            
            listStudentsAfterRemove.Count.Should().Be(2);
        }
    }
}
