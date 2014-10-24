using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Entities;

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
			var stagesNotAcceptedByCoordinator = stages.Where(stage => !stage.AcceptedByCoordinator).ToList();

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
	}
}