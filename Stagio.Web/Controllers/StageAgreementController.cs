using System;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.StageAgreement;

namespace Stagio.Web.Controllers
{
    public partial class StageAgreementController : Controller
    {
        private readonly IEntityRepository<StageAgreement> _stageAgreementRepository;
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<ApplicationUser> _accountRepository;
        private readonly IAccountService _accountService;
        public StageAgreementController(IEntityRepository<StageAgreement> stageAgreement, IEntityRepository<Apply> applyRepository, IHttpContextService httpContextService, IEntityRepository<Stage> stageRepository, IEntityRepository<ApplicationUser> accountRepository, IAccountService accountService)
        {
            _httpContextService = httpContextService;
            _stageAgreementRepository = stageAgreement;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _accountRepository = accountRepository;
            _accountService = accountService;
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult CreateConfirmation(int idApply)
        {
            var apply = _applyRepository.GetById(idApply);
            var stageAgreement = new StageAgreement();
            stageAgreement.IdStage = apply.IdStage;
            stageAgreement.IdStudentSigned = apply.IdStudent;
            stageAgreement.IdCoordinatorSigned = _httpContextService.GetUserId();
            _stageAgreementRepository.Add(stageAgreement);

            return View();
        }


        [Authorize()]
  
        public virtual ActionResult Edit(int idStageAgreement)
        {
            var stageAgreement = _stageAgreementRepository.GetById(idStageAgreement);


            if (stageAgreement != null)
            {
                var stage = _stageRepository.GetById(stageAgreement.IdStage);
                var stageAgreementEditPageViewModel = Mapper.Map<ViewModels.StageAgreement.EditStageAgreement>(stageAgreement);
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

           [Authorize()]
        [HttpPost]
        public virtual ActionResult Edit(EditStageAgreement signStageAgreementViewModel)
        {
            var stageAgreement = _stageAgreementRepository.GetById(signStageAgreementViewModel.Id);
            var user = _accountRepository.GetById(_httpContextService.GetUserId());
            if (!ModelState.IsValid)
            {
                return RedirectToAction(MVC.StageAgreement.Edit(stageAgreement.Id));
            }

            if (!stageAgreement.StudentHasSigned && signStageAgreementViewModel.StudentSignature != null)
            {
                if (_accountService.ValidatePassword(user.Password, signStageAgreementViewModel.StudentSignature))
                {
                    signStageAgreementViewModel.DateStudentSigned = DateTime.Now.ToShortDateString();
                    signStageAgreementViewModel.StudentHasSigned = true;
                }
                else
                {
                    return RedirectToAction(MVC.StageAgreement.Edit(stageAgreement.Id));
                }
            }

            if (!stageAgreement.CoordinatorHasSigned && signStageAgreementViewModel.CoordinatorSignature != null)
            {
                if (_accountService.ValidatePassword(user.Password, signStageAgreementViewModel.CoordinatorSignature))
                {
                    signStageAgreementViewModel.DateCoordinatorSigned = DateTime.Now.ToShortDateString();
                    signStageAgreementViewModel.CoordinatorHasSigned = true;
                }
                else
                {
                    return RedirectToAction(MVC.StageAgreement.Edit(stageAgreement.Id));
                }
            }

            if (!stageAgreement.ContactEnterpriseHasSigned && signStageAgreementViewModel.ContactEnterpriseSignature != null)
            {
                if (_accountService.ValidatePassword(user.Password, signStageAgreementViewModel.ContactEnterpriseSignature))
                {
                    signStageAgreementViewModel.DateContactEnterpriseSigned = DateTime.Now.ToShortDateString();
                    signStageAgreementViewModel.ContactEnterpriseHasSigned = true;
                }
                else
                {
                    return RedirectToAction(MVC.StageAgreement.Edit(stageAgreement.Id));
                }
            }

            Mapper.Map(signStageAgreementViewModel, stageAgreement);

            _stageAgreementRepository.Update(stageAgreement);

            return RedirectToAction(MVC.Home.Index());
        }


    }
}