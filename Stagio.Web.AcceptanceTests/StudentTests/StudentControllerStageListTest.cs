using System;
using FluentAssertions;
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

            StageListStudentPage.HasStage.Should().BeTrue();
            
        }

        [TestMethod]
        public void student_home_page_not_should_display_stages_not_if_logged_in()
        {
            StageListStudentPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
            
        }

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            StageListStudentPage.GoTo();
            StageListStudentPage.AccessStageDescription().Should().BeTrue();
           
        }
    }
}
