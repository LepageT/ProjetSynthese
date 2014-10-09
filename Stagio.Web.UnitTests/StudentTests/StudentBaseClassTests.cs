using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.TestUtility.AutoFixture;
using Stagio.Web.Controllers;
using Stagio.Web.Mappers;

namespace Stagio.Web.UnitTests.StudentTests
{
    public class StudentBaseClassTests
    {
        protected StudentController studentController;
        protected Fixture _fixture;
        protected IEntityRepository<Stagio.Domain.Entities.Student> studentRepository;
            
        [TestInitialize]
        public void ControllerTestInit()
        {
            AutoMapperConfiguration.Configure();

            _fixture = new Fixture();
            _fixture.Customizations.Add(new VirtualMembersOmitter());

            studentRepository = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Student>>();
            studentController = new StudentController(studentRepository);
        }
    }
}
