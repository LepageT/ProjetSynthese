using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.StudentTests
{
    [TestClass]
    public class StudentControllerResultCreateList : BaseTests
    {
        [TestMethod]
        public void coordinator_should_be_able_to_see_the_page_resultCreateList_student_if_logged_in()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();
            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv");
            CreateListStudentsCoordinatorPage.ClickToCreatelist();

            Assert.IsTrue(ResultCreateListStudentsCoordinatorPage.IsDisplayed);
            
        }

        [TestMethod]
        public void coordinator_not_should_be_able_to_see_the_page_resultCreateList_student_not_if_logged_in()
        {
            CreateListStudentsCoordinatorPage.GoToByUrl();

            Assert.IsTrue(LoginPage.IsDisplayed);

        }

        [TestMethod]
        public void coordinator_createList_should_redirect_on_home_index()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();
            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv");
            CreateListStudentsCoordinatorPage.ClickToCreatelist();
            ResultCreateListStudentsCoordinatorPage.ClickResultButton();

            Assert.IsTrue(HomePage.IsDisplayed);

        }
    }
}
