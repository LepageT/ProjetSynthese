
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects;
using Stagio.Web.Automation.PageObjects.Coordinator;

namespace Stagio.Web.AcceptanceTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerDetailsApplyStudentTests : BaseTests
    {
        [TestMethod]
        public void contactEnterprise_should_not_download_files_isfiles_not_valid()
        {
            LoginPage.GoTo();
            LoginPage.LoginAs(ContactEnterpriseUsername, ContactEnterprisePassword);
            DetailsStudentApplyCoordinatorPage.GoToByUrl();

            DetailsStudentApplyCoordinatorPage.DownloadPage();

            DetailsStudentApplyCoordinatorPage.ErrorDisplayed.Should().BeTrue();
        }

    }
}
