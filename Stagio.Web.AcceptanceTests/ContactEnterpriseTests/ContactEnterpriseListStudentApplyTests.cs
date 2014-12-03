using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseListStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_can_see_a_list_of_student_for_stage()
        {
            LoginPage.GoToByUrl();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            StudentApplyContactEnterprisePage.GoToByUrl();

            StudentApplyContactEnterprisePage.IsDisplayed.Should().BeTrue();
            
        }

        [TestMethod]
        public void contactEnterprise_can_click_on_a_student()
        {
            LoginPage.GoToByUrl();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            StudentApplyContactEnterprisePage.GoToByUrl();

            StudentApplyContactEnterprisePage.ButtonIsDisplayed().Should().BeTrue();
            
        }
    }
}
