using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_the_page_to_apply_to_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ApplyStudentPage.GoTo();

            Assert.IsTrue(ApplyStudentPage.IsDisplayed);
            
        }

        [TestMethod]
        public void student_should_see_confirmation_page_after_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyStudentPage.GoToByUrl();

            ApplyStudentPage.SelectFiles("C:\\dev\\abc.pdf", "C:\\dev\\abcdef.pdf");

            Assert.IsTrue(ConfirmationUploadCVLetterPage.IsDisplayed);

        }

        [TestMethod]
        public void student_upload_should_rest_on_to_upload_is_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyStudentPage.GoToByUrl();

            ApplyStudentPage.SelectFiles("", "");

            Assert.IsTrue(ApplyStudentPage.IsDisplayed);

        }
    }
}
