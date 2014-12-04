using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.Services
{
    public interface IAccountService
    {
        MayBe<ApplicationUser> ValidateUser(string email, string password);

        string HashPassword(string password);

        bool UserEmailExist(string email);

        bool isCoordonator(ApplicationUser user);

        bool isBetweenAccesibleDates();
    }
}