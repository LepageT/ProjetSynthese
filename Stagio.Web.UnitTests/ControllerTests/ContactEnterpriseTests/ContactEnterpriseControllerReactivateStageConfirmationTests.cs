using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.Domain.Entities;
using Ploeh.AutoFixture;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerReactivateStageConfirmationTests : ContactEnterpriseControllerBaseClassTests
    {
        [TestMethod]
        public void contact_enterprise_remove_stage_should_render_view()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            var result = enterpriseController.ReactivateStageConfirmation(stage.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contact_enterprise_remove_stage_should_update_DB()
        {
            var stage = _fixture.Create<Stage>();
            stageRepository.GetById(stage.Id).Returns(stage);

            enterpriseController.ReactivateStageConfirmation(stage.Id);

            stageRepository.Received().Update(Arg.Is<Stage>(x => x.Status == StageStatus.New));
        }

        [TestMethod]
        public void contact_enterprise_remove_stage_should_return_httpnotfound_if_id_invalid()
        {
            var result = enterpriseController.ReactivateStageConfirmation(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
