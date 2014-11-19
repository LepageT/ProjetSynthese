using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Notification;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseNotificationTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_see_notification_detail()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            DetailNotificationPage.GoToNotification(4);

            Assert.IsTrue(DetailNotificationPage.IsDisplayed);
        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_see_notification_list()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            IndexContactEnterprisePage.Goto();

            Assert.IsTrue(IndexContactEnterprisePage.IsNotificationShowing);
        }
    }
}
