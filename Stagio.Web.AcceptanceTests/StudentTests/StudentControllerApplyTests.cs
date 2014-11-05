using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerApplyTests : BaseTests
    {
        [TestMethod]
        public void student_should_be_able_to_see_the_page_to_apply_to_a_stage()
        {
            ApplyStudentPage.GoToByUrl();

            Assert.IsTrue(ApplyStudentPage.IsDisplayed);
            
        }

        [TestMethod]
        public void student_should_see_confirmation_page_after_apply()
        {
            ApplyStudentPage.GoToByUrl();
            ApplyStudentPage.ApplyStudent("test", "test");

            Assert.IsTrue(ApplyStudentPage.ConfirmationPageIsDisplayed);

        }
    }
}
