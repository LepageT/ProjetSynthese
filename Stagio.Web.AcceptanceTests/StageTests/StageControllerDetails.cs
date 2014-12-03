using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerDetails : BaseTests
    {

        [TestMethod]
        public void coordinator_can_remove_stage_of_listStageAccepted()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage3();

            DetailsStageCoordinatorPage.RemoveStage();

            ListAllStagesCoordinatorPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_can_refuse_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage1();

            DetailsStageCoordinatorPage.RefuseStage();

            ListAllStagesCoordinatorPage.IsDisplayed.Should().BeTrue();
            
        }

        [TestMethod]
        public void coordinator_can_accept_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            DetailsStageCoordinatorPage.GoToDetailsStage1();

            DetailsStageCoordinatorPage.AcceptStage();

            ListAllStagesCoordinatorPage.IsDisplayed.Should().BeTrue();
           
        }
    }
}
