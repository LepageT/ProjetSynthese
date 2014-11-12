using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerReplyStageTests : BaseTests
    {
        [TestMethod]
        public void student_ReplyStage_page_should_display_applied_stage_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ReplyStageStudentPage.GoTo();

            Assert.IsTrue(ReplyStageStudentPage.IsDisplayed);
        }

        [TestMethod]
        public void student_ReplyStage_page_not_should_display_applied_stage_not_if_logged_in()
        {
            ReplyStageStudentPage.GoToByUrlIdApply1();

            Assert.IsTrue(LoginPage.IsDisplayed);
        }

       /* [TestMethod]
        public void student_should_see_ApplyList_page_after_ReplyStage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);
            ReplyStageStudentPage.GoTo();
            ReplyStageStudentPage.ReplyAcceptStage();

            Assert.IsTrue(ApplyListStudentPage.IsDisplayed);

        }*/
    }
}
