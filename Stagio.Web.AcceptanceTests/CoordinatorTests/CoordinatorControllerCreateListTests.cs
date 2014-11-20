using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.TestUtilities.Database;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class StudentControllerCreateListTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_the_page_createList_student_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            AddStudentsCoordinatorPage.GoTo();
            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv");

            CreateListStudentsCoordinatorPage.IsDisplayed.Should().BeTrue();
           
        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_see_the_page_createList_student_not_if_logged_in()
        {
            CreateListStudentsCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();
           
        }

        [TestMethod]
        public void coordinator_creatList_should_redirect_on_resultCreateList()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();
            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv");
           
            CreateListStudentsCoordinatorPage.ClickToCreatelist();

            ResultatCreateListStudentPage.IsDisplayed.Should().BeTrue();
            

        }
    }
}
