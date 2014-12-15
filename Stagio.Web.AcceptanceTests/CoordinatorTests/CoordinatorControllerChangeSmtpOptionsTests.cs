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
        private const string SERVER = "jenkinssmtp.cegep-ste-foy.qc.ca";
        private const string SMTP_PORT = "527";
        private const string USERNAME = "bob";
        private const string PASSWORD = "123";
        private const string EMAIL = "test@test.com";
        [TestMethod]
        public void Coordinator_should_be_able_to_change_smtp_options()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            ChangeSMTPOptionsPage.GoTo();
            ChangeSMTPOptionsPage.FillFieldsAndSend(SERVER, SMTP_PORT, USERNAME, PASSWORD, EMAIL);
            ChangeSMTPOptionsPage.GoTo();
            ChangeSMTPOptionsPage.ReturnToDefault();

            IndexCoordinatorPage.IsDisplayed.Should().BeTrue();
        }
    }
}
