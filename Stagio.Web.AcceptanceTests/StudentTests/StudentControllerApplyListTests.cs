using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyListTests : BaseTests
    {
        //[TestMethod]
        //public void student_ApplyList_page_should_display_applied_stages_if_logged_in()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(StudentUsername, StudentPassword);

        //    ApplyListStudentPage.GoTo();

        //    ApplyListStudentPage.HasStage.Should().BeTrue();
        //}

        //[TestMethod]
        //public void student_ApplyList_page_not_should_display_applied_stages_not_if_logged_in()
        //{
        //    ApplyListStudentPage.GoToByUrl();

        //    LoginPage.IsDisplayed.Should().BeTrue();
        //}

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();

            ApplyListStudentPage.AccessStageDescription().Should().BeTrue();
        }

        [TestMethod]
        public void student_should_see_RemoveApplyConfirmationPage_when_removing_an_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToRemove();

            ApplyListStudentPage.ConfirmationRemoveIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void student_should_see_ReApplyApplyConfirmationPage_when_reapplying()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToRemove();
            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToReApply();

            ApplyListStudentPage.ConfirmationReApplyIsDisplayed.Should().BeTrue();
        }
    }
}
