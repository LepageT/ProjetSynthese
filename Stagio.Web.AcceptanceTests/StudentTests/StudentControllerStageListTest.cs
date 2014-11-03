using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerStageListTest : BaseTests
    {
        [TestMethod]
        public void student_home_page_should_display_stages_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            StageListStudentPage.GoTo();

            Assert.IsTrue(StageListStudentPage.HasStage);
            
        }

        [TestMethod]
        public void student_home_page_not_should_display_stages_not_if_logged_in()
        {
            StageListStudentPage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);
            
        }

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            StageListStudentPage.GoTo();
            StageListStudentPage.AccessStageDescription();
           
        }
    }
}
