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
        [TestMethod]
        public void student_not_should_be_able_to_edit_his_interview_if_not_logged_in()
        {
            EditInterviewPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void student_edit_should_update_his_interview_if_id_is_valid()
        {
            var DATE_INTERVIEW = new DateTime(1999,12,24,12,30, 0);
            var DATE_OFFER = new DateTime(1999, 12, 24, 12, 30, 0);
            var DATE_ACCEPT_OFFER = new DateTime(1999, 12, 24, 12, 30, 0);

            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            addInterview();
            EditInterviewPage.GoToByUrl();

            EditInterviewPage.EditAnInterview(DATE_INTERVIEW, DATE_OFFER, DATE_ACCEPT_OFFER, true);

            ListInterview.IsDisplayed.Should().BeTrue();
            EditInterviewPage.EditVerification(DATE_INTERVIEW, DATE_OFFER, DATE_ACCEPT_OFFER).Should().BeTrue();
        }

        private void addInterview()
        {
            CreateInterviewStudentPage.GoTo();
            CreateInterviewStudentPage.AddInterview();
            HomePage.GoTo();
            
        }
    }
}
