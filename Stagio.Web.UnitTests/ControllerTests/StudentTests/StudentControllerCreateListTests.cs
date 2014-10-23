using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using NSubstitute.Core;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;
using System;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;
using Stagio.Web.ViewModels.Student;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateListTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void createlist_action_should_render_default_view()
        {
            var result = studentController.CreateList() as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void createList_post_can_not_create_two_profils_with_two_same_matricule()
        {
            var listStudents = _fixture.CreateMany<ListStudent>(3).ToList();
            var liststudent = new ListStudent
            {
                FirstName = "Bob",
                LastName = "Patrick",
                Matricule = listStudents[0].Matricule
            };
            studentController.CreateListPost();
            listStudents.Add(liststudent);
            studentController.TempData["listStudent"] = listStudents;

            studentController.CreateListPost();

            studentRepository.DidNotReceive().Add(Arg.Is<Student>(x => x.FirstName == listStudents[3].FirstName));
            studentRepository.DidNotReceive().Add(Arg.Is<Student>(x => x.LastName == listStudents[3].LastName));
        }


        [TestMethod]
        public void createListPost_model_sould_not_be_valid_if_listStudent_null_redirect_default_view()
        {
            var listStudents = new List<ListStudent>();
            listStudents = null;
            studentController.TempData["listStudent"] = listStudents;

            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("Upload");
        }

        [TestMethod]
        public void createlist_post_should_add_student_to_repository()
        {
            var listStudents = _fixture.CreateMany<ListStudent>(3).ToList();
            var studentsInDb = new List<Student>();
            foreach (var student in listStudents)
            {
                studentsInDb.Add(new Student
                {
                    Matricule = student.Matricule,
                    FirstName = student.FirstName,
                    LastName = student.LastName

                });
            }
            studentController.TempData["listStudent"] = listStudents;

            studentController.CreateListPost();
            studentRepository.GetAll().Returns(studentsInDb.AsQueryable());

            foreach (var studentCreated in studentsInDb)
            {
                StudentRepositoryAddMethodShouldHaveReceived(studentCreated);
            }
        }

        [TestMethod]
        public void createlist_post_should_return_upload_when_modelState_is_not_valid()
        {
            studentController.ModelState.AddModelError("Error", "Error");
            var listStudents = _fixture.CreateMany<ListStudent>().ToList();
            studentController.TempData["listStudent"] = listStudents;

            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("Upload");
        }

        [TestMethod]
        public void createlist_post_should_redirect_to_student_resultList_on_success()
        {
            var listStudents = _fixture.CreateMany<ListStudent>(3).ToList();
            studentController.TempData["listStudent"] = listStudents;

            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("ResultCreateList");
        }


        [TestMethod]
        public void createlist_post_should_not_add_student_if_matricule_is_not_valid()
        {
            var listStudents = _fixture.CreateMany<ListStudent>(3).ToList();
            listStudents[1].Matricule = 1234567098;

            studentController.TempData["listStudent"] = listStudents;
            studentController.CreateListPost();

            studentRepository.DidNotReceive().Add(Arg.Is<Student>(x => x.Matricule == listStudents[1].Matricule));
        }

        private void StudentRepositoryAddMethodShouldHaveReceived(Student student)
        {
            studentRepository.Received().Add(Arg.Is<Student>(x => x.Id == student.Id));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.FirstName == student.FirstName));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.LastName == student.LastName));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.Matricule == student.Matricule));
            studentRepository.Received().Add(Arg.Is<Student>(x => x.Password == student.Password));
        }

    }
}
