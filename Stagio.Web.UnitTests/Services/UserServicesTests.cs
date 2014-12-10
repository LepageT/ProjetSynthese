using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using Ploeh.AutoFixture;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;
using Stagio.Web.Services;
using Stagio.Web.UnitTests.ControllerTests.ContactEnterpriseTests;
using Stagio.Web.ViewModels.Interviews;


namespace Stagio.Web.UnitTests.Services
{
    [TestClass]
    public class UserServicesTests : AllControllersBaseClassTests
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IEntityRepository<Misc> _miscRepository;
        private AccountService _accountService;

        [TestInitialize]
        public void test_initialize()
        {
            _userRepository = Substitute.For<IEntityRepository<ApplicationUser>>();
            _miscRepository = Substitute.For<IEntityRepository<Misc>>();
            _accountService = new AccountService(_userRepository, _miscRepository);
        }

        [TestMethod]
        public void validate_should_return_a_user_when_username_and_password_are_valid()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            var nonHashedPassword = users.First().Password;
            foreach (var appUser in users)
            {
                appUser.Password = _accountService.HashPassword(appUser.Password);
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
                appUser.Password = _accountService.HashPassword(appUser.Password);
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

        [TestMethod]
        public void HashPassword_should_hash_the_password()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            var nonHashedPassword = users.First().Password;
            foreach (var appUser in users)
            {
                appUser.Password = _accountService.HashPassword(appUser.Password);
            }
            _userRepository.GetAll().Returns(users);

            nonHashedPassword.Should().NotBeSameAs(users.First().Password);
        }

        [TestMethod]
        public void UserEmailExist_should_return_true_if_email_exist()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.UserEmailExist(users.First().Email);

            user.Should().BeTrue();
        }

        [TestMethod]
        public void UserEmailExist_should_return_false_if_email_doesnt_exist()
        {
            var users = _fixture.CreateMany<ApplicationUser>(3).AsQueryable();
            _userRepository.GetAll().Returns(users);

            var user = _accountService.UserEmailExist("test@hotmail.com");

            user.Should().BeFalse();
        }

        [TestMethod]
        public void isCoordonator_should_return_true_if_coordonator()
        {
            var user = _fixture.Create<ApplicationUser>();
            user.Roles = new List<UserRole>()
            {
                new UserRole() {RoleName = RoleName.Coordinator},
            };

            var result = _accountService.isCoordonator(user);
            
            result.Should().BeTrue();
        }

        [TestMethod]
        public void isCoordonator_should_return_false_if_not_coordonator()
        {
            var user = _fixture.Create<ApplicationUser>();
            user.Roles = new List<UserRole>()
            {
                new UserRole() {RoleName = RoleName.Student},
                new UserRole() {RoleName = RoleName.ContactEnterprise}
            };

            var result = _accountService.isCoordonator(user);

            result.Should().BeFalse();
        }

        [TestMethod]
        public void isBetweenAccesibleDates_should_return_false_with_null_misc()
        {
            IQueryable<Misc> miscs = new EnumerableQuery<Misc>(new List<Misc>());

            _miscRepository.GetAll().Returns(miscs);

            var result = _accountService.isBetweenAccesibleDates();

            result.Should().BeFalse();
        }

        [TestMethod]
        public void isBetweenAccesibleDates_should_return_false_with_invalid_StartDate()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            misc.StartApplyDate = (DateTime.Today.AddDays(2)).ToString();
            misc.EndApplyDate = (DateTime.Today.AddDays(3)).ToString();
            _miscRepository.GetAll().Returns(miscs);

            var result = _accountService.isBetweenAccesibleDates();

            result.Should().BeFalse();
        }

        [TestMethod]
        public void isBetweenAccesibleDates_should_return_false_with_invalid_EndDate()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            misc.StartApplyDate = (DateTime.Today.AddDays(-5)).ToString();
            misc.EndApplyDate = (DateTime.Today.AddDays(-3)).ToString();
            _miscRepository.GetAll().Returns(miscs);

            var result = _accountService.isBetweenAccesibleDates();

            result.Should().BeFalse();
        }

        [TestMethod]
        public void isBetweenAccesibleDates_should_return_true_with_valid_dates()
        {
            var miscs = _fixture.CreateMany<Misc>(2).AsQueryable();
            var misc = miscs.First();
            misc.StartApplyDate = (DateTime.Today.AddDays(-1)).ToString();
            misc.EndApplyDate = (DateTime.Today.AddDays(3)).ToString();
            _miscRepository.GetAll().Returns(miscs);

            var result = _accountService.isBetweenAccesibleDates();

            result.Should().BeTrue();
        }
    }
}
