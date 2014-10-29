using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Stagio.DataLayer;
using Stagio.Web.Controllers;
using Stagio.Domain.Entities;

namespace Stagio.Web.UnitTests.ControllerTests.StudentTests
{
    public class StudentControllerBaseClassTests : AllControllersBaseClassTests
    {
        protected StudentController studentController;
        protected IEntityRepository<Student> studentRepository;
        protected IEntityRepository<Stage> stageRepository;
        protected IEntityRepository<Apply> applyRepository;
        
        [TestInitialize]
        public void StudentControllerTestInit()
        {
            studentRepository = Substitute.For<IEntityRepository<Student>>();
            stageRepository = Substitute.For<IEntityRepository<Stage>>();
            applyRepository = Substitute.For<IEntityRepository<Apply>>();
            studentController = new StudentController(studentRepository, stageRepository, applyRepository);
        }
    }
}
