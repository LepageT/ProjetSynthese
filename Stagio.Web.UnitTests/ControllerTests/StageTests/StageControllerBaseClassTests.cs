using System;
using System.Web;
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
        protected IEntityRepository<ContactEnterprise> contactEnterpriseRepository;
        protected IHttpContextService httpContextService;
        protected INotificationService notificationService;
        protected StageController stageController;
        
        [TestInitialize]
        public void StageControllerTestInit()
        {
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            httpContextService = Substitute.For<IHttpContextService>();
            notificationService = Substitute.For<INotificationService>();
            contactEnterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            stageController = new StageController(stageRepository, httpContextService, contactEnterpriseRepository, notificationService);
        }
    }
}
