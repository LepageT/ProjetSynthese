using System;
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
            var user = _fixture.Create<ContactEnterprise>();
            httpContext.GetUserId().Returns(user.Id);
            enterpriseRepository.GetById(user.Id).Returns(user);
            stage.CompanyName = user.EnterpriseName;
            var applies = _fixture.Build<Apply>().With(x => x.IdStage, stage.Id).CreateMany(3);
            stageRepository.GetById(stage.Id).Returns(stage);
            applyRepository.GetAll().Returns(applies.AsQueryable());

            var result = enterpriseController.RemoveStageConfirmation(stage.Id) as ViewResult;

            result.ViewName.Should().Be("");
        }

        [TestMethod]
        public void contact_enterprise_remove_stage_should_update_DB()
        {
            var stage = _fixture.Create<Stage>();
            var user = _fixture.Create<ContactEnterprise>();
            httpContext.GetUserId().Returns(user.Id);
            enterpriseRepository.GetById(user.Id).Returns(user);
            stage.CompanyName = user.EnterpriseName;
            var applies = _fixture.Build<Apply>().With(x => x.IdStage, stage.Id).CreateMany(3);
            stageRepository.GetById(stage.Id).Returns(stage);
            applyRepository.GetAll().Returns(applies.AsQueryable());

            enterpriseController.RemoveStageConfirmation(stage.Id);

            stageRepository.Received().Update(Arg.Is<Stage>(x => x.Status == StageStatus.Removed));
        }

        [TestMethod]
        public void contact_enterprise_remove_stage_should_return_httpnotfound_if_id_invalid()
        {
            var result = enterpriseController.RemoveStageConfirmation(INVALID_ID);

            result.Should().BeOfType<HttpNotFoundResult>();
        }
    }
}
