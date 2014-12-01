using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using AutoMapper;
using Microsoft.AspNet.Identity;
using NSubstitute;
using Stagio.Domain.Application;
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
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<ApplicationUser> _accountRepository;
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository; 


        public StageAgreementController(IEntityRepository<StageAgreement> stageAgreement, IEntityRepository<Apply> applyRepository, IEntityRepository<Stage> stageRepository, IEntityRepository<Student> studentRepository, IHttpContextService httpContextService, IEntityRepository<ApplicationUser> accountRepository, IEntityRepository<ContactEnterprise> contactEnterpriseRepository)
        {
            _stageAgreementRepository = stageAgreement;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _studentRepository = studentRepository;
            _httpContextService = httpContextService;
            _accountRepository = accountRepository;
            _contactEnterpriseRepository = contactEnterpriseRepository;
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult CreateConfirmation(int idApply)
        {
            var apply = _applyRepository.GetById(idApply);
            var stageAgreement = new StageAgreement();
            stageAgreement.IdStage = apply.IdStage;
            stageAgreement.IdStudentSigned = apply.IdStudent;
            _stageAgreementRepository.Add(stageAgreement);

            return View();
        }

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
                    if (stage.CompanyName == contactEnteprise.EnterpriseName)
                    {
                        var stageAgreementsEnterprise = stageAgreements.Where(stageAgreementId => stageAgreementId.IdStage == stage.Id);
                        listStageAgreementsEnterprise.Add(stageAgreementsEnterprise.First());
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
                stageAgreementNotSigned.StudentFirstName = _studentRepository.GetById(listStageAgreementsNotSigned[count].IdStudentSigned).FirstName;
                stageAgreementNotSigned.StudentLastName = _studentRepository.GetById(listStageAgreementsNotSigned[count].IdStudentSigned).LastName;
                count = count + 1;
            }

            foreach (var stageAgreementSigned in listStageAgreement.ListStagesAgreementsSigned)
            {
                count = 0;
                stageAgreementSigned.EnterpriseName =
                    _stageRepository.GetById(listStageAgreementsSigned[count].IdStage).CompanyName;
                stageAgreementSigned.StageName = _stageRepository.GetById(listStageAgreementsSigned[count].IdStage).StageTitle;
                stageAgreementSigned.StudentFirstName = _studentRepository.GetById(listStageAgreementsSigned[count].IdStudentSigned).FirstName;
                stageAgreementSigned.StudentLastName = _studentRepository.GetById(listStageAgreementsSigned[count].IdStudentSigned).LastName;
                count = count + 1;
            }

            return View(listStageAgreement);
        }
    }
}