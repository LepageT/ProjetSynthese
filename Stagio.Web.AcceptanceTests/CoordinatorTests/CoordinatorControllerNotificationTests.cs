using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Coordinator;
using Stagio.Web.Automation.PageObjects.Notification;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerNotificationTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_notification_detail()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            DetailNotificationPage.GoToNotification(5);

            Assert.IsTrue(DetailNotificationPage.IsDisplayed);
        }

        [TestMethod]
        public void coordinator_should_be_able_to_see_notification_list_on_index()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            IndexCoordinatorPage.Goto();

            Assert.IsTrue(IndexCoordinatorPage.IsNotificationShowing);
        }
    }
}

