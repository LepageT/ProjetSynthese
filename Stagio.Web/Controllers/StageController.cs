﻿using System;
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
		// private readonly IEntityRepository<Activation> _activationRepository;

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
	}
}