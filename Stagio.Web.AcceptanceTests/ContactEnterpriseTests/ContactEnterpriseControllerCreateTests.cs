using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerCreateTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_create_profil_page()
        {
            CreateContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(CreateContactEnterprisePage.IsDisplayed);
            
        }

        [TestMethod]
        public void contact_enterprise_create_should_create_account()
        {
            CreateContactEnterprisePage.GoToByUrl();
            CreateContactEnterprisePage.CreateContactEnterpriseWithoutInvitation();

            Assert.IsTrue(CreateContactEnterprisePage.ConfirmationIsDisplayed);
            
        }


        [TestMethod]
        public void contact_enterprise_invitation_create_should_create_account()
        {
            CreateContactEnterprisePage.CreateContactEnterpriseWithInvitation();

            Assert.IsTrue(CreateContactEnterprisePage.ConfirmationIsDisplayed);
            
           
        }
    }
}
