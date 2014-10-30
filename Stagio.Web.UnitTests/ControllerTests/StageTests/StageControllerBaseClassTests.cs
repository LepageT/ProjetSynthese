using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<Stage> stageRepository;
        protected StageController stageController;
        
        [TestInitialize]
        public void StageControllerTestInit()
        {
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            stageController = new StageController(stageRepository);
        }
    }
}
