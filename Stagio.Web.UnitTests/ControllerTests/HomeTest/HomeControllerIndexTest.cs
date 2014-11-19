using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.HomeTest
{
    [TestClass]
    public class HomeControllerIndexTest : HomeControllerBaseTest
    {
        [TestMethod]
        public void home_index_should_render_view()
        {
            var result = homeController.Index() as ViewResult;

            result.ViewName.Should().Be("");
        }
    }
}
