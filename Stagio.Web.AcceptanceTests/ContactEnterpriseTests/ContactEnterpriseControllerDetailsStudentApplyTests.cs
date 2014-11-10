using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.AcceptanceTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerDetailsStudentApplyTests : BaseTests
    {
        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_accepting_a_student_apply()
        {
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();
            DetailsStudentApplyContactEnterprisePage.AcceptApply();

            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.ConfirmationAccpetIsDisplayed);
            
        }

        [TestMethod]
        public void contact_enterprise_should_be_able_to_access_confirmation_page_when_refusing_a_student_apply()
        {
            DetailsStudentApplyContactEnterprisePage.GoToByUrl();
            DetailsStudentApplyContactEnterprisePage.RefuseApply();

            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.ConfirmationRefuseIsDisplayed);

        }

        [TestMethod]
        public void contactEnterprise_can_see_a_page_of_detail_apply()
        {

            DetailsStudentApplyContactEnterprisePage.GoToByUrl();

            Assert.IsTrue(DetailsStudentApplyContactEnterprisePage.IsDisplayed);
           
        }

    }
}

