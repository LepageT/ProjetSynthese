using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorChangeStageApplyDates : BaseTests
    {
        [TestMethod]
        public void coordinator_can_change_dates_of_stage_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            ChangeStageApplyDatesCoordinatorPage.GoTo();
            ChangeStageApplyDatesCoordinatorPage.AddDates();

            IndexCoordinatorPage.isDiplayed.Should().BeTrue();
        }
    }
}
