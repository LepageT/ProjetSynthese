using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

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
