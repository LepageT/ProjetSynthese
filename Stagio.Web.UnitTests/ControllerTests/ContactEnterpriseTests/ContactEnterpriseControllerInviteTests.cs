using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;


namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerInviteTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_inviteContactEnteprise_get_should_return_inviteContactEnterprise_view()
        {
            var result = enterpriseController.InviteContactEnterprise() as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contact_enterprise_inviteContactEnteprise_post_should_return_default_view_when_modelState_is_not_valid()
        {
            var enterpriseInvalid = _fixture.Create<ViewModels.ContactEnterprise.Invite>();
            enterpriseInvalid.Email = null;
            enterpriseController.ModelState.AddModelError("Error", "Error");

            var result = enterpriseController.InviteContactEnterprise(enterpriseInvalid) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contact_enterprise_inviteContactEnteprise_post_should_return_confirmation_on_success()
        {
            var enterpriseValid = _fixture.Create<ViewModels.ContactEnterprise.Invite>();
            enterpriseValid.Email = "test@hotmail.com";
            mailler.SendEmail(enterpriseValid.Email, "Test", "").ReturnsForAnyArgs(true);

            var result = enterpriseController.InviteContactEnterprise(enterpriseValid) as RedirectToRouteResult;
            var action = result.RouteValues["Action"];

            action.ShouldBeEquivalentTo(MVC.ContactEnterprise.Views.ViewNames.InviteContactEnterpriseConfirmation);
        }

        [TestMethod]
        public void contact_enterprise_inviteContactEnterprise_post_should_return_default_view_when_mailler_cant_send()
        {
            var enterprise = _fixture.Create<ViewModels.ContactEnterprise.Invite>();

            mailler.SendEmail(Arg.Any<String>(), Arg.Any<String>(), Arg.Any<String>()).Returns(false);

            var result = enterpriseController.InviteContactEnterprise(enterprise) as ViewResult;

            result.ViewName.Should().Be("");
        }

    

    }
}
