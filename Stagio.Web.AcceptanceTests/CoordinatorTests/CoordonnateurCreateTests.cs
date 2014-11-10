using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorCreateTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_create_an_account_with_valid_invitation()
        {
            CreateCoordinatorPage.GoToByUrl();

            Assert.IsTrue(CreateCoordinatorPage.IsDisplayed);

            }

        [TestMethod]
        public void coordinator_create_should_create_account_if_invitation_is_valid()
        {
            CreateCoordinatorPage.GoToByUrl();
            const string FIRST_NAME = "Bobino";
            const string LAST_NAME = "Tremblay";
            const string EMAIL = "testemail@admin.com";
            const string PASSWORD = "Bobino1234";
            CreateCoordinatorPage.FillFieldsAndSend(FIRST_NAME, LAST_NAME, EMAIL, PASSWORD);

            Assert.IsTrue(CreateCoordinatorPage.ConfirmationPageIsDisplayed);

        }

       
    }
}
