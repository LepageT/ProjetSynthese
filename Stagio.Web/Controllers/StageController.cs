using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;
using Stagio.Web.ViewModels.Stage;

namespace Stagio.Web.Controllers
{
    public partial class StageController : Controller
    {
        private readonly IEntityRepository<Stage> _stageRepository;

        public StageController(IEntityRepository<Stage> stageRepository)
        {
            _stageRepository = stageRepository;
        }

        public virtual ActionResult ListNewStages()
        {
            var stages = _stageRepository.GetAll();
            var stagesNotAcceptedByCoordinator = stages.Where(stage => stage.Status == 0).ToList();

            var stagesViewModels = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesNotAcceptedByCoordinator);

            return View(stagesViewModels);
        }

        public virtual ActionResult ViewStageInfo(int id)
        {
            var stage = _stageRepository.GetById(id);

            if (stage != null)
            {
                var stageInfoViewModel = Mapper.Map<ViewModels.Stage.ViewInfo>(stage);

                return View(stageInfoViewModel);
            }
            return HttpNotFound();
        }

        public virtual ActionResult Details(int id)
        {
            var stage = _stageRepository.GetById(id);

            var details = Mapper.Map<Details>(stage);
            
            return View(details);
        }

        [HttpPost]
        public virtual ActionResult Details(string command, int id)
        {
            var stage = _stageRepository.GetById(id);

            if (command.Equals("Accepter"))
            {
                stage.Status = 1; //1 = Accepter;
            }
            else if (command.Equals("Refuser"))
            {
                stage.Status = 2; //2 = Refuser;
            }

            _stageRepository.Update(stage);

            return RedirectToAction(MVC.Stage.ListNewStages());
        }

    }
}