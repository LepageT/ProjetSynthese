
using System;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Ninject.Infrastructure.Disposal;
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
        private readonly IEntityRepository<StageAgreement> _stageAgreementRepository;
        private readonly IEntityRepository<Stage> _stageRepository;

        public AccountController(IHttpContextService httpContext,
            IAccountService accountService, IEntityRepository<ApplicationUser> accountRepository, IEntityRepository<StageAgreement> stageAgreemenrRepository, IEntityRepository<Stage> stageRepository  )
        {
            _accountRepository = accountRepository;
            _httpContext = httpContext;
            _accountService = accountService;
            _stageAgreementRepository = stageAgreemenrRepository;
            _stageRepository = stageRepository;
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

        public virtual ActionResult SignStageAgreement(int idStageAgreement)
        {
            var stageAgreement = _stageAgreementRepository.GetById(idStageAgreement);
            var stage = _stageRepository.GetById(stageAgreement.IdStage);

            if (stageAgreement != null)
            {
                var stageAgreementEditPageViewModel = Mapper.Map<SignStageAgreement>(stageAgreement);
                stageAgreementEditPageViewModel.CompanyName = stage.CompanyName;
                stageAgreementEditPageViewModel.Adresse = stage.Adresse;
                stageAgreementEditPageViewModel.ResponsableToEmail = stage.ResponsableToEmail;
                stageAgreementEditPageViewModel.ResponsableToName = stage.ResponsableToName;
                stageAgreementEditPageViewModel.ResponsableToPhone = stage.ResponsableToPhone;
                stageAgreementEditPageViewModel.ResponsableToTitle = stage.ResponsableToTitle;
                stageAgreementEditPageViewModel.ResponsableToPoste = stage.ResponsableToPoste;
                stageAgreementEditPageViewModel.StudentName = _accountRepository.GetById(stageAgreement.IdStudentSigned).FirstName + " " + _accountRepository.GetById(stageAgreement.IdStudentSigned).LastName;
                stageAgreementEditPageViewModel.Matricule =
                        Convert.ToInt32(_accountRepository.GetById(stageAgreement.IdStudentSigned).UserName);
                stageAgreementEditPageViewModel.CoordinatorName = _accountRepository.GetById(stageAgreement.IdCoordinatorSigned).FirstName + " " + _accountRepository.GetById(stageAgreement.IdCoordinatorSigned).LastName;
                stageAgreementEditPageViewModel.CoordinatorPhone =
                    _accountRepository.GetById(stageAgreement.IdCoordinatorSigned).Telephone;
                stageAgreementEditPageViewModel.CoordinatorEmail =
                  _accountRepository.GetById(stageAgreement.IdCoordinatorSigned).Email;
                stageAgreementEditPageViewModel.CoordinatorPoste =
                  _accountRepository.GetById(stageAgreement.IdCoordinatorSigned).Poste;
                
                return View(stageAgreementEditPageViewModel);
            }
            return HttpNotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult SignStageAgreement(SignStageAgreement signStageAgreementViewModel)
        {
            var stageAgreement = _stageAgreementRepository.GetById(signStageAgreementViewModel.Id);
            var user = _accountRepository.GetById(_httpContext.GetUserId());
            if (!ModelState.IsValid)
            {
                return View(stageAgreement.Id);
            }

            if (!stageAgreement.StudentHasSigned && signStageAgreementViewModel.StudentSignature != null)
            {
                if(_accountService.HashPassword(signStageAgreementViewModel.StudentSignature) == user.Password )
                {
                    signStageAgreementViewModel.DateStudentSigned = DateTime.Now.ToShortDateString();
                    signStageAgreementViewModel.StudentHasSigned = true; 
                }
                else
                {
                    return View(stageAgreement.Id);
                }
            }

            if (!stageAgreement.CoordinatorHasSigned && signStageAgreementViewModel.CoordinatorSignature != null)
            {
                if (_accountService.HashPassword(signStageAgreementViewModel.CoordinatorSignature) == user.Password)
                {
                    signStageAgreementViewModel.DateCoordinatorSigned = DateTime.Now.ToShortDateString();
                    signStageAgreementViewModel.CoordinatorHasSigned = true;
                }
                else
                {
                    return View(stageAgreement.Id);
                }
            }

            if (!stageAgreement.ContactEnterpriseHasSigned && signStageAgreementViewModel.ContactEnterpriseSignature != null)
            {
                if (_accountService.HashPassword(signStageAgreementViewModel.ContactEnterpriseSignature) == user.Password)
                {
                    signStageAgreementViewModel.DateContactEnterpriseSigned = DateTime.Now.ToShortDateString();
                    signStageAgreementViewModel.ContactEnterpriseHasSigned = true;
                }
                else
                {
                    return View(stageAgreement.Id);
                }
            }

            Mapper.Map(signStageAgreementViewModel, stageAgreement);

            _stageAgreementRepository.Update(stageAgreement);

            return RedirectToAction(MVC.Home.Index());
        }
    }

}