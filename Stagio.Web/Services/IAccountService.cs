using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IAccountService
    {
        MayBe<ApplicationUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserEmailExist(string email);
    }
}