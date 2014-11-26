using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;

namespace Stagio.Web.Controllers
{
    public partial class StageAgreementController : Controller
    {
        private readonly IEntityRepository<StageAgreement> _stageAgreementRepository;
        private readonly IEntityRepository<Apply> _applyRepository;


        public StageAgreementController(IEntityRepository<StageAgreement> stageAgreement, IEntityRepository<Apply> applyRepository)
        {
            _stageAgreementRepository = stageAgreement;
            _applyRepository = applyRepository;
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
    }
}