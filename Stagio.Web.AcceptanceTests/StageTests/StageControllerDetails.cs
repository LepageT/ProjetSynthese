using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerDetails : BaseTests
    {
        [TestMethod]
        public void coordinator_can_see_details_stage_page_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage1();

            Assert.IsTrue(DetailsStageCoordinatorPage.IsDisplayed);
            
        }

        [TestMethod]
        public void coordinator_can_see_remove_button_if_stage_accepted()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage3();

            Assert.IsTrue(DetailsStageCoordinatorPage.ButtonRemoveIsDisplayed());
            
        }

        [TestMethod]
        public void coordinator_can_not_see_remove_button_if_stage_Not_accepted()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage1();

            Assert.IsFalse(DetailsStageCoordinatorPage.ButtonRemoveIsDisplayed());
            
        }

        [TestMethod]
        public void coordinator_can_remove_stage_of_listStageAccepted()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage3();
            DetailsStageCoordinatorPage.RemoveStage();

            Assert.IsTrue(ListAllStagesCoordinatorPage.IsDisplayed);

        }

        [TestMethod]
        public void coordinator_can_refuse_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage1();
            DetailsStageCoordinatorPage.RefuseStage();

            Assert.IsTrue(ListAllStagesCoordinatorPage.IsDisplayed);
            
        }

        [TestMethod]
        public void coordinator_can_accept_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage1();
            DetailsStageCoordinatorPage.AcceptStage();

            Assert.IsTrue(ListAllStagesCoordinatorPage.IsDisplayed);
           
        }
    }
}
