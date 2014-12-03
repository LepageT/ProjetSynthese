using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyConfirmationTests : BaseTests
    {

        [TestMethod]
        public void student_should_download_his_files_of_the_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ApplyStudentPage.GoToByUrl();
            ApplyStudentPage.SelectFiles("file1.pdf", "file2.pdf");

            ConfirmationUploadCVLetterPage.IsDisplayed.Should().BeTrue();
        }

    }
}
