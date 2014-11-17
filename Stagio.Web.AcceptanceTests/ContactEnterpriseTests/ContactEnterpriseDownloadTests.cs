using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseDownloadTests : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_can_see_a_list_of_student_for_stage()
        {
            StudentApplyContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(StudentApplyContactEnterprisePage.IsDisplayed);

        }

        [TestMethod]
        public void contactEnterprise_can_click_on_a_student()
        {
            StudentApplyContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(StudentApplyContactEnterprisePage.ButtonIsDisplayed());

        }
    }
}
