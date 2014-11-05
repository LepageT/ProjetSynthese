using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteEnterpriseTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_access_invite_enterprise_page_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteContactEnterpriseCoordinatorPage.GoTo();

            Assert.IsTrue(InviteContactEnterpriseCoordinatorPage.IsDisplayed);
            
        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_access_invite_enterprise_page_if_not_logged_in()
        {
            InviteContactEnterpriseCoordinatorPage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);
           
        }


        [TestMethod]
        public void coordinator_should_be_able_to_invite_enterprise()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteContactEnterpriseCoordinatorPage.GoTo();
            const string MESSAGE_INVITATION = "test";
            InviteContactEnterpriseCoordinatorPage.AddMessageInvitationAndSend(MESSAGE_INVITATION);

            Assert.IsTrue(InviteContactEnterpriseCoordinatorPage.ConfirmationPageIsDisplayed);
            

        }
    }
}
