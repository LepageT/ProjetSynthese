using System;
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
        protected ContactEnterpriseController enterpriseController;
        protected IAccountService accountService;
        protected IMailler mailler;
        protected IEntityRepository<ContactEnterprise> enterpriseRepository;
        protected IEntityRepository<Stage> stageRepository;

        [TestInitialize]
        public void ContactControllerTestInit()
        {
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            mailler = Substitute.For<IMailler>();
            enterpriseController = new ContactEnterpriseController(enterpriseRepository, stageRepository, accountService, mailler);
            accountService = Substitute.For<IAccountService>();
        }
    }
}
