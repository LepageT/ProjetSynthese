using System;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.Web.Automation;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Student;
using Stagio.Web.ViewModels.Interviews;

namespace Stagio.Web.AcceptanceTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerList: BaseTests
    {
        [TestMethod]
        public void student_can_see_a_list_of_interviews()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            addInterview();
            
            ListInterview.GoTo();

            ListInterview.InterviewIsDisplayed().Should().BeTrue();

        }

        private void addInterview()
        {
            CreateInterviewStudentPage.GoTo();
            CreateInterviewStudentPage.AddInterview();
            HomePage.GoTo();
           
        }
    }
}
