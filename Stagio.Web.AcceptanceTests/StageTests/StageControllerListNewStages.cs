using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerListNewStages : BaseTests
    {

        [TestMethod]
        public void coordinator_can_see_listNewStages_page_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            ListAllStagesCoordinatorPage.GoTo();

            ListAllStagesCoordinatorPage.IsDisplayed.Should().BeTrue();
            
        }

        [TestMethod]
        public void coordinator_can_not_see_listNewStages_page_if_not_logged_in()
        {
            ListAllStagesCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
           
        }

        [TestMethod]
        public void coordinator_can_see_listNewStages_with_stages()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            ListAllStagesCoordinatorPage.GoTo();

            ListAllStagesCoordinatorPage.CountNbStages().Should().NotBe(0);
           
        }
    }
}
