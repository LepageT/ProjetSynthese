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
        protected INotificationService notificationService;
        protected StageController stageController;
        protected IHttpContextService httpContextService;
        protected IEntityRepository<Coordinator> coordinatorRepository;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<Interview> interviewRepository;
        protected IEntityRepository<Apply> applyRepository;
        [TestInitialize]
        public void StageControllerTestInit()
        {
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            httpContextService = Substitute.For<IHttpContextService>();
            notificationService = Substitute.For<INotificationService>();
            contactEnterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            httpContextService = Substitute.For<IHttpContextService>();
            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            interviewRepository = Substitute.For<IEntityRepository<Interview>>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            stageController = new StageController(stageRepository, httpContextService, contactEnterpriseRepository, notificationService, coordinatorRepository, studentRepository,applyRepository, interviewRepository);
        }
    }
}
