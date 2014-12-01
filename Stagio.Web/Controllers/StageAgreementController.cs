using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.StageAgreement;

namespace Stagio.Web.Controllers
{
    public partial class StageAgreementController : Controller
    {
        private readonly IEntityRepository<StageAgreement> _stageAgreementRepository;
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Student> _studentRepository; 


        public StageAgreementController(IEntityRepository<StageAgreement> stageAgreement, IEntityRepository<Apply> applyRepository, IEntityRepository<Stage> stageRepository, IEntityRepository<Student> studentRepository)
        {
            _stageAgreementRepository = stageAgreement;
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _studentRepository = studentRepository;
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

            var listStageAgreementsNotSigned = stageAgreements.Where(agreementNotSigned => agreementNotSigned.CoordinatorHasSigned == false).ToList();
            var listStageAgreementsSigned = stageAgreements.Where(agreementSigned => agreementSigned.CoordinatorHasSigned == true).ToList();

            listStageAgreement.ListStageAgreementNotSigned =
                Mapper.Map<IEnumerable<StageAgreementDetail>>(listStageAgreementsNotSigned).ToList();
            listStageAgreement.ListStagesAgreementsSigned =
                Mapper.Map<IEnumerable<StageAgreementDetail>>(listStageAgreementsSigned).ToList();

            foreach (var stageAgreementNotSigned in listStageAgreement.ListStageAgreementNotSigned)
            {
                foreach (var stageAgreement in listStageAgreementsNotSigned)
                {
                    stageAgreementNotSigned.EnterpriseName =
                        _stageRepository.GetById(stageAgreement.IdStage).CompanyName;
                    stageAgreementNotSigned.StageName = _stageRepository.GetById(stageAgreement.IdStage).StageTitle;
                    stageAgreementNotSigned.StudentFirstName = _studentRepository.GetById(stageAgreement.IdStudentSigned).FirstName;
                    stageAgreementNotSigned.StudentLastName = _studentRepository.GetById(stageAgreement.IdStudentSigned).LastName;
                }
            }

            foreach (var stageAgreementSigned in listStageAgreement.ListStagesAgreementsSigned)
            {
                foreach (var stageAgreement in listStageAgreementsSigned)
                {
                    stageAgreementSigned.EnterpriseName =
                        _stageRepository.GetById(stageAgreement.IdStage).CompanyName;
                    stageAgreementSigned.StageName = _stageRepository.GetById(stageAgreement.IdStage).StageTitle;
                    stageAgreementSigned.StudentFirstName = _studentRepository.GetById(stageAgreement.IdStudentSigned).FirstName;
                    stageAgreementSigned.StudentLastName = _studentRepository.GetById(stageAgreement.IdStudentSigned).LastName;
                }
            }

            return View(listStageAgreement);
        }
    }
}