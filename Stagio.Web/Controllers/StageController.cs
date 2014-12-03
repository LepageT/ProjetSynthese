using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module;
using Stagio.Web.Module.Strings.Notification;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Stage;

namespace Stagio.Web.Controllers
{
    public partial class StageController : Controller
    {
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly IHttpContextService _httpContext;
        private readonly INotificationService _notificationService;
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository; 

        public StageController(IEntityRepository<Stage> stageRepository, IHttpContextService httpContextService, IEntityRepository<ContactEnterprise> contactEnterpriseRepository, INotificationService notificationService )
        {
            _stageRepository = stageRepository;
            _httpContext = httpContextService;
            _contactEnterpriseRepository = contactEnterpriseRepository;
            _notificationService = notificationService;
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult ListNewStages()
        {
            var stages = _stageRepository.GetAll();
            var listAllStages = new ListAllStages();
            var stagesNotStatus = stages.Where(stage => stage.Status == 0).ToList();
            var stagesStatus = stages.Where(stage => stage.Status == StageStatus.Accepted).ToList();
            var stagesRefusedByCoordinator = stages.Where(stage => stage.Status == StageStatus.Refused).ToList();
            var stagesRemoveByContact = stages.Where(stage => stage.Status == StageStatus.Removed).ToList();

            listAllStages.ListNewStages = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesNotStatus).ToList();
            listAllStages.ListStagesAccepted = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesStatus).ToList();
            listAllStages.ListStagesRefused = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesRefusedByCoordinator).ToList();
            listAllStages.ListStagesRemoved = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesRemoveByContact).ToList();

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

        [HttpPost]
        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult Details(string command, int id)
        {
            var stage = _stageRepository.GetById(id);


            if (stage == null)
            {
                return View();
            }

            

            if (command.Equals("Accepter"))
            {
                stage.Status = StageStatus.Accepted;
                var contactsEnterprise = _contactEnterpriseRepository.GetAll().ToList();

                _notificationService.SendNotificationToAllContactEnterpriseOf(stage.CompanyName, CoordinatorToContactEnterprise.StageAcceptedTitle, CoordinatorToContactEnterprise.StageAcceptedMessage);
                string messageToStudent = String.Format(ContactEnterpriseToStudent.NewStageMessage, stage.CompanyName, stage.Id, stage.StageTitle);
                _notificationService.SendNotificationToAllStudent(ContactEnterpriseToStudent.NewStageTitle, messageToStudent);
            }
            else if (command.Equals("Refuser"))
            {
                _notificationService.SendNotificationToAllContactEnterpriseOf(stage.CompanyName,
                    CoordinatorToContactEnterprise.StageRefusedTitle, CoordinatorToContactEnterprise.StageRefusedMessage);
                stage.Status = StageStatus.Refused;
            }
            else if (command.Equals("Retirer"))
            {
                stage.Status = StageStatus.Refused;
            }
            _stageRepository.Update(stage);
            return RedirectToAction(MVC.Stage.ListNewStages());
        }

        [Authorize(Roles = RoleName.ContactEnterprise)]
        public virtual ActionResult Edit(int id)
        {
            var stage = _stageRepository.GetById(id);

            if (stage != null)
            {
                var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());

                if (stage.CompanyName != user.EnterpriseName)
                {
                    this.Flash("Impossible de modifier le stage", FlashEnum.Error);
                    return RedirectToAction(MVC.ContactEnterprise.ListStage());
                }
                var stageEditPageViewModel = Mapper.Map<ViewModels.Stage.Edit>(stage);
                return View(stageEditPageViewModel);
            }
            return HttpNotFound();
        }


        [Authorize(Roles = RoleName.ContactEnterprise)]
        // POST: Student/Edit/5
        [HttpPost]
        public virtual ActionResult Edit(ViewModels.Stage.Edit editStageViewModel)
        {
            var stage = _stageRepository.GetById(editStageViewModel.Id);
            var user = _contactEnterpriseRepository.GetById(_httpContext.GetUserId());
            
            
            if (stage == null)
            {
                return HttpNotFound();
            }

            if (stage.CompanyName != user.EnterpriseName)
            {
                this.Flash("Impossible de modifier le stage", FlashEnum.Error);
                return RedirectToAction(MVC.ContactEnterprise.ListStage());
            }

            if (!ModelState.IsValid)
            {
                return View(editStageViewModel);
            }
        
            Mapper.Map(editStageViewModel, stage);

           _stageRepository.Update(stage);

                string message = "L'entreprise " + " " + stage.CompanyName + " " +
                                 ContactEntrepriseToCoordinator.EditStageMessage +
                                 ContactEntrepriseToCoordinator.NewStageLink + editStageViewModel.Id + '"'+ "> " + stage.StageTitle + " " +
                                 ContactEntrepriseToCoordinator.NewStageEndLink;
                _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.EditStageTitle,
                    message);
                string messageToStudent = stage.CompanyName + ContactEnterpriseToStudent.EditStageMessage +
                                          ContactEntrepriseToCoordinator.NewStageLink + editStageViewModel.Id + '"' + "> " + stage.StageTitle + " " +
                                 ContactEntrepriseToCoordinator.NewStageEndLink;
            _notificationService.SendNotificationToAllStudent(ContactEnterpriseToStudent.EditStageTitle,
                messageToStudent);

            this.Flash("Modification réussi", FlashEnum.Success);
            return RedirectToAction(MVC.ContactEnterprise.ListStage());
         
        }
                
        [Authorize(Roles = RoleName.ContactEnterprise)]
        public virtual ActionResult DraftEdit(int id)
        {
            var stage = _stageRepository.GetById(id);

            if (stage != null)
            {
                var stageDraftPageViewModel = Mapper.Map<ViewModels.Stage.Edit>(stage);

                return View(stageDraftPageViewModel);
            }
            return HttpNotFound();
        }
               
        [Authorize(Roles = RoleName.ContactEnterprise)]
        [HttpPost]
        public virtual ActionResult DraftEdit(ViewModels.Stage.Edit draftStageViewModel, string buttonClick = "")
        {
            if (buttonClick.Equals("Enregistrer"))
            {
                var stage = _stageRepository.GetById(draftStageViewModel.Id);
                if (stage == null)
                {
                    return HttpNotFound();
                }

                Mapper.Map(draftStageViewModel, stage);

                _stageRepository.Update(stage);

                return RedirectToAction(MVC.ContactEnterprise.DraftList());

            }
            else
            {
                if (!ModelState.IsValid)
                {
                    return View(draftStageViewModel);
                }

                var stage = Mapper.Map<Stage>(draftStageViewModel);
                stage.PublicationDate = DateTime.Now.ToString();
                stage.Status = StageStatus.New;

                _stageRepository.Update(stage);
                string message = "L'entreprise " + stage.CompanyName + " " + ContactEntrepriseToCoordinator.NewStageMessage + " " + ContactEntrepriseToCoordinator.NewStageLink + stage.Id.ToString() + '"' + ContactEntrepriseToCoordinator.NewStageEndLink;
                _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.NewStageTitle, message);

                return RedirectToAction(MVC.ContactEnterprise.CreateStageSucceed());
            }
        }

        public virtual ActionResult DraftDelete(int id)
        {
            var stage = _stageRepository.GetById(id);
            if (stage == null)
            {
                return HttpNotFound();
            }

            _stageRepository.Delete(stage);

            return RedirectToAction(MVC.ContactEnterprise.DraftList());
        }
    }
}