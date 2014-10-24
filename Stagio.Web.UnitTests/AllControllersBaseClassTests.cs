using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Controllers;
using Stagio.Web.Mappers;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
 
        protected Fixture _fixture;

        protected IEntityRepository<Coordinator> coordinatorRepository;
        protected IEntityRepository<Invitation> invitationRepository;
        protected IEntityRepository<ContactEnterprise> enterpriseRepository;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<Stage> stageRepository;

        protected StageController stageController;
        protected CoordinatorController coordinatorController;
        protected ContactEnterpriseController enterpriseController;
        protected StudentController studentController;
        protected AccountController accountController;
        protected IHttpContextService httpContext;
        protected IAccountService accountService;

        protected IMailler mailler;

        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            studentRepository = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Student>>();
            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            invitationRepository = Substitute.For<IEntityRepository<Invitation>>();
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();


            mailler = Substitute.For<IMailler>();

            stageController = new StageController(stageRepository);
            studentController = new StudentController(studentRepository);
            httpContext = Substitute.For<IHttpContextService>();
            accountService = Substitute.For<IAccountService>();
            accountController = new AccountController(httpContext, accountService); 
            enterpriseController = new ContactEnterpriseController(enterpriseRepository, stageRepository, accountService, mailler);
            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler, accountService);
        }
    }
}
