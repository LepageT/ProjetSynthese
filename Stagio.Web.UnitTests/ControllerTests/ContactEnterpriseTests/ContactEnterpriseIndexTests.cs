using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Automation.PageObjects.ContactEnterprise;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseIndexTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_index_should_render_view()
        {
           var result = enterpriseController.Index() as ViewResult;

            Assert.AreEqual("", result.ViewName);
          
        }

    }
}
