using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerCreate : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_the_page_to_add_interview_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            CreateInterviewStudentPage.GoTo();

            CreateInterviewStudentPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void student_should_not_be_able_to_see_the_page_to_add_interview_if_not_logged_in_and_redirected_to_login()
        {
            CreateInterviewStudentPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
            
        }

        [TestMethod]
        public void student_should_be_able_to_add_interview()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            CreateInterviewStudentPage.GoTo();

            CreateInterviewStudentPage.AddInterview();

            CreateInterviewStudentPage.ConfirmationIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void student_should_not_be_able_to_add_interview_if_it_is_already_add()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            CreateInterviewStudentPage.GoTo();
            CreateInterviewStudentPage.AddInterview();
            CreateInterviewStudentPage.GoTo();

            CreateInterviewStudentPage.AddInterview();

            CreateInterviewStudentPage.IsDisplayed.Should().BeTrue();

        }
    }
}
