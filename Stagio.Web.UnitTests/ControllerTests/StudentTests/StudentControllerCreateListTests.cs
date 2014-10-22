using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;
using System;
using Stagio.Web.UnitTests.ControllerTests.EnterpriseTests;
using Stagio.Web.ViewModels.Student;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateListTests : StudentControllerBaseClassTests
    {
        [TestMethod]
        public void createlist_action_should_render_default_view()
        {
             _fixture.CreateMany<Student>().ToList();
            var result = studentController.CreateList() as ViewResult;

             Assert.AreEqual("", result.ViewName);
        }


        [TestMethod]
        public void createList_post_can_not_create_two_profils_with_two_same_matricule()
        {
            var listStudent = _fixture.CreateMany<ListStudent>(3).ToList();
            var studentInDb = new List<Student>();

            foreach (var student in listStudent)
            {
                studentInDb.Add(new Student
                {
                    Matricule = student.Matricule,
                    FirstName = student.FirstName,
                    LastName = student.LastName

                });
            }

            studentController.TempData["listStudent"] = listStudent;
            studentController.CreateListPost();
            studentRepository.GetAll().Returns(studentInDb.AsQueryable());


            studentController.TempData["listStudent"] = listStudent;
            studentController.CreateListPost();
            
            foreach (var studentCreated in studentInDb)
            {
                StudentRepositoryAddMethodShouldHaveReceived(studentCreated);
            }
        }
        

        [TestMethod]
        public void createListPost_model_sould_not_be_valid_if_listStudent_null_redirect_default_view()
        {
            
            var studentViewModel = new List<Student>();
            studentViewModel = null;
            studentController.TempData["listStudent"] = studentViewModel;
            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("Upload");
        }

        [TestMethod]
        public void createlist_post_should_add_student_to_repository()
        {
            var listStudent = _fixture.CreateMany<ListStudent>(3).ToList();
            var studentInDb = new List<Student>();

            foreach(var student in listStudent) 
            {
                studentInDb.Add(new Student
                {
                   Matricule = student.Matricule,
                   FirstName = student.FirstName,
                   LastName = student.LastName
                    
                });
            }

            studentController.TempData["listStudent"] = listStudent;
            studentController.CreateListPost();
            studentRepository.GetAll().Returns(studentInDb.AsQueryable());
            foreach (var studentCreated in studentInDb)
            {
                StudentRepositoryAddMethodShouldHaveReceived(studentCreated);
            }
        }

        [TestMethod]
        public void createlist_post_should_return_default_view_when_modelState_is_not_valid()
        {

            studentController.ModelState.AddModelError("Error", "Error");
            var studentViewModel = _fixture.CreateMany<Student>().ToList();
            studentController.TempData["listStudent"] = studentViewModel;
            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("Upload");
        }

        [TestMethod]
        public void createlist_post_should_redirect_to_student_resultList_on_success()
        {
            var studentViewModel = _fixture.CreateMany<ListStudent>(3).ToList();
            studentController.TempData["listStudent"] = studentViewModel;
            var result = studentController.CreateListPost() as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo("ResultCreateList");

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
