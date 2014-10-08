using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.EnterpriseTests
{
    [TestClass]
    class EnterpriseControllerCreateTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void create_action_should_render_default_view()
        {
            var result = enterpriseController.Create() as ViewResult;

            Assert.AreEqual(result.ViewName, "");
        }
    }
}
