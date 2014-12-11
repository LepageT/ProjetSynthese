
﻿using System;
using System.Web.Mvc;
using AutoMapper;
﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
﻿using Stagio.Web.Module.Strings.Notification;
﻿using Stagio.Web.Services;
using Stagio.Web.ViewModels.StageAgreement;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

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
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository;
        private readonly INotificationService _notificationService;
        private readonly IEntityRepository<Coordinator> _coordinatorRepository;
        private readonly IEntityRepository<Student> _studentRepository; 

        public StageAgreementController(IEntityRepository<StageAgreement> stageAgreement, IEntityRepository<Apply> applyRepository, IEntityRepository<Stage> stageRepository, IEntityRepository<Student> studentRepository, IHttpContextService httpContextService, IEntityRepository<ApplicationUser> accountRepository, IEntityRepository<ContactEnterprise> contactEnterpriseRepository, IAccountService accountService, INotificationService notificationService, IEntityRepository<Coordinator> coordinatorRepository)
        {
            _httpContextService = httpContextService;
            _stageAgreementRepository = stageAgreement;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _accountRepository = accountRepository;
            _accountService = accountService;
            _httpContextService = httpContextService;
            _contactEnterpriseRepository = contactEnterpriseRepository;
            _notificationService = notificationService;
            _coordinatorRepository = coordinatorRepository;
            _studentRepository = studentRepository;
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

            string stageTitle = _stageRepository.GetById(stageAgreement.IdStage).StageTitle;
            string enterpriseName = _stageRepository.GetById(stageAgreement.IdStage).CompanyName;
            string message = String.Format(CoordinatorToContactEnterprise.StageAgreementCreatedMessage, stageTitle);

            _notificationService.SendNotificationToAllContactEnterpriseOf(enterpriseName,
                CoordinatorToContactEnterprise.StageAgreementCreatedTitle, message);
            _notificationService.SendNotificationToAllCoordinator(
                CoordinatorToContactEnterprise.StageAgreementCreatedTitle, message);
            _notificationService.SendNotificationTo(stageAgreement.IdStudentSigned,
                CoordinatorToContactEnterprise.StageAgreementCreatedTitle, message);

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
            var stage = _stageRepository.GetById(stageAgreement.IdStage);
            string stageName = stage.StageTitle;
            string enterpriseName = stage.CompanyName;

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
                    string firstName = _studentRepository.GetById(stageAgreement.IdStudentSigned).FirstName;
                    string lastName = _studentRepository.GetById(stageAgreement.IdStudentSigned).LastName;
                    string message = String.Format(CoordinatorToContactEnterprise.StageAgreementSignedMessage, firstName, lastName, stageName, stageAgreement.Id);
                    _notificationService.SendNotificationToAllCoordinator(
                    CoordinatorToContactEnterprise.StageAgreementSignedTitle, message);
                    _notificationService.SendNotificationToAllContactEnterpriseOf(enterpriseName,
                    CoordinatorToContactEnterprise.StageAgreementSignedTitle, message);
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
                    string firstName = _coordinatorRepository.GetById(stageAgreement.IdCoordinatorSigned).FirstName;
                    string lastName = _coordinatorRepository.GetById(stageAgreement.IdCoordinatorSigned).LastName;
                    string message = String.Format(CoordinatorToContactEnterprise.StageAgreementSignedMessage, firstName, lastName, stageName, stageAgreement.Id);
                    _notificationService.SendNotificationTo(stageAgreement.IdStudentSigned,
                    CoordinatorToContactEnterprise.StageAgreementSignedTitle, message);
                    _notificationService.SendNotificationToAllContactEnterpriseOf(enterpriseName,
                    CoordinatorToContactEnterprise.StageAgreementSignedTitle, message);
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
                    string firstName = _contactEnterpriseRepository.GetById(_httpContextService.GetUserId()).FirstName;
                    string lastName = _contactEnterpriseRepository.GetById(_httpContextService.GetUserId()).LastName;
                    string message = String.Format(CoordinatorToContactEnterprise.StageAgreementSignedMessage, firstName, lastName, stageName, stageAgreement.Id);
                    _notificationService.SendNotificationToAllCoordinator(
                    CoordinatorToContactEnterprise.StageAgreementSignedTitle, message);
                    _notificationService.SendNotificationTo(stageAgreement.IdStudentSigned,
                    CoordinatorToContactEnterprise.StageAgreementSignedTitle, message);
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

        [Authorize()]
        public virtual ActionResult List()
        {
            var stageAgreements = _stageAgreementRepository.GetAll().ToList();
            var listStageAgreement = new ListStageAgreement();
            var userId = _httpContextService.GetUserId();
            var account = _accountRepository.GetById(userId);
            List<StageAgreement> listStageAgreementsNotSigned;
            List<StageAgreement> listStageAgreementsSigned;


            if (account.Roles.First().RoleName == RoleName.Coordinator)
            {
                listStageAgreementsNotSigned =
                    stageAgreements.Where(agreementNotSigned => agreementNotSigned.CoordinatorHasSigned == false)
                        .ToList();
                listStageAgreementsSigned =
                    stageAgreements.Where(agreementSigned => agreementSigned.CoordinatorHasSigned == true).ToList();
            }
            else if (account.Roles.First().RoleName == RoleName.ContactEnterprise)
            {
                var contactEnteprise = _contactEnterpriseRepository.GetById(userId);
                List<StageAgreement> listStageAgreementsEnterprise = new List<StageAgreement>();
                foreach (var stageAgreement in stageAgreements)
                {
                    var stage = _stageRepository.GetById(stageAgreement.IdStage);
                    if (stage.CompanyName == contactEnteprise.EnterpriseName && stageAgreement.IdStage == stage.Id)
                    {
                        listStageAgreementsEnterprise.Add(stageAgreement);
                    }

                }
                listStageAgreementsNotSigned =
                    listStageAgreementsEnterprise.Where(agreementNotSigned => agreementNotSigned.ContactEnterpriseHasSigned == false)
                        .ToList();
                listStageAgreementsSigned =
                    listStageAgreementsEnterprise.Where(agreementSigned => agreementSigned.ContactEnterpriseHasSigned == true).ToList();
            }
            else
            {
                listStageAgreementsNotSigned =
                    stageAgreements.Where(agreementNotSigned => agreementNotSigned.StudentHasSigned == false && agreementNotSigned.IdStudentSigned == userId)
                        .ToList();
                listStageAgreementsSigned =
                    stageAgreements.Where(agreementNotSigned => agreementNotSigned.StudentHasSigned == true).ToList();
            }

            listStageAgreement.ListStageAgreementNotSigned =
                Mapper.Map<IEnumerable<StageAgreementDetail>>(listStageAgreementsNotSigned).ToList();
            listStageAgreement.ListStagesAgreementsSigned =
                Mapper.Map<IEnumerable<StageAgreementDetail>>(listStageAgreementsSigned).ToList();

            int count = 0;
            foreach (var stageAgreementNotSigned in listStageAgreement.ListStageAgreementNotSigned)
            {

                stageAgreementNotSigned.EnterpriseName =
                    _stageRepository.GetById(listStageAgreementsNotSigned[count].IdStage).CompanyName;
                stageAgreementNotSigned.StageName = _stageRepository.GetById(listStageAgreementsNotSigned[count].IdStage).StageTitle;
                stageAgreementNotSigned.StudentFirstName = _accountRepository.GetById(listStageAgreementsNotSigned[count].IdStudentSigned).FirstName;
                stageAgreementNotSigned.StudentLastName = _accountRepository.GetById(listStageAgreementsNotSigned[count].IdStudentSigned).LastName;
                count = count + 1;
            }

            foreach (var stageAgreementSigned in listStageAgreement.ListStagesAgreementsSigned)
            {
                count = 0;
                stageAgreementSigned.EnterpriseName =
                    _stageRepository.GetById(listStageAgreementsSigned[count].IdStage).CompanyName;
                stageAgreementSigned.StageName = _stageRepository.GetById(listStageAgreementsSigned[count].IdStage).StageTitle;
                stageAgreementSigned.StudentFirstName = _accountRepository.GetById(listStageAgreementsSigned[count].IdStudentSigned).FirstName;
                stageAgreementSigned.StudentLastName = _accountRepository.GetById(listStageAgreementsSigned[count].IdStudentSigned).LastName;
                count = count + 1;
            }

            return View(listStageAgreement);
        }
    }
}