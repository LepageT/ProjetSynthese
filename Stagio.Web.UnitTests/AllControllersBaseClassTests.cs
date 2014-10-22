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

        protected StudentController studentController;
        protected Fixture _fixture;
        protected IEntityRepository<Student> studentRepository;

        protected IEntityRepository<Coordinator> coordinatorRepository;
        protected IEntityRepository<Invitation> invitationRepository;
        protected IEntityRepository<ContactEnterprise> enterpriseRepository;
        protected IMailler mailler;

        protected CoordinatorController coordinatorController;
        protected ContactEnterpriseController enterpriseController;

        protected IAccountService accountService;

            
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
            coordinatorController = new CoordinatorController(enterpriseRepository, coordinatorRepository, invitationRepository, mailler, accountService);

        }
    }
}
