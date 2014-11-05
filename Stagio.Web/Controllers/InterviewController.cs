using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class InterviewController : Controller
    {
        private readonly IEntityRepository<Stagio.Domain.Entities.Apply> _applyRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Interview> _interviewRepository; 
        private readonly IHttpContextService _httpContextService;

        public InterviewController(IEntityRepository<Stagio.Domain.Entities.Apply> applyRepository, IEntityRepository<Stage> stageRepository, IHttpContextService httpContextService, IEntityRepository<Interview> interviewRepository )
        {
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _httpContextService = httpContextService;
            _interviewRepository = interviewRepository;

        }
        // GET: Interview
        public virtual ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult Create()
        {
            var interview = new ViewModels.Interviews.Create();
            var userId = _httpContextService.GetUserId();
            var applies = _applyRepository.GetAll().Where(x => x.IdStudent == userId).ToList();

            interview.Apply = from apply in applies
                select new SelectListItem
                {
                    Text = _stageRepository.GetById(apply.IdStage).StageTitle.ToString(),
                    Value = ((int)apply.IdStage).ToString()
                };
            

            return View(interview);
        }

        [Authorize(Roles = RoleName.Student)]
        [HttpPost]
        public virtual ActionResult Create(ViewModels.Interviews.Create createdInterview)
        {
            if (ModelState.IsValid)
            {
                var interview = Mapper.Map<Interview>(createdInterview);

                _interviewRepository.Add(interview);

                return RedirectToAction(MVC.Interview.InterviewConfirmation());
            }

            return View(createdInterview);
        }

        public virtual ActionResult InterviewConfirmation()
        {
            return View();
        }
    }
}