using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;
using Stagio.Web.Automation.PageObjects.Student;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class StudentControllerUploadTests : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_the_page_upload_student_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            AddStudentsCoordinatorPage.GoTo();

            AddStudentsCoordinatorPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_see_the_page_upload_student_if_not_logged_in()
        {
            AddStudentsCoordinatorPage.GoToByUrl();

            LoginPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_should_be_able_to_choose_a_file_csv()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);

            AddStudentsCoordinatorPage.GoTo();

            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv").Should().BeTrue();


        }

        [TestMethod]
        public void coordinator_should_not_be_able_to_import_an_another_file_than_csv()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();

            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.txt");

            AddStudentsCoordinatorPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_upload_should_redirect_to_CreateList_is_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();

            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv");

            CreateListStudentsCoordinatorPage.IsDisplayed.Should().BeTrue();

        }

        [TestMethod]
        public void coordinator_upload_should_rest_on_to_upload_is_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();

            AddStudentsCoordinatorPage.SelectCsvFile("");

            AddStudentsCoordinatorPage.IsDisplayed.Should().BeTrue();

        }

    }
}
