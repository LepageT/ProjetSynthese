using System.Web.Mvc;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class StageAgreementController : Controller
    {
        private readonly IEntityRepository<StageAgreement> _stageAgreementRepository;
        private readonly IEntityRepository<Apply> _applyRepository;
        private readonly IHttpContextService _httpContextService;


        public StageAgreementController(IEntityRepository<StageAgreement> stageAgreement, IEntityRepository<Apply> applyRepository, IHttpContextService httpContextService)
        {
            _httpContextService = httpContextService;
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
            stageAgreement.IdCoordinatorSigned = _httpContextService.GetUserId();
            _stageAgreementRepository.Add(stageAgreement);

            return View();
        }



    }
}