using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.EnterpriseTests
{
    [TestClass]
    public class EnterpriseControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<Enterprise> enterpriseRepository;
        protected IEntityRepository<Stage> stageRepository; 
        protected EnterpriseController enterpriseController;
        protected IAccountService accountService;
        
        [TestInitialize]
        public void EnterpriseControllerInitTest()
        {
            enterpriseRepository = Substitute.For<IEntityRepository<Enterprise>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            accountService = Substitute.For<IAccountService>();
            enterpriseController = new EnterpriseController(enterpriseRepository, stageRepository, accountService);
        }
    }
}
