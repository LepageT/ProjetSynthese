using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.StageTests
{
    [TestClass]
    public class StageControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<Stage> stageRepository;
        protected INotificationService notificationService;
        protected IEntityRepository<ContactEnterprise> contactEnterpriseRepository;
        protected StageController stageController;
        protected IHttpContextService httpContextService;
        protected IEntityRepository<Coordinator> coordinatorRepository;
            
        [TestInitialize]
        public void StageControllerTestInit()
        {
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            notificationService = Substitute.For<INotificationService>();
            contactEnterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            httpContextService = Substitute.For<IHttpContextService>();
            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();

            stageController = new StageController(stageRepository, notificationService, contactEnterpriseRepository, httpContextService, coordinatorRepository);
        }
    }
}
