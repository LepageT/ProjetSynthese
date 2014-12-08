using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerRemoveStudentsTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_not_be_able_to_access_RemoveStudents_page_if_not_logged_in()
        {
            RemoveStudentsCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();

        }


        [TestMethod]
        public void coordinator_should_be_able_to_see_RemoveStudents_with_students()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            RemoveStudentsCoordinatorPage.GoTo();

            RemoveStudentsCoordinatorPage.CountNbStudents().Should().NotBe(0);

        }


        [TestMethod]
        public void coordinator_should_be_able_to_delete_students_andd_see_confirmation_page()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            RemoveStudentsCoordinatorPage.GoTo();

            RemoveStudentsCoordinatorPage.DeleteStudents();

            RemoveStudentsCoordinatorPage.ConfirmationPageIsDisplayed.Should().BeTrue();


        }
    }
}
