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

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerCreateTests : StageAgreementControllerBaseClassTests
    {
        [TestMethod]
        public void create_stage_agreement_should_render_view()
        {
            var apply = _fixture.Create<Apply>();
            applyRepository.GetById(apply.Id).Returns(apply);

            var result = stageAgreementController.CreateConfirmation(apply.Id) as ViewResult;

            result.ViewName.Should().Be(""); 
        }

        [TestMethod]
        public void create_stage_agreement_should_add_stage_agreement_in_DB()
        {
            var apply = _fixture.Create<Apply>();
            
            applyRepository.GetById(apply.Id).Returns(apply);

            stageAgreementController.CreateConfirmation(apply.Id);

            stageAgreementRepository.Received().Add(Arg.Is<StageAgreement>(x => x.IdStage == apply.IdStage));
            stageAgreementRepository.Received().Add(Arg.Is<StageAgreement>(x => x.IdStudentSigned == apply.IdStudent));
            stageAgreementRepository.Received().Add(Arg.Is<StageAgreement>(x => x.ContactEnterpriseHasSigned == false));
            stageAgreementRepository.Received().Add(Arg.Is<StageAgreement>(x => x.StudentHasSigned == false));
            stageAgreementRepository.Received().Add(Arg.Is<StageAgreement>(x => x.CoordinatorHasSigned == false));
        }

        
    }
}
