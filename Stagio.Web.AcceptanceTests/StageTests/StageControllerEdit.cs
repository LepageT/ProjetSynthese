using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StageTests
{
    [TestClass]
    public class StageControllerEdit : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_edit_stage_if_id_is_valid()
        {
            LoginPage.GoToByUrl();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            EditStagePage.GoToByUrl();
            EditStagePage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void contact_enterprise_not_should_be_able_to_edit_his_profil_if_not_logged_in()
        {
            EditStagePage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void contact_enterprise_edit_should_update_his_stage_if_id_is_valid()
        {
            const string NEW_RESPONSABLE_NAME = "Ticoune";
       

            LoginPage.GoToByUrl();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            EditStagePage.GoToByUrl();
            EditStagePage.EditAStage(NEW_RESPONSABLE_NAME);

            EditStagePage.EditVerification(NEW_RESPONSABLE_NAME).Should().BeTrue();
        }

        [TestMethod]
        public void contact_enterprise_edit_should_redirect_to_index_if_updated()
        {
            const string NEW_RESPONSABLE_NAME = "Ticoune";

            LoginPage.GoToByUrl();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            EditStagePage.GoToByUrl();
            EditStagePage.EditAStage(NEW_RESPONSABLE_NAME);

           ListStageContactEnterprisePage.IsDisplayed.Should().BeTrue();


        }
    }
}
