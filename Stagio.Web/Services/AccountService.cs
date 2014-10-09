using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;

namespace Stagio.Web.Services
{
    public class AccountService : IAccountService
    {
        private IEntityRepository<ApplicationUser> _userRepository;

        public AccountService(IEntityRepository<ApplicationUser> userRepository)
        {
            _userRepository = userRepository;
        }
        public MayBe<ApplicationUser> ValidateUser(string userName, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == userName);

            if (user == null)
            {
                return new MayBe<ApplicationUser>();
            }
            if (!PasswordHash.ValidatePassword(password, user.Password))
            {
                return new MayBe<ApplicationUser>();
            }

            return new MayBe<ApplicationUser>(user);
        }

        public string HashPassword(string password)
        {
            return PasswordHash.CreateHash(password);
        }

        public bool UserEmailExist(string email)
        {
            throw new System.NotImplementedException();
        }

        public bool UserMatriculeExist(string matricule)
        {
            throw new System.NotImplementedException();
        }
    }
}