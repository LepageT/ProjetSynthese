
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerCreateStageTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void enterprise_createStage_get_should_return_createStage_view()
        {
            var result = enterpriseController.CreateStage() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void enterprise_createStage_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var stageViewModel = _fixture.Create<ViewModels.Stage.Create>();
            enterpriseController.ModelState.AddModelError("Error", "Error");

            var result = enterpriseController.CreateStage(stageViewModel) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void enterprise_createStage_post_should_return_index_on_success()
        {
            var stageViewModel = _fixture.Create<ViewModels.Stage.Create>();

            var result = enterpriseController.CreateStage(stageViewModel) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.CreateStageSucceed);
        }

        [TestMethod]
        public void enterprise_createStageSucceed_should_render_view()
        {
            var result = enterpriseController.CreateStageSucceed() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
