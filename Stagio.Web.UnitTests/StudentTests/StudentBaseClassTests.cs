using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Web.Controllers;
using Stagio.Web.Mappers;


namespace Stagio.Web.UnitTests.StudentTests
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
