using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.StageAgreementTests
{
    [TestClass]
    public class StageAgreementControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected StageAgreementController stageAgreementController;
        protected IEntityRepository<StageAgreement> stageAgreementRepository;
        protected IEntityRepository<Apply> applyRepository;
        protected IEntityRepository<Stage> stageRepository;
            
        [TestInitialize]
        public void stageAgreementTestInit()
        {
            stageAgreementRepository = Substitute.For<IEntityRepository<StageAgreement>>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();

            stageAgreementController = new StageAgreementController(stageAgreementRepository, applyRepository, stageRepository);
        }
    }
}
