using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Web.Controllers;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    public class StudentBaseClassTests : AllControllersBaseClassTests
    {
        protected StudentController studentController;
        protected IEntityRepository<Stagio.Domain.Entities.Student> studentRepository;
            
        [TestInitialize]
        public void StudentControllerTestInit()
        {

            studentRepository = Substitute.For<IEntityRepository<Stagio.Domain.Entities.Student>>();
            studentController = new StudentController(studentRepository);
        }
    }
}
