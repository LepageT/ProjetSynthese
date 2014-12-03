using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyTests : BaseTests
    {
        //[TestMethod]
        //public void student_should_be_able_to_see_the_page_to_apply_to_a_stage()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(StudentUsername, StudentPassword);

        //    ApplyStudentPage.GoTo();

        //    ApplyStudentPage.IsDisplayed.Should().BeTrue();

        //}

        //[TestMethod]
        //public void student_should_see_confirmation_page_after_apply()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(StudentUsername, StudentPassword);
        //    ApplyStudentPage.GoToByUrl();

        //    ApplyStudentPage.SelectFiles("file1.pdf", "file2.pdf");

        //    ConfirmationUploadCVLetterPage.IsDisplayed.Should().BeTrue();

        //}

        [TestMethod]
        public void student_upload_should_rest_on_to_upload_is_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ApplyStudentPage.GoToByUrl();

            ApplyStudentPage.SelectFiles("", "");

            ApplyStudentPage.IsDisplayed.Should().BeTrue();

        }
    }
}
