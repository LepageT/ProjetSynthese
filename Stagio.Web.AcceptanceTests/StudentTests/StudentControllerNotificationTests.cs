using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Coordinator;
using Stagio.Web.Automation.PageObjects.Notification;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerNotificationTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_notification_detail()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            DetailNotificationPage.GoToNotification(1);

            Assert.IsTrue(DetailNotificationPage.IsDisplayed);
        }

        [TestMethod]
        public void student_should_be_able_to_see_notification_list_on_index()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            IndexStudentPage.GoTo();

            Assert.IsTrue(IndexStudentPage.IsNotificationShowing);
        }
    }
}
