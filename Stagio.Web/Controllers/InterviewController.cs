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

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult Create()
        {
            var interview = new ViewModels.Interviews.Create();
            var userId = _httpContextService.GetUserId();

            
            var applies = _applyRepository.GetAll().Where(x => x.IdStudent == userId).ToList();

            interview.Apply = from apply in applies
                select new SelectListItem
                {
                    Text = _stageRepository.GetById(apply.IdStage).StageTitle.ToString() + " - " + _stageRepository.GetById(apply.IdStage).CompanyName.ToString(),
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
                createdInterview.StudentId = _httpContextService.GetUserId();
                var interviewCreated = Mapper.Map<Interview>(createdInterview);

                var interviews = _interviewRepository.GetAll().ToList();
                foreach (var interview in interviews)
                {
                    if (interview.StudentId == createdInterview.StudentId &&
                        interview.StageId == createdInterview.StageId)
                    {
                        ViewBag.Message = "Vous avez déjà inscrit une date d'entrevue pour ce stage.";
                        var applies = _applyRepository.GetAll().Where(x => x.IdStudent == createdInterview.StudentId).ToList();

                        createdInterview.Apply = from apply in applies
                                          select new SelectListItem
                                          {
                                              Text = _stageRepository.GetById(apply.IdStage).StageTitle.ToString() + " - " + _stageRepository.GetById(apply.IdStage).CompanyName.ToString(),
                                              Value = ((int)apply.IdStage).ToString()
                                          };
                        return View(createdInterview);
                    }
                }

                _interviewRepository.Add(interviewCreated);

                return RedirectToAction(MVC.Interview.InterviewCreateConfirmation());
            }

            return View(createdInterview);
        }

        public virtual ActionResult InterviewCreateConfirmation()
        {
            return View();
        }

        [Authorize(Roles = RoleName.Student)]
        public virtual ActionResult List()
        {
            var userId = _httpContextService.GetUserId();
            var interviews = _interviewRepository.GetAll().Where(x => x.StudentId == userId).ToList();

            var interviewsList = Mapper.Map<IEnumerable<ViewModels.Interviews.List>>(interviews).ToList();

            foreach (var interview in interviewsList)
            {
                var stages = _stageRepository.GetAll();
                foreach (var stage in stages)
                {
                    if (stage.Id == interview.StageId)
                    {
                        interview.StageTitleAndCompagny = stage.StageTitle.ToString() + " - " +
                                             stage.CompanyName.ToString();
                    }
                }
                
            }

            return View(interviewsList);
        }


        [Authorize(Roles = RoleName.Student)]

        public virtual ActionResult Edit(int id)
        {
            var interview = _interviewRepository.GetById(id);
            if (ModelState.IsValid)
            {
            if (interview != null)
            {
                var interviewEditPageViewModel = Mapper.Map<ViewModels.Interviews.Edit>(interview);
                var stages = _stageRepository.GetAll();
                foreach (var stage in stages)
                {
                    if (stage.Id == interview.StageId)
                    {
                        interviewEditPageViewModel.StageTitleAndCompagny = stage.StageTitle.ToString() + " - " +
                                             stage.CompanyName.ToString();
                    }
                }
                return View(interviewEditPageViewModel);
            }
            }
            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult Edit(ViewModels.Interviews.Edit editInterviewViewModel)
        {
            var interview = _interviewRepository.GetById(editInterviewViewModel.Id);
            if (interview != null)
            {
                Mapper.Map(editInterviewViewModel, interview);

                _interviewRepository.Update(interview);

                return RedirectToAction(MVC.Interview.List());
            }
            return HttpNotFound();

           
        }

    }
}