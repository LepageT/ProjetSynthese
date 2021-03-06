﻿using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Notification;
using Stagio.Web.Module.Strings.Shared;
using Stagio.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Stagio.Web.Controllers
{
    public partial class InterviewController : Controller
    {
        private readonly IEntityRepository<Stagio.Domain.Entities.Apply> _applyRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Interview> _interviewRepository; 
        private readonly IHttpContextService _httpContextService;
        private readonly INotificationService _notificationService;

        public InterviewController(IEntityRepository<Stagio.Domain.Entities.Apply> applyRepository, IEntityRepository<Stage> stageRepository, IHttpContextService httpContextService, IEntityRepository<Interview> interviewRepository, IEntityRepository<Student> studentRepository, INotificationService notificationService)
        {
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _httpContextService = httpContextService;
            _interviewRepository = interviewRepository;
            _studentRepository = studentRepository;
            _notificationService = notificationService;

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
                    Text = _stageRepository.GetById(apply.IdStage).StageTitle + " - " + _stageRepository.GetById(apply.IdStage).CompanyName,
                    Value = apply.IdStage.ToString()
                };
            
            var applis = interview.Apply.ToList();

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
                var student = _studentRepository.GetById(interviewCreated.StudentId);
                var stage = _stageRepository.GetById(interviewCreated.StageId);
                var interviews = _interviewRepository.GetAll().ToList();
                foreach (var interview in interviews)
                {
                    if (interview.StudentId == createdInterview.StudentId &&
                        interview.StageId == createdInterview.StageId)
                    {
                        this.Flash(FlashMessageResources.InterviewDateAlreadyExist, FlashEnum.Warning);
                        var applies = _applyRepository.GetAll().Where(x => x.IdStudent == createdInterview.StudentId).ToList();

                        createdInterview.Apply = from apply in applies
                                          select new SelectListItem
                                          {
                                              Text = _stageRepository.GetById(apply.IdStage).StageTitle + " - " + _stageRepository.GetById(apply.IdStage).CompanyName,
                                              Value = apply.IdStage.ToString()
                                          };
                        return View(createdInterview);
                    }
                }
                string message = String.Format(StudentToCoordinator.CreateInterview, student.FirstName, student.LastName, interviewCreated.Date, stage.CompanyName);
                _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.CreateInterviewTitle, message);
                _interviewRepository.Add(interviewCreated);
                this.Flash(FlashMessageResources.AddSuccess, FlashEnum.Success);

                return RedirectToAction(MVC.Interview.InterviewCreateConfirmation());
            }
            this.Flash(FlashMessageResources.ErrorsOnPage, FlashEnum.Error);

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
            if (interview == null)
            {
                this.Flash(FlashMessageResources.InterviewNotExist, FlashEnum.Warning);
                return RedirectToAction(MVC.Interview.List());
            }
            var student = _studentRepository.GetById(_httpContextService.GetUserId());
         
            if (interview.StudentId != student.Id )
            {
                this.Flash(FlashMessageResources.NotAccessInterview, FlashEnum.Warning);
                return RedirectToAction(MVC.Interview.List());
            }
            if (ModelState.IsValid && interview != null)
            {
                
                    var interviewEditPageViewModel = Mapper.Map<ViewModels.Interviews.Edit>(interview);
                    if (student.hadStage)
                    {
                        interviewEditPageViewModel.hadStage = true;
                        if(interview.DateAcceptOffer != null)
                        {
                            interviewEditPageViewModel.IdStageAcceptedByStudent = interview.StageId;
                        }
                    }
                    var stages = _stageRepository.GetAll();
                    foreach (var stage in stages)
                    {
                        if (stage.Id == interview.StageId)
                        {
                            interviewEditPageViewModel.StageTitleAndCompagny = stage.StageTitle + " - " + stage.CompanyName;
                        }
                    }
                    return View(interviewEditPageViewModel);
                }
            
            return HttpNotFound();
        }

        [HttpPost]
        public virtual ActionResult Edit(ViewModels.Interviews.Edit editInterviewViewModel)
        {
            var interview = _interviewRepository.GetById(editInterviewViewModel.Id);
          
            if (interview != null)
            {
                var student = _studentRepository.GetById(interview.StudentId);
                if (editInterviewViewModel.Present && !interview.Present)
                {
                   
                    var stage = _stageRepository.GetById(interview.StageId);
                    string message = String.Format(StudentToCoordinator.EditInterviewMessage, student.FirstName, student.LastName, stage.CompanyName, interview.Date);
                    _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.EditInterviewTitle,
                        message);
                }
                if (editInterviewViewModel.Date != interview.Date)
                {
                    var stage = _stageRepository.GetById(interview.StageId);
                    string message  = String.Format(StudentToCoordinator.EditDateInterviewMessage, student.FirstName,
                        student.LastName, editInterviewViewModel.Date, stage.StageTitle, stage.CompanyName);

                    _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.EditDateInterviewTitle,
                        message);
                }

                if(editInterviewViewModel.DateAcceptOffer != null)
                {
                    student.hadStage = true;
                }
                else
                {
                    student.hadStage = false;
                }

                Mapper.Map(editInterviewViewModel, interview);
                _studentRepository.Update(student);
                _interviewRepository.Update(interview);
                this.Flash(FlashMessageResources.EditSuccess, FlashEnum.Success);
                return RedirectToAction(MVC.Interview.List());
            }
            return HttpNotFound();
        }

    }
}