using System.Security.Claims;

namespace Stagio.Web.Services
{
    public interface IHttpContextService
    {
        int GetUserId();
        void AuthenticationSignIn(ClaimsIdentity identity);
        void AuthenticationSignOut();

    }
}