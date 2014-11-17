using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.ConfirmationAccpetIsDisplayed);
            
        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_refusing_a_student_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();
            DetailsStudentApplyContactEnterprisePage.RefuseApply();

            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.ConfirmationRefuseIsDisplayed);

        }

        [TestMethod]
        public void contactEnterprise_can_see_a_page_of_detail_apply()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.IsDisplayed);
           
        }

        [TestMethod]
        public void contactEnterprise_should_not_download_files_isfiles_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();
            DetailsStudentApplyContactEnterprisePage.DownloadPage();
            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.ErrorDisplayed);
        }

        //[TestMethod]
        //public void contactEnterprise_should_download_files_isfiles_valid()
        //{

        //    LoginPage.GoTo();
        //    LoginPage.LoginAs(StudentUsername, StudentPassword);
        //    ApplyStudentPage.GoToByUrl();
        //    ApplyStudentPage.SelectFiles("C:\\dev\\abc.pdf", "C:\\dev\\abcdef.pdf");
            
        //    LoginPage.GoToByUrl();
        //    LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
        //    DetailsStudentApplyContactEnterprisePage.GoToByUrl();
        //    DetailsStudentApplyContactEnterprisePage.DownloadPage();
        //    DetailsStudentApplyContactEnterprisePage.DownloadFile("C:\\dev\\abc.pdf");
        //    Assert.IsFalse(DetailsStudentApplyContactEnterprisePage.ErrorDisplayed);
        //}

    }
}

