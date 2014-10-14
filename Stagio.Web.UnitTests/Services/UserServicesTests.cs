using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;
using Stagio.Web.Services;

namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class UserServicesTests : AllControllersBaseClassTests
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private AccountService _accountService;

        [TestInitialize]
        public void test_initialize()
        {
            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _accountService = new AccountService(_userRepository);
        }

        [TestMethod]
        public void validate_should_return_a_user_when_username_and_password_are_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            var nonHashedPassword = users.First().Password;
            foreach (var appUser in users)
            {
                appUser.Password = PasswordHash.CreateHash(appUser.Password);
            }
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().UserName, nonHashedPassword);

            user.First().ShouldBeEquivalentTo(users.First());
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_password_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            foreach (var appUser in users)
            {
                appUser.Password = PasswordHash.CreateHash(appUser.Password);
            }
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser(users.First().UserName, "INVALID PASSWORD");

            user.Should().BeEmpty();
        }

        [TestMethod]
        public void validate_should_return_empty_list_when_username_is_not_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.ValidateUser("INVALID EMAIL", users.First().Password);

            user.Should().BeEmpty();
        }

    }
}
