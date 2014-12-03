using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.Selenium;

namespace Stagio.Web.AcceptanceTests.AccountTests
{
    [TestClass]
    public class AccountControllerDetailsTests : BaseTests
    {
        [TestMethod]
        public void applicationUser_can_see_his_profil()
        {
            Driver.GetScreenShoot("login.png");
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            Driver.GetScreenShoot("login_after.png");

            DetailsAccountPage.GoToByUrl1();
            Driver.GetScreenShoot("Detail_goto.png");

            DetailsAccountPage.IsDisplayed.Should().BeTrue();
           
        }

    }
}
