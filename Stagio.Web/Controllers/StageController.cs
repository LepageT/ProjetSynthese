using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using Stagio.DataLayer;
using Stagio.Domain.Application;
using Stagio.Domain.Entities;
using Stagio.Web.Module.Strings.Notification;
using Stagio.Web.Services;
using Stagio.Web.ViewModels.Stage;

namespace Stagio.Web.Controllers
{
    public partial class StageController : Controller
    {
        private readonly IEntityRepository<Stage> _stageRepository;
        private readonly INotificationService _notificationService;
        private readonly IEntityRepository<ContactEnterprise> _contactEnterpriseRepository; 

        public StageController(IEntityRepository<Stage> stageRepository, INotificationService notificationService, IEntityRepository<ContactEnterprise> contactEnterpriseRepository)
        {
            _stageRepository = stageRepository;
            _notificationService = notificationService;
            _contactEnterpriseRepository = contactEnterpriseRepository;
        }

        [Authorize(Roles = RoleName.Coordinator)]
        public virtual ActionResult ListNewStages()
        {
            var stages = _stageRepository.GetAll();
            var listAllStages = new ListAllStages();
            var stagesNotStatus = stages.Where(stage => stage.Status == 0).ToList();
            var stagesStatus = stages.Where(stage => stage.Status == StageStatus.Accepted).ToList();
            var stagesRefusedByCoordinator = stages.Where(stage => stage.Status == StageStatus.Refused).ToList();

            listAllStages.ListNewStages = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesNotStatus).ToList();
            listAllStages.ListStagesAccepted = Mapper.Map<IEnumerable<ViewModels.Stage.ListNewStages>>(stagesStatus).ToList();
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

        [HttpPost]
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
                foreach (var contactEnterprise in contactsEnterprise)
                {
                    if (contactEnterprise.EnterpriseName == stage.CompanyName)
                    {
                        _notificationService.SendNotificationTo(contactEnterprise.Id, CoordinatorToContactEnterprise.StageAcceptedTitle, CoordinatorToContactEnterprise.StageAcceptedMessage);

                    }
                }
            }
            else if (command.Equals("Refuser"))
            {
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
        // GET: Student/Edit/5
        public virtual ActionResult Edit(int id)
        {
            var stage = _stageRepository.GetById(id);

            if (stage != null)
            {
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
            if (stage == null)
            {
                return HttpNotFound();
            }

            if (!ModelState.IsValid)
            {
                return View(editStageViewModel);
            }
        
            Mapper.Map(editStageViewModel, stage);

           _stageRepository.Update(stage);

           string message = "L'entreprise " +  " "+ stage.CompanyName +  " " + ContactEntrepriseToCoordinator.EditStageMessage + " " + stage.StageTitle + " " + ContactEntrepriseToCoordinator.NewStageLink + editStageViewModel.Id + '"' + ContactEntrepriseToCoordinator.NewStageEndLink;
           _notificationService.SendNotificationToAllCoordinator(ContactEntrepriseToCoordinator.EditStageTitle, message);

            return RedirectToAction(MVC.ContactEnterprise.ListStage());
        }
    }
}