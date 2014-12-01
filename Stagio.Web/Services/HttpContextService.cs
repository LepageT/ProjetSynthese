
using System;
using System.Security.Claims;
using System.Security.Policy;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using NSubstitute.Core;
using Stagio.Domain.Application;

namespace Stagio.Web.Services
{
    public class HttpContextService : IHttpContextService
    {
        public int GetUserId()
        {
            var userId = HttpContext.Current.User.Identity.GetUserId();

            return int.Parse(userId);
        }

        public void AuthenticationSignIn(ClaimsIdentity identity)
        {
            HttpContext.Current.GetOwinContext().Authentication.SignIn(new AuthenticationProperties(), identity);
        }

        public void AuthenticationSignOut()
        {
            HttpContext.Current.GetOwinContext().Authentication.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
        }

       

    }
}