using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerCreateTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_create_should_create_account()
        {

            CreateContactEnterprisePage.GoToByUrl();

            CreateContactEnterprisePage.CreateContactEnterpriseWithoutInvitation();

            CreateContactEnterprisePage.ConfirmationIsDisplayed.Should().BeTrue();
            
        }


        
    }
}
