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
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerRemoveStageConfirmationTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_remove_stage_should_render_view()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            var result = enterpriseController.RemoveStageConfirmation(stage.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contact_enterprise_remove_stage_should_update_DB()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            enterpriseController.RemoveStageConfirmation(stage.Id);

            stageRepository.Received().Update(Arg.Is<Stage>(x => x.Status == StageStatus.Removed));
        }

        [TestMethod]
        public void contact_enterprise_remove_stage_should_return_httpnotfound_if_id_invalid()
        {
            var result = enterpriseController.RemoveStageConfirmation(9999999);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
