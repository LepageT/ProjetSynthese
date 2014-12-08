using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using FluentAssertions;

namespace Stagio.Web.UnitTests.ControllerTests.CoordinatorTests
{
    [TestClass]
    public class CoordinatorControllerInviteOneContactEnterpriseConfirmationTests : CoordinatorControllerBaseClassTests
    {
        [TestMethod]
        public void coordinator_inviteOneContactEnterpriseConfirmation_should_render_view()
        {
            var result = coordinatorController.InviteOneContactEnterpriseConfirmation() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
