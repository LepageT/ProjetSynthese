using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerChangeSmtpOptionsTests : BaseTests
    {
        private const string SERVER = "smtp.qc.ca";
        private const string SMTP_PORT = "25";
        private const string USERNAME = "";
        private const string PASSWORD = "";
        private const string EMAIL = "test@test.com";
        [TestMethod]
        public void Coordinator_should_be_able_to_change_smtp_options()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

             ChangeSMTPOptionsPage.GoTo();
            ChangeSMTPOptionsPage.FillFieldsAndSend(SERVER, SMTP_PORT, USERNAME, PASSWORD, EMAIL);

            IndexCoordinatorPage.IsDisplayed.Should().BeTrue();
        }
    }
}
