using System;
using System.Drawing.Imaging;
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

            Assert.IsTrue(LoginPage.VerifyCoordinatorLogin());
          
        }

        [TestMethod]
        public void application_user_should_be_able_to_view_the_login_page()
        {
            LoginPage.GoTo();

            Assert.IsTrue(LoginPage.IsDisplayed);

        }

        [TestMethod]
        public void authentificated_user_should_be_able_to_logout_after_valid_login()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            LoginPage.Logout();
            
            Assert.IsTrue(LoginPage.VerifyLogout());
            
        }
    
    }
}
