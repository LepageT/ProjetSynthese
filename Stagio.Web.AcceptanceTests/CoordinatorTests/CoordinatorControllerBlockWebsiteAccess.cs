using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerBlockWebsiteAccess : BaseTests
    {
        [TestMethod]
        public void Coordinator_can_block_access_to_website()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            BlockWebsiteAccessCoordinatorPage.GoTo();
            BlockWebsiteAccessCoordinatorPage.ClickResultButton();

            IndexCoordinatorPage.isDiplayed.Should().BeTrue();
        }
    }
}
