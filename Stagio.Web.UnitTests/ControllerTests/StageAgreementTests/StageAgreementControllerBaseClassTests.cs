using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected StageAgreementController stageAgreementController;

        [TestInitialize]
        public void stageAgreementTestInit()
        {
            stageAgreementController = new StageAgreementController();
        }
    }
}
