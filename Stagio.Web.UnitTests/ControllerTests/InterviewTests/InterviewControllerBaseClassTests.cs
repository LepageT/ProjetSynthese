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
        protected InterviewController interviewController;

        [TestInitialize]
        public void StageControllerTestInit()
        {
            interviewRepository = Substitute.For<IEntityRepository<Interview>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            httpContextService = Substitute.For<IHttpContextService>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            interviewController = new InterviewController(applyRepository, stageRepository, httpContextService, interviewRepository);
        }
    }
}
