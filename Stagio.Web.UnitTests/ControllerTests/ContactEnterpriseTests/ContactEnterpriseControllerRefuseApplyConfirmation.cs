using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerRefuseApplyConfirmation : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void refuseApplyConfirmation_should_render_view()
        {
            var result = enterpriseController.RefuseApplyConfirmation() as ViewResult;

            result.ViewName.Should().Be(""); 
        }
    }
}
