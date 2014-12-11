using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseEditTest : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_should_not_be_able_to_edit_his_profil_if_not_logged_in()
        {
            EditContactEnterprisePage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
        }

        [TestMethod]
        public void contactEnterprise_edit_should_update_his_profil_if_id_is_valid()
        {
            const string NEW_TELEPHONE = "444-444-4444";
            const string OLD_PASSWORD = "qwerty12";
            const string NEW_PASSWORD = "asdfgh12";

            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            EditContactEnterprisePage.GoTo();
            EditContactEnterprisePage.EditAStudent(NEW_TELEPHONE, OLD_PASSWORD, NEW_PASSWORD);

            IndexContactEnterprisePage.IsDisplayed.Should().BeTrue();
            EditContactEnterprisePage.EditVerification(NEW_TELEPHONE).Should().BeTrue();
        }
    }
}
