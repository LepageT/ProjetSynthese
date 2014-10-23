using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Controllers;
using Stagio.DataLayer;
using Stagio.Web.Mappers;
using Stagio.Web.Services;


namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
        protected StudentController studentController;
        protected Fixture _fixture;
        protected IEntityRepository<Student> studentRepository;
        protected IMailler mailler;

        protected IEntityRepository<Coordinator> coordinatorRepository;
        protected IEntityRepository<Invitation> invitationRepository;
        protected IEntityRepository<Enterprise> enterpriseRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected StageController stageController;

        protected CoordinatorController coordinatorController;
        protected EnterpriseController enterpriseController;
            
        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            studentRepository = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Student>>();
            //activationReposity = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Activation>>();

            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            invitationRepository = Substitute.For<IEntityRepository<Invitation>>();
            enterpriseRepository = Substitute.For<IEntityRepository<Enterprise>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();


            mailler = Substitute.For<IMailler>();

            stageController = new StageController(stageRepository);
            studentController = new StudentController(studentRepository);
            enterpriseController = new EnterpriseController(enterpriseRepository, stageRepository);
            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler);
        }
    }
}
