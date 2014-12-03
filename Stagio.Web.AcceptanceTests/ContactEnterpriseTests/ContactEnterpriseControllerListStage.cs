using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerListStage : BaseTests
    {

        [TestMethod]
        public void contactEnterprise_can_click_on_a_stage()
        {   
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            ListStageContactEnterprisePage.GoTo();

            ListStageContactEnterprisePage.AccessStageDetail().Should().BeTrue();
            
        }

        [TestMethod]
        public void contactEnterprise_can_reactivate_a_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            ListStageContactEnterprisePage.GoTo();
            ListStageContactEnterprisePage.ClickRemoveStage1();
            ListStageContactEnterprisePage.GoTo();
            ListStageContactEnterprisePage.ClickReactivateStage1();

            ListStageContactEnterprisePage.ReactivateStageConfirmationIsDisplayed.Should().BeTrue();

        }
        
    }
}
