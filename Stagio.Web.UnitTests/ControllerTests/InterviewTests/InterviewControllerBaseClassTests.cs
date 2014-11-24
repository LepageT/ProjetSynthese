using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.Controllers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.InterviewTests
{
    [TestClass]
    public class InterviewControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected IEntityRepository<Interview> interviewRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected IHttpContextService httpContextService;
        protected IEntityRepository<Apply> applyRepository;
        protected IEntityRepository<ApplicationUser> applicationUserRepository;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<Notification> notificationRepository;
        protected InterviewController interviewController;

        [TestInitialize]
        public void StageControllerTestInit()
        {
            interviewRepository = Substitute.For<IEntityRepository<Interview>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            httpContextService = Substitute.For<IHttpContextService>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            applicationUserRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            interviewController = new InterviewController(applyRepository, stageRepository, httpContextService, interviewRepository,studentRepository,notificationRepository,applicationUserRepository);
        }
    }
}
