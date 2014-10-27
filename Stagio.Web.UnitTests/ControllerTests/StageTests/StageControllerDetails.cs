using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Ploeh;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerDetails : AllControllersBaseClassTests
    {
        [TestMethod]
        public void details_stage_should_render_a_view_details()
        {
            var stage = _fixture.Create<Stage>();

            var result = stageController.Details(stage.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

    }
}
