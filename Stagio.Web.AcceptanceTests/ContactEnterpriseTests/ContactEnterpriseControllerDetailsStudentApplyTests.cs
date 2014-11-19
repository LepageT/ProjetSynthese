using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_accepting_a_student_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();

            DetailsStudentApplyContactEnterprisePage.AcceptApply();

            DetailsStudentApplyContactEnterprisePage.ConfirmationAccpetIsDisplayed.Should().BeTrue();
            
        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_refusing_a_student_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();

            DetailsStudentApplyContactEnterprisePage.RefuseApply();

            DetailsStudentApplyContactEnterprisePage.ConfirmationRefuseIsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void contactEnterprise_can_see_a_page_of_detail_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            DetailsStudentApplyContactEnterprisePage.GoToByUrl();

            DetailsStudentApplyContactEnterprisePage.IsDisplayed.Should().BeTrue();
           
        }

        [TestMethod]
        public void contactEnterprise_should_not_download_files_isfiles_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();

            DetailsStudentApplyContactEnterprisePage.DownloadPage();

            DetailsStudentApplyContactEnterprisePage.ErrorDisplayed.Should().BeTrue();
        }


    }
}

