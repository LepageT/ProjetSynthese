// <auto-generated />
// This file was generated by a T4 template.
// Don't change it directly as your change would get overwritten.  Instead, make changes
// to the .tt file (i.e. the T4 template) and save it to regenerate this file.

// Make sure the compiler doesn't complain about missing Xml comments and CLS compliance
#pragma warning disable 1591, 3008, 3009
#region T4MVC

using System;
using System.Diagnostics;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using System.Web.Mvc.Html;
using System.Web.Routing;
using T4MVC;
namespace Stagio.Web.Controllers
{
    public partial class ContactEnterpriseController
    {
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected ContactEnterpriseController(Dummy d) { }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoute(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToAction(Task<ActionResult> taskResult)
        {
            return RedirectToAction(taskResult.Result);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(ActionResult result)
        {
            var callInfo = result.GetT4MVCResult();
            return RedirectToRoutePermanent(callInfo.RouteValueDictionary);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        protected RedirectToRouteResult RedirectToActionPermanent(Task<ActionResult> taskResult)
        {
            return RedirectToActionPermanent(taskResult.Result);
        }

        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Details()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Reactivate()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reactivate);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Edit()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
        }
        [NonAction]
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public virtual System.Web.Mvc.ActionResult Delete()
        {
            return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ContactEnterpriseController Actions { get { return MVC.ContactEnterprise; } }
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Area = "";
        [GeneratedCode("T4MVC", "2.0")]
        public readonly string Name = "ContactEnterprise";
        [GeneratedCode("T4MVC", "2.0")]
        public const string NameConst = "ContactEnterprise";

        static readonly ActionNamesClass s_actions = new ActionNamesClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionNamesClass ActionNames { get { return s_actions; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNamesClass
        {
            public readonly string Index = "Index";
            public readonly string Details = "Details";
            public readonly string Reactivate = "Reactivate";
            public readonly string CreateConfirmation = "CreateConfirmation";
            public readonly string Edit = "Edit";
            public readonly string Delete = "Delete";
            public readonly string CreateStage = "CreateStage";
            public readonly string CreateStageSucceed = "CreateStageSucceed";
            public readonly string InviteContactEnterprise = "InviteContactEnterprise";
            public readonly string ListStudentApply = "ListStudentApply";
            public readonly string ListStage = "ListStage";
        }

        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionNameConstants
        {
            public const string Index = "Index";
            public const string Details = "Details";
            public const string Reactivate = "Reactivate";
            public const string CreateConfirmation = "CreateConfirmation";
            public const string Edit = "Edit";
            public const string Delete = "Delete";
            public const string CreateStage = "CreateStage";
            public const string CreateStageSucceed = "CreateStageSucceed";
            public const string InviteContactEnterprise = "InviteContactEnterprise";
            public const string ListStudentApply = "ListStudentApply";
            public const string ListStage = "ListStage";
        }


        static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Details
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_Reactivate s_params_Reactivate = new ActionParamsClass_Reactivate();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Reactivate ReactivateParams { get { return s_params_Reactivate; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Reactivate
        {
            public readonly string email = "email";
            public readonly string firstName = "firstName";
            public readonly string lastName = "lastName";
            public readonly string enterpriseName = "enterpriseName";
            public readonly string telephone = "telephone";
            public readonly string poste = "poste";
            public readonly string createViewModel = "createViewModel";
        }
        static readonly ActionParamsClass_Edit s_params_Edit = new ActionParamsClass_Edit();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Edit EditParams { get { return s_params_Edit; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Edit
        {
            public readonly string id = "id";
            public readonly string collection = "collection";
        }
        static readonly ActionParamsClass_Delete s_params_Delete = new ActionParamsClass_Delete();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_Delete DeleteParams { get { return s_params_Delete; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_Delete
        {
            public readonly string id = "id";
            public readonly string collection = "collection";
        }
        static readonly ActionParamsClass_CreateStage s_params_CreateStage = new ActionParamsClass_CreateStage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_CreateStage CreateStageParams { get { return s_params_CreateStage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_CreateStage
        {
            public readonly string createdStage = "createdStage";
        }
        static readonly ActionParamsClass_InviteContactEnterprise s_params_InviteContactEnterprise = new ActionParamsClass_InviteContactEnterprise();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_InviteContactEnterprise InviteContactEnterpriseParams { get { return s_params_InviteContactEnterprise; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_InviteContactEnterprise
        {
            public readonly string createContactEnterpriseViewModel = "createContactEnterpriseViewModel";
        }
        static readonly ActionParamsClass_ListStudentApply s_params_ListStudentApply = new ActionParamsClass_ListStudentApply();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListStudentApply ListStudentApplyParams { get { return s_params_ListStudentApply; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListStudentApply
        {
            public readonly string id = "id";
        }
        static readonly ActionParamsClass_ListStage s_params_ListStage = new ActionParamsClass_ListStage();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ActionParamsClass_ListStage ListStageParams { get { return s_params_ListStage; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ActionParamsClass_ListStage
        {
            public readonly string id = "id";
        }
        static readonly ViewsClass s_views = new ViewsClass();
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public ViewsClass Views { get { return s_views; } }
        [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
        public class ViewsClass
        {
            static readonly _ViewNamesClass s_ViewNames = new _ViewNamesClass();
            public _ViewNamesClass ViewNames { get { return s_ViewNames; } }
            public class _ViewNamesClass
            {
                public readonly string CreateConfirmation = "CreateConfirmation";
                public readonly string CreateStage = "CreateStage";
                public readonly string CreateStageSucceed = "CreateStageSucceed";
                public readonly string InviteContactEnterprise = "InviteContactEnterprise";
                public readonly string ListStage = "ListStage";
                public readonly string ListStudentApply = "ListStudentApply";
                public readonly string Reactivate = "Reactivate";
            }
            public readonly string CreateConfirmation = "~/Views/ContactEnterprise/CreateConfirmation.cshtml";
            public readonly string CreateStage = "~/Views/ContactEnterprise/CreateStage.cshtml";
            public readonly string CreateStageSucceed = "~/Views/ContactEnterprise/CreateStageSucceed.cshtml";
            public readonly string InviteContactEnterprise = "~/Views/ContactEnterprise/InviteContactEnterprise.cshtml";
            public readonly string ListStage = "~/Views/ContactEnterprise/ListStage.cshtml";
            public readonly string ListStudentApply = "~/Views/ContactEnterprise/ListStudentApply.cshtml";
            public readonly string Reactivate = "~/Views/ContactEnterprise/Reactivate.cshtml";
        }
    }

    [GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
    public partial class T4MVC_ContactEnterpriseController : Stagio.Web.Controllers.ContactEnterpriseController
    {
        public T4MVC_ContactEnterpriseController() : base(Dummy.Instance) { }

        [NonAction]
        partial void IndexOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult Index()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Index);
            IndexOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void DetailsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Details(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Details);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DetailsOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ReactivateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string email, string firstName, string lastName, string enterpriseName, string telephone, int? poste);

        [NonAction]
        public override System.Web.Mvc.ActionResult Reactivate(string email, string firstName, string lastName, string enterpriseName, string telephone, int? poste)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reactivate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "email", email);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "firstName", firstName);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "lastName", lastName);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "enterpriseName", enterpriseName);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "telephone", telephone);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "poste", poste);
            ReactivateOverride(callInfo, email, firstName, lastName, enterpriseName, telephone, poste);
            return callInfo;
        }

        [NonAction]
        partial void ReactivateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.ContactEnterprise.Reactive createViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult Reactivate(Stagio.Web.ViewModels.ContactEnterprise.Reactive createViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reactivate);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createViewModel", createViewModel);
            ReactivateOverride(callInfo, createViewModel);
            return callInfo;
        }

        [NonAction]
        partial void CreateConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateConfirmation()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateConfirmation);
            CreateConfirmationOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            EditOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void EditOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, System.Web.Mvc.FormCollection collection);

        [NonAction]
        public override System.Web.Mvc.ActionResult Edit(int id, System.Web.Mvc.FormCollection collection)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Edit);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "collection", collection);
            EditOverride(callInfo, id, collection);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            DeleteOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void DeleteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, System.Web.Mvc.FormCollection collection);

        [NonAction]
        public override System.Web.Mvc.ActionResult Delete(int id, System.Web.Mvc.FormCollection collection)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Delete);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "collection", collection);
            DeleteOverride(callInfo, id, collection);
            return callInfo;
        }

        [NonAction]
        partial void CreateStageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateStage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateStage);
            CreateStageOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void CreateStageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Stage.Create createdStage);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateStage(Stagio.Web.ViewModels.Stage.Create createdStage)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateStage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createdStage", createdStage);
            CreateStageOverride(callInfo, createdStage);
            return callInfo;
        }

        [NonAction]
        partial void CreateStageSucceedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult CreateStageSucceed()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateStageSucceed);
            CreateStageSucceedOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void InviteContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult InviteContactEnterprise()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteContactEnterprise);
            InviteContactEnterpriseOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void InviteContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.ContactEnterprise.Reactive createContactEnterpriseViewModel);

        [NonAction]
        public override System.Web.Mvc.ActionResult InviteContactEnterprise(Stagio.Web.ViewModels.ContactEnterprise.Reactive createContactEnterpriseViewModel)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteContactEnterprise);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createContactEnterpriseViewModel", createContactEnterpriseViewModel);
            InviteContactEnterpriseOverride(callInfo, createContactEnterpriseViewModel);
            return callInfo;
        }

        [NonAction]
        partial void ListStudentApplyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListStudentApply()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListStudentApply);
            ListStudentApplyOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ListStudentApplyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListStudentApply(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListStudentApply);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ListStudentApplyOverride(callInfo, id);
            return callInfo;
        }

        [NonAction]
        partial void ListStageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListStage()
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListStage);
            ListStageOverride(callInfo);
            return callInfo;
        }

        [NonAction]
        partial void ListStageOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

        [NonAction]
        public override System.Web.Mvc.ActionResult ListStage(int id)
        {
            var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListStage);
            ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
            ListStageOverride(callInfo, id);
            return callInfo;
        }

    }
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
