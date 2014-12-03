using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerEdit : BaseTests
    {
        //[TestMethod]
        //public void student_should_be_able_to_edit_his_interview_if_id_is_valid_and_student_is_connected()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(StudentUsername, StudentPassword);
        //    addInterview();

        //    EditInterviewPage.GoToByUrl();

        //    EditInterviewPage.IsDisplayed.Should().BeTrue();
        //}

        [TestMethod]
        public void student_not_should_be_able_to_edit_his_interview_if_not_logged_in()
        {
            EditInterviewPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
        }

        //[TestMethod]
        //public void student_edit_should_update_his_interview_if_id_is_valid()
        //{
        //    var NEW_DATE = new DateTime(1999,12,24,12,30, 0);

        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(StudentUsername, StudentPassword);
        //    addInterview();
        //    EditInterviewPage.GoToByUrl();

        //    EditInterviewPage.EditAnInterview(NEW_DATE, true);

        //    EditInterviewPage.EditVerification(NEW_DATE).Should().BeTrue();
        //}

        [TestMethod]
        public void student_edit_interview_should_redirect_to_list_interview_if_updated()
        {
            var NEW_DATE = new DateTime(1999, 12, 24, 12, 30, 0);

            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            addInterview();
            EditInterviewPage.GoToByUrl();

            EditInterviewPage.EditAnInterview(NEW_DATE, true);

            ListInterview.IsDisplayed.Should().BeTrue();
        }

        private void addInterview()
        {
            CreateInterviewStudentPage.GoTo();
            CreateInterviewStudentPage.AddInterview();
            HomePage.GoTo();
            
        }
    }
}
