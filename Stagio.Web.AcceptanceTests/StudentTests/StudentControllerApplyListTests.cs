using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyListTests : BaseTests
    {
        [TestMethod]
        public void student_ApplyList_page_should_display_applied_stages_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ApplyListStudentPage.GoTo();

            Assert.IsTrue(ApplyListStudentPage.HasStage);
        }

        [TestMethod]
        public void student_ApplyList_page_not_should_display_applied_stages_not_if_logged_in()
        {
            ApplyListStudentPage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);
        }

        [TestMethod]
        public void student_should_be_able_to_access_stage_descritpion()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.AccessStageDescription();
        }

        [TestMethod]
        public void student_should_see_RemoveApplyConfirmationPage_when_removing_an_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            ApplyListStudentPage.GoTo();
            ApplyListStudentPage.ClickToRemove();

            Assert.IsTrue(ApplyListStudentPage.ConfirmationRemoveIsDisplayed);

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

            Assert.IsTrue(ApplyListStudentPage.ConfirmationRemoveIsDisplayed);
        }
    }
}
