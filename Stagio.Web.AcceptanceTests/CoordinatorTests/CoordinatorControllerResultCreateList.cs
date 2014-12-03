using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class StudentControllerResultCreateList : BaseTests
    {



        [TestMethod]
        public void coordinator_createList_should_redirect_on_home_index()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(CoordonatorUsername, CoordonatorPassword);
            AddStudentsCoordinatorPage.GoTo();
            AddStudentsCoordinatorPage.SelectCsvFile("C:\\dev\\abc.csv");
            CreateListStudentsCoordinatorPage.ClickToCreatelist();

            ResultCreateListStudentsCoordinatorPage.ClickResultButton();

            HomePage.IsDisplayed.Should().BeTrue();

        }
    }
}
