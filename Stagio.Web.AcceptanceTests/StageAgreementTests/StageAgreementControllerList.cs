using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.StageAgreement;

namespace Stagio.Web.AcceptanceTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerList : BaseTests
    {
       
        [TestMethod]
        public void coordinator_can_see_stageAgreement_list_with_elements()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            StageAgreementListPage.CoordinatorGoTo();

            StageAgreementListPage.HasStageAgreement.Should().BeTrue();
        }

        [TestMethod]
        public void contactEnterprise_can_see_stageAgreement_list_with_elements()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            StageAgreementListPage.ContactEnterpriseGoTo();

            StageAgreementListPage.HasStageAgreement.Should().BeTrue();
        }

        [TestMethod]
        public void student_can_see_stageAgreement_list_with_elements()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(StudentUsername, StudentPassword);

            StageAgreementListPage.StudentGoTo();

            StageAgreementListPage.HasStageAgreement.Should().BeTrue();
        }
    }
}
