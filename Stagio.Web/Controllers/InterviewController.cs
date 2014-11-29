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
using Stagio.Web.Module.Strings.Notification;
using Stagio.Web.Services;

namespace Stagio.Web.Controllers
{
    public partial class InterviewController : Controller
    {
        private readonly IEntityRepository<Stagio.Domain.Entities.Apply> _applyRepository;
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IEntityRepository<Student> _studentRepository;
        private readonly IEntityRepository<Interview> _interviewRepository; 
        private readonly IHttpContextService _httpContextService;
        private readonly IEntityRepository<ApplicationUser> _applicationUserRepository;
        private readonly IEntityRepository<Notification> _notificationRepository;
        private readonly INotificationService _notificationService;

        public InterviewController(IEntityRepository<Stagio.Domain.Entities.Apply> applyRepository, IEntityRepository<Stage> stageRepository, IHttpContextService httpContextService, IEntityRepository<Interview> interviewRepository, IEntityRepository<Student> studentRepository, IEntityRepository<Notification> notificationRepository, IEntityRepository<ApplicationUser> applicationUserRepository)
        {
            _applyRepository = applyRepository;
            _stageRepository = stageRepository;
            _httpContextService = httpContextService;
            _interviewRepository = interviewRepository;
            _studentRepository = studentRepository;
            _notificationRepository = notificationRepository;
            _applicationUserRepository = applicationUserRepository;
            _notificationService = new NotificationService(applicationUserRepository, notificationRepository);


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
                string message = student.FirstName + " " + student.LastName + " " +
                                     StudentToCoordinator.CreateInterviewPart1 + " " + interviewCreated.Date + " " + StudentToCoordinator.CreateInterviewPart2 + " " + stage.CompanyName ;
                _notificationService.SendNotificationToAllCoordinator(
                    StudentToCoordinator.CreateInterviewTitle, message);
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
               
                if (editInterviewViewModel.Present && !interview.Present)
                {
                    var student = _studentRepository.GetById(interview.StudentId);
                    var stage = _stageRepository.GetById(interview.StageId);
                    string message = student.FirstName + " " + student.LastName + " " +
                                     StudentToCoordinator.EditInterviewMessage + " " + stage.CompanyName + " le  " + interview.Date;
                    _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.EditInterviewTitle,
                        message);
                }
                if (editInterviewViewModel.Date != interview.Date)
                {
                    var student = _studentRepository.GetById(interview.StudentId);
                    var stage = _stageRepository.GetById(interview.StageId);
                    string message = StudentToCoordinator.EditDateInterviewMessagePart1 + " " + student.FirstName + " " + student.LastName + " " +
                                     StudentToCoordinator.EditDateInterviewMessagePart2 + " " + editInterviewViewModel.Date + " pour le stage " + stage.StageTitle + " de " + stage.CompanyName;
                    _notificationService.SendNotificationToAllCoordinator(StudentToCoordinator.EditDateInterviewTitle,
                        message);
                }

                Mapper.Map(editInterviewViewModel, interview);

                _interviewRepository.Update(interview);
                return RedirectToAction(MVC.Interview.List());
            }
            return HttpNotFound();
        }

    }
}