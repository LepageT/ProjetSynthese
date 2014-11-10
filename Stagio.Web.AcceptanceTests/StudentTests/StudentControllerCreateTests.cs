using System;
using System.Net.Mime;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Domain.Entities;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;
using Ploeh.AutoFixture;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerCreateTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_create_his_profil()
        {
            CreateStudentPage.GoTo();

            Assert.IsTrue(CreateStudentPage.IsDisplayed);

        }

        [TestMethod]
        public void student_create_should_redirect_to_index_if_created()
        {
            var student = _fixture.Create<Student>();
            CreateStudentPage.GoTo();
            CreateStudentPage.CreateStudent(student);

            Assert.IsTrue(CreateStudentPage.ConfirmationPageIsDisplayed);
            
        }
    }
}
