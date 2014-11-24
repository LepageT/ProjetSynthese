using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Web.Controllers;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    public class StudentControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected StudentController studentController;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected IHttpContextService httpContextService;
        protected IEntityRepository<Apply> applyRepository;
        protected IMailler mailler;
        protected IAccountService accountService;
        protected IEntityRepository<ApplicationUser> applicationUserRepository;
        protected IEntityRepository<Notification> notificationRepository;
        protected IEntityRepository<ApplicationUser> applicationRepository;
            
       [TestInitialize]
        public void StudentControllerTestInit()
        {
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            httpContextService = Substitute.For<IHttpContextService>();
            mailler = Substitute.For<IMailler>();
            accountService = Substitute.For<IAccountService>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            notificationRepository = Substitute.For<IEntityRepository<Notification>>();
            applicationUserRepository = Substitute.For<IEntityRepository<ApplicationUser>>();


            studentController = new StudentController(studentRepository, stageRepository, applyRepository, httpContextService, mailler, accountService, notificationRepository, applicationUserRepository);
        }
    }
}
