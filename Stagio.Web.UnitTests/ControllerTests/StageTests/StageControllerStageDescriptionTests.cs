﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerStageDescriptionTests : AllControllersBaseClassTests
    {
        [TestMethod]
        public void stage_viewStageInfo_should_render_view()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(1).Returns(stage);


            var result = stageController.ViewStageInfo(1) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void stage_viewStageInfo_should_return_httpnotfound_if_stageId_is_not_valid()
        {
            var result = stageController.ViewStageInfo(999999999);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}