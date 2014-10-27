using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Mappers;

namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
 
        protected Fixture _fixture;


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
