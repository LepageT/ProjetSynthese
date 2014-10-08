using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using Stagio.Utilities.Encryption;

namespace Stagio.Web.Controllers
{
    public partial class AccountController : Controller
    {
        // GET: Account
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(ViewModels.Account.Login accountLoginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("");
            }

            var user = _accountService.ValidateUser(accountLoginViewModel.UserName, accountLoginViewModel.Password);

            if (!user.Any())
            {
                ModelState.AddModelError("loginError", "Inexistant password or username");
                return View("");
            }

            AuthentificateUser(user.First());

            return RedirectToAction(MVC.Home.Index());
        }
        private void AuthentificateUser(ApplicationUser applicationUser)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, applicationUser.Email),
                new Claim(ClaimTypes.NameIdentifier, applicationUser.Id.ToString()),
            },
                DefaultAuthenticationTypes.ApplicationCookie);

            foreach (var role in applicationUser.Roles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role.RoleName));
            }

            _httpContext.AuthenticationSignIn(identity);
        }
    }
}