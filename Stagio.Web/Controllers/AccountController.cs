
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IHttpContextService _httpContext;
        private readonly IAccountService _accountService;

        public AccountController(IHttpContextService httpContext,
                                 IAccountService accountService)
        {
            _httpContext = httpContext;
            _accountService = accountService;
        }
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
            
            var user = _accountService.ValidateUser(accountLoginViewModel.Username, accountLoginViewModel.Password);

            if (!user.Any())
            {
                ModelState.AddModelError("loginError", "Mot de passe ou nom d'utilisateur non existant");
                return View("");
            }

            AuthentificateUser(user.First());

            return RedirectToAction(MVC.Home.Index());
        }

        public virtual ActionResult Logout()
        {
            _httpContext.AuthenticationSignOut();
            return RedirectToAction(Views.ViewNames.Login);
        }

        private void AuthentificateUser(ApplicationUser applicationUser)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, applicationUser.FirstName + " " + applicationUser.LastName),
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