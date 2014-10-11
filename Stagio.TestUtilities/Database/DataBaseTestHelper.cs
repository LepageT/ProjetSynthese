using Stagio.DataLayer.EntityFramework;
using Stagio.Domain.Entities;

namespace Stagio.TestUtilities.Database
{
    public class DataBaseTestHelper
    {
        private EfEntityRepository<ApplicationUser> _userRepository;
        private EfEntityRepository<Student> _studentRepository; 

         public DataBaseTestHelper()
        {
             _studentRepository = new EfEntityRepository<Student>();
            _userRepository = new EfEntityRepository<ApplicationUser>();
        }

        public void SeedTables()
        {
            addStudents();
            addUser();
        }

        private void addUser()
        {
            var user = TestData.applicationUser;
            _userRepository.Add(user);
 
        }

        private void addStudents()
        {
            var student1 = TestData.sudent1;
            _studentRepository.Add(student1);

            var student2 = TestData.sudent2;
            _studentRepository.Add(student2);
        }

    }
}
