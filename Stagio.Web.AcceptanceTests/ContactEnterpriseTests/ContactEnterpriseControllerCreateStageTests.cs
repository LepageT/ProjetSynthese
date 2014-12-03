using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerCreateStageTests : BaseTests
    {
        [TestMethod]
        public void enterprise_should_not_be_able_to_see_the_page_to_create_stage_if_not_logged_in_and_redirected_to_login()
        {
            CreateStageContactEnterprisePage.GoToByUrl();
          
            LoginPage.IsDisplayed.Should().BeTrue();

         }

        [TestMethod]
        public void enterprise_should_be_able_to_create_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            CreateStageContactEnterprisePage.GoTo();

            CreateStageContactEnterprisePage.CreateStage();

            CreateStageContactEnterprisePage.ConfirmationPageIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_save_draft()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            CreateStageContactEnterprisePage.GoTo();

            CreateStageContactEnterprisePage.CreateDraft();

            CreateStageContactEnterprisePage.DraftConfirmationPageIsDisplayed.Should().BeTrue();
        }

    }
}
