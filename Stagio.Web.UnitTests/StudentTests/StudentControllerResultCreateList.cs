using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.StudentTests
{
    [TestClass]
    public class StudentControllerResultCreateList : AllControllersBaseClassTests
    {

        [TestMethod]
        public void resultCreatelist_action_should_render_default_view()
        {
            var result = studentController.ResultCreateList() as ViewResult;

            Assert.AreEqual("", result.ViewName);
        }

    }
}
