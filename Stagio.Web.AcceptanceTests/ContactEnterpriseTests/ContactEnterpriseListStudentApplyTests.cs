using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseListStudentApplyTests : BaseTests
    {
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
