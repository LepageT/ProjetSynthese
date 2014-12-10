using System;
using FluentAssertions.Events;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Utilities.Encryption;
using System.Collections.Generic;
using System.Linq;

namespace Stagio.Web.Services
{
    public class AccountService : IAccountService
    {
        private IEntityRepository<ApplicationUser> _userRepository;
        private IEntityRepository<Misc> _miscRepository;

        public AccountService(IEntityRepository<ApplicationUser> userRepository, IEntityRepository<Misc> miscRepository )
        {
            _userRepository = userRepository;
            _miscRepository = miscRepository;
        }
        public MayBe<ApplicationUser> ValidateUser(string userName, string password)
        {
            var user = _userRepository.GetAll().FirstOrDefault(x => x.UserName == userName);

            if (user == null)
            {
                return new MayBe<ApplicationUser>();
            }
            if (user.Active == false)
            {
                return new MayBe<ApplicationUser>();
            }
            if (user.Password == null)
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

        public bool ValidatePassword(string hashedPassword, string passwordToValidate)
        {
            return PasswordHash.ValidatePassword(passwordToValidate, hashedPassword);
        }

        public bool UserEmailExist(string email)
        {

            IEnumerable<string> emails = _userRepository.GetAll().Where(x => x.Email != null).Select(x => x.Email);
            if (emails.Contains(email))
            {
                return true;
            }
            return false;
        }

        public bool isCoordonator(ApplicationUser user)
        {
            foreach (var role in user.Roles)
            {
                if (role.RoleName == RoleName.Coordinator)
                {
                   return true; 
                }
            }
            return false;
        }

        public bool isStudent(ApplicationUser user)
        {
            foreach (var role in user.Roles)
            {
                if (role.RoleName == RoleName.Student)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isContactEnterprise(ApplicationUser user)
        {
            foreach (var role in user.Roles)
            {
                if (role.RoleName == RoleName.ContactEnterprise)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isBetweenAccesibleDates()
        {
            var misc = _miscRepository.GetAll().FirstOrDefault();
            if (misc == null)
            {
                return false;
            }
            
            if (DateTime.Now >= Convert.ToDateTime(misc.StartApplyDate))
            {
                if (DateTime.Now <= Convert.ToDateTime(misc.EndApplyDate))
                {
                    return true;
                }
            }
            return false;
        }

    }
}