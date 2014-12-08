using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerEdit : BaseTests
    {
        [TestMethod]
        public void user_can_sign_stage_agreement()
        {
         
        
            const string SIGNATURE = "test4test1";

            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            CreateStageAgreementCoordinatorPage.GoTo();
            EditStageAgreementPage.GoByUrl();
            EditStageAgreementPage.EditAStageAgreement(SIGNATURE);

            HomePage.IsDisplayed.Should().BeTrue();
        }


    }
}
