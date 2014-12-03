using System;
using System.Drawing.Imaging;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;

namespace Stagio.Web.AcceptanceTests.AccountTests
{
    [TestClass]
    public class AccountControllerLoginTests : BaseTests
    {

        [TestMethod]
        public void application_user_can_log_in()
        {
            LoginPage.GoTo();

            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            LoginPage.VerifyCoordinatorLogin().Should().BeTrue();
           
        }

        //[TestMethod]
        //public void application_user_should_be_able_to_view_the_login_page()
        //{
        //    LoginPage.GoTo();

        //    LoginPage.IsDisplayed.Should().BeTrue();

        //}

        [TestMethod]
        public void authentificated_user_should_be_able_to_logout_after_valid_login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            LoginPage.Logout();
            
            LoginPage.VerifyLogout().Should().BeTrue();

        }
    
    }
}
