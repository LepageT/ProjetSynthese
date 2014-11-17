using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;
namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
[TestClass]
public class CoordinatorControllerStudentApplyListTests : BaseTests
{
    //[TestMethod]
    //public void coordinator_should_be_able_to_access_StudentApplyList_page_if_logged_in()
    //{
    //    LoginPage.GoTo();
    //    LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
    //    StudentApplyListCoordinatorPage.GoTo();
    //    Assert.IsTrue(StudentApplyListCoordinatorPage.IsDisplayed);
    //}
    //[TestMethod]
    //public void coordinator_should_not_be_able_to_access_StudentApplyList_page_if_not_logged_in()
    //{
    //    StudentApplyListCoordinatorPage.GoToByUrl();
    //    Assert.IsTrue(LoginPage.IsDisplayed);
    //}
    //[TestMethod]
    //public void coordinator_should_be_able_to_see_StudentApplyList_with_students()
    //{
    //    LoginPage.GoTo();
    //    LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
    //    StudentApplyListCoordinatorPage.GoTo();
    //    Assert.AreNotEqual(0, StudentApplyListCoordinatorPage.CountNbApplies());
    //}
}
}