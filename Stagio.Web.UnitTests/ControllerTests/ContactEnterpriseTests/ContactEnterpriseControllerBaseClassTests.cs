using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests
{
    [TestClass]
    public class ContactEnterpriseControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<ContactEnterprise> enterpriseRepository;
        protected IEntityRepository<Stage> stageRepository; 
        protected ContactEnterpriseController enterpriseController;
        protected IAccountService accountService;
        
        [TestInitialize]
        public void EnterpriseControllerInitTest()
        {
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            accountService = Substitute.For<IAccountService>();
            enterpriseController = new ContactEnterpriseController(enterpriseRepository, stageRepository, accountService);

        }
    }
}
