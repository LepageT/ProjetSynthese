using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerListStage : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_can_see_a_list_of_stage()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            ListStageContactEnterprisePage.GoTo();

            Assert.IsTrue(ListStageContactEnterprisePage.IsDisplayed);
            
        }

        [TestMethod]
        public void contactEnterprise_can_click_on_a_stage()
        {   
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);

            ListStageContactEnterprisePage.GoTo();
            Assert.IsTrue(ListStageContactEnterprisePage.AccessStageDetail());
            
        }
        
    }
}
