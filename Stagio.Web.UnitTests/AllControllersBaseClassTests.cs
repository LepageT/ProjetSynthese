using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ploeh.AutoFixture;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Mappers;

namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
 
        protected Fixture _fixture;

        protected IEntityRepository<Coordinator> coordinatorRepository;
        protected IEntityRepository<Invitation> invitationRepository;
        protected IEntityRepository<ContactEnterprise> enterpriseRepository; 

        protected CoordinatorController coordinatorController;
        protected ContactEnterpriseController enterpriseController;

            
        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());


            coordinatorRepository = Substitute.For<IEntityRepository<Coordinator>>();
            invitationRepository = Substitute.For<IEntityRepository<Invitation>>();
            enterpriseRepository = Substitute.For<IEntityRepository<ContactEnterprise>>();

            mailler = Substitute.For<IMailler>();

            studentController = new StudentController(studentRepository);
            enterpriseController = new ContactEnterpriseController(enterpriseRepository);
            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler);

        }
    }
}
