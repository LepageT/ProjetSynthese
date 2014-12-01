using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerCreate : BaseTests
    {
        [TestMethod]
        public void coordinator_can_see_create_confirmation_stage_agreement_page()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            CreateStageAgreementCoordinatorPage.GoTo();

            CreateStageAgreementCoordinatorPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void user_can_not_see_create_stage_agreement_page_if_not_coordinator()
        {
            CreateStageAgreementCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
        }
    }
}
