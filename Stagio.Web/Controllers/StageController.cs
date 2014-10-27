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
		    var listAllStages = new ListAllStages();
			var stagesNotAcceptedByCoordinator = stages.Where(stage => stage.AcceptedByCoordinator == 0).ToList();
            var stagesAcceptedByCoordinator = stages.Where(stage => stage.AcceptedByCoordinator == 1).ToList();
            var stagesRefusedByCoordinator = stages.Where(stage => stage.AcceptedByCoordinator == 2).ToList();

			listAllStages.ListNewStages = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesNotAcceptedByCoordinator).ToList();
            listAllStages.ListStagesAccepted = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesAcceptedByCoordinator).ToList();
            listAllStages.ListStagesRefused = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesRefusedByCoordinator).ToList();


			return View(listAllStages);
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

        [HttpPost, ActionName("Details")]
        public virtual ActionResult DetailsPost(string button)
        {

            string allo = " ";
           // var stage = _stageRepository.GetById(id);

           // var details = Mapper.Map<Details>(stage);

            return View();
        }

	}
}