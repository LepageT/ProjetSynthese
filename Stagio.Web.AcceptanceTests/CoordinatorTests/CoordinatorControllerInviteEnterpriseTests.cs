using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteEnterpriseTests : BaseTests
    {
        //[TestMethod]
        //public void coordinator_should_be_able_to_access_invite_enterprise_page_if_logged_in()
        //{
        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

        //    InviteContactEnterpriseCoordinatorPage.GoTo();

        //    InviteContactEnterpriseCoordinatorPage.IsDisplayed.Should().BeTrue();
            
        //}

        [TestMethod]
        public void coordinator_not_should_be_able_to_access_invite_enterprise_page_if_not_logged_in()
        {
            InviteContactEnterpriseCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
           
        }


        [TestMethod]
        public void coordinator_should_be_able_to_invite_enterprise()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            InviteContactEnterpriseCoordinatorPage.GoTo();
            const string MESSAGE_INVITATION = "test";

            InviteContactEnterpriseCoordinatorPage.AddMessageInvitationAndSend(MESSAGE_INVITATION);

            InviteContactEnterpriseCoordinatorPage.ConfirmationPageIsDisplayed.Should().BeTrue();
            

        }
    }
}
