
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Controller;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Account;

namespace Stagio.Web.Controllers
{
    public partial class AccountController : Controller
    {
        private readonly IHttpContextService _httpContext;
        private readonly IAccountService _accountService;
        private readonly IEntityRepository<ApplicationUser> _accountRepository;

        public AccountController(IHttpContextService httpContext,
            IAccountService accountService, IEntityRepository<ApplicationUser> accountRepository)
        {
            _accountRepository = accountRepository;
            _httpContext = httpContext;
            _accountService = accountService;
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
                ModelState.AddModelError("loginError", AccountResources.ErrorLogin);
                this.Flash(AccountResources.ErrorLogin, FlashEnum.Error);
                return View("");
            }

            AuthentificateUser(user.First());
            if (User.IsInRole("Étudiant"))
            {
                return RedirectToAction(MVC.Student.Index());
            }
            else if (User.IsInRole("Coordonnateur"))
            {
                return RedirectToAction(MVC.Coordinator.Index());
            }
            else if (User.IsInRole("Contact entreprise"))
            {
                return RedirectToAction(MVC.ContactEnterprise.Index());
            }
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

        public virtual ActionResult Details(int id)
        {
            var userID = _httpContext.GetUserId();

            if (id != userID)
            {
                id = userID;
            }
            
            var account = _accountRepository.GetById(id);

            var details = Mapper.Map<Details>(account);

            if (account == null)
            {
                return HttpNotFound();
            }

            return View(details);
        }
    }

}