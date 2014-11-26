using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerCreateTests : StageAgreementControllerBaseClassTests
    {
        [TestMethod]
        public void create_stage_agreement_should_render_view()
        {
            var result = stageAgreementController.CreateConfirmation() as ViewResult;

            result.ViewName.Should().Be(""); 
        }

        
    }
}
