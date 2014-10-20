using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.Domain.Entities;
using Stagio.TestUtilities.AutoFixture;
using Stagio.Web.Controllers;
using Stagio.DataLayer;
using Stagio.Web.Mappers;


namespace Stagio.Web.UnitTests
{
    public class AllControllersBaseClassTests
    {
        protected StudentController studentController;
        protected Fixture _fixture;
        protected IEntityRepository<Stagio.Domain.Entities.Student> studentRepository;
        //protected IEntityRepository<Stagio.Domain.Entities.Activation> activationReposity;

        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            studentRepository = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Student>>();
            //activationReposity = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Activation>>();

            studentController = new StudentController(studentRepository);
        }
    }
}
