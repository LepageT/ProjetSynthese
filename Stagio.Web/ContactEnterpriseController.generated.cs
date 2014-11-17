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
		public virtual System.Web.Mvc.ActionResult CreateConfirmation()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateConfirmation);
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
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult ListStudentApply()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ListStudentApply);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult DetailsStudentApply()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DetailsStudentApply);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult DetailsStudentApplyPost()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DetailsStudentApplyPost);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult AcceptApplyConfirmation()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AcceptApplyConfirmation);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult RemoveStageConfirmation()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStageConfirmation);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult ReactivateStageConfirmation()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ReactivateStageConfirmation);
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
			public readonly string Create = "Create";
			public readonly string Reactivate = "Reactivate";
			public readonly string CreateConfirmation = "CreateConfirmation";
			public readonly string Edit = "Edit";
			public readonly string Delete = "Delete";
			public readonly string CreateStage = "CreateStage";
			public readonly string CreateStageSucceed = "CreateStageSucceed";
			public readonly string InviteContactEnterprise = "InviteContactEnterprise";
			public readonly string ListStudentApply = "ListStudentApply";
			public readonly string ListStage = "ListStage";
			public readonly string DetailsStudentApply = "DetailsStudentApply";
			public readonly string DetailsStudentApplyPost = "DetailsStudentApply";
			public readonly string AcceptApplyConfirmation = "AcceptApplyConfirmation";
			public readonly string RefuseApplyConfirmation = "RefuseApplyConfirmation";
			public readonly string RemoveStageConfirmation = "RemoveStageConfirmation";
			public readonly string ReactivateStageConfirmation = "ReactivateStageConfirmation";
		}

		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionNameConstants
		{
			public const string Index = "Index";
			public const string Details = "Details";
			public const string Create = "Create";
			public const string Reactivate = "Reactivate";
			public const string CreateConfirmation = "CreateConfirmation";
			public const string Edit = "Edit";
			public const string Delete = "Delete";
			public const string CreateStage = "CreateStage";
			public const string CreateStageSucceed = "CreateStageSucceed";
			public const string InviteContactEnterprise = "InviteContactEnterprise";
			public const string ListStudentApply = "ListStudentApply";
			public const string ListStage = "ListStage";
			public const string DetailsStudentApply = "DetailsStudentApply";
			public const string DetailsStudentApplyPost = "DetailsStudentApply";
			public const string AcceptApplyConfirmation = "AcceptApplyConfirmation";
			public const string RefuseApplyConfirmation = "RefuseApplyConfirmation";
			public const string RemoveStageConfirmation = "RemoveStageConfirmation";
			public const string ReactivateStageConfirmation = "ReactivateStageConfirmation";
		}


		static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Details
		{
			public readonly string id = "id";
		}
		static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Create
		{
			public readonly string createViewModel = "createViewModel";
		}
		static readonly ActionParamsClass_Reactivate s_params_Reactivate = new ActionParamsClass_Reactivate();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Reactivate ReactivateParams { get { return s_params_Reactivate; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Reactivate
		{
			public readonly string token = "token";
			public readonly string createViewModel = "createViewModel";
		}
		static readonly ActionParamsClass_CreateConfirmation s_params_CreateConfirmation = new ActionParamsClass_CreateConfirmation();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_CreateConfirmation CreateConfirmationParams { get { return s_params_CreateConfirmation; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_CreateConfirmation
		{
			public readonly string idContactEnterprise = "idContactEnterprise";
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
			public readonly string createdInviteContactEnterpriseViewModel = "createdInviteContactEnterpriseViewModel";
		}
		static readonly ActionParamsClass_ListStudentApply s_params_ListStudentApply = new ActionParamsClass_ListStudentApply();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_ListStudentApply ListStudentApplyParams { get { return s_params_ListStudentApply; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_ListStudentApply
		{
			public readonly string id = "id";
		}
		static readonly ActionParamsClass_DetailsStudentApply s_params_DetailsStudentApply = new ActionParamsClass_DetailsStudentApply();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_DetailsStudentApply DetailsStudentApplyParams { get { return s_params_DetailsStudentApply; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_DetailsStudentApply
		{
			public readonly string id = "id";
		}
		static readonly ActionParamsClass_DetailsStudentApplyPost s_params_DetailsStudentApplyPost = new ActionParamsClass_DetailsStudentApplyPost();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_DetailsStudentApplyPost DetailsStudentApplyPostParams { get { return s_params_DetailsStudentApplyPost; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_DetailsStudentApplyPost
		{
			public readonly string command = "command";
			public readonly string id = "id";
		}
		static readonly ActionParamsClass_AcceptApplyConfirmation s_params_AcceptApplyConfirmation = new ActionParamsClass_AcceptApplyConfirmation();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_AcceptApplyConfirmation AcceptApplyConfirmationParams { get { return s_params_AcceptApplyConfirmation; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_AcceptApplyConfirmation
		{
			public readonly string acceptApply = "acceptApply";
		}
		static readonly ActionParamsClass_RemoveStageConfirmation s_params_RemoveStageConfirmation = new ActionParamsClass_RemoveStageConfirmation();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_RemoveStageConfirmation RemoveStageConfirmationParams { get { return s_params_RemoveStageConfirmation; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_RemoveStageConfirmation
		{
			public readonly string idStage = "idStage";
		}
		static readonly ActionParamsClass_ReactivateStageConfirmation s_params_ReactivateStageConfirmation = new ActionParamsClass_ReactivateStageConfirmation();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_ReactivateStageConfirmation ReactivateStageConfirmationParams { get { return s_params_ReactivateStageConfirmation; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_ReactivateStageConfirmation
		{
			public readonly string idStage = "idStage";
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
                public readonly string AcceptApplyConfirmation = "AcceptApplyConfirmation";
                public readonly string Create = "Create";
                public readonly string CreateConfirmation = "CreateConfirmation";
                public readonly string CreateStage = "CreateStage";
                public readonly string CreateStageSucceed = "CreateStageSucceed";
                public readonly string DetailsStudentApply = "DetailsStudentApply";
                public readonly string Index = "Index";
                public readonly string InviteContactEnterprise = "InviteContactEnterprise";
                public readonly string ListStage = "ListStage";
                public readonly string ListStudentApply = "ListStudentApply";
                public readonly string Reactivate = "Reactivate";
                public readonly string ReactivateStageConfirmation = "ReactivateStageConfirmation";
                public readonly string RefuseApplyConfirmation = "RefuseApplyConfirmation";
                public readonly string RemoveStageConfirmation = "RemoveStageConfirmation";
            }
            public readonly string AcceptApplyConfirmation = "~/Views/ContactEnterprise/AcceptApplyConfirmation.cshtml";
            public readonly string Create = "~/Views/ContactEnterprise/Create.cshtml";
            public readonly string CreateConfirmation = "~/Views/ContactEnterprise/CreateConfirmation.cshtml";
            public readonly string CreateStage = "~/Views/ContactEnterprise/CreateStage.cshtml";
            public readonly string CreateStageSucceed = "~/Views/ContactEnterprise/CreateStageSucceed.cshtml";
            public readonly string DetailsStudentApply = "~/Views/ContactEnterprise/DetailsStudentApply.cshtml";
            public readonly string Index = "~/Views/ContactEnterprise/Index.cshtml";
            public readonly string InviteContactEnterprise = "~/Views/ContactEnterprise/InviteContactEnterprise.cshtml";
            public readonly string ListStage = "~/Views/ContactEnterprise/ListStage.cshtml";
            public readonly string ListStudentApply = "~/Views/ContactEnterprise/ListStudentApply.cshtml";
            public readonly string Reactivate = "~/Views/ContactEnterprise/Reactivate.cshtml";
            public readonly string ReactivateStageConfirmation = "~/Views/ContactEnterprise/ReactivateStageConfirmation.cshtml";
            public readonly string RefuseApplyConfirmation = "~/Views/ContactEnterprise/RefuseApplyConfirmation.cshtml";
            public readonly string RemoveStageConfirmation = "~/Views/ContactEnterprise/RemoveStageConfirmation.cshtml";
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
		partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult Create()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
			CreateOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.ContactEnterprise.Create createViewModel);

		[NonAction]
		public override System.Web.Mvc.ActionResult Create(Stagio.Web.ViewModels.ContactEnterprise.Create createViewModel)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createViewModel", createViewModel);
			CreateOverride(callInfo, createViewModel);
			return callInfo;
		}

		[NonAction]
		partial void ReactivateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string token);

		[NonAction]
		public override System.Web.Mvc.ActionResult Reactivate(string token)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Reactivate);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "token", token);
			ReactivateOverride(callInfo, token);
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
		partial void CreateConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int idContactEnterprise);

		[NonAction]
		public override System.Web.Mvc.ActionResult CreateConfirmation(int idContactEnterprise)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateConfirmation);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "idContactEnterprise", idContactEnterprise);
			CreateConfirmationOverride(callInfo, idContactEnterprise);
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
		partial void InviteContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.ContactEnterprise.Invite createdInviteContactEnterpriseViewModel);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteContactEnterprise(Stagio.Web.ViewModels.ContactEnterprise.Invite createdInviteContactEnterpriseViewModel)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteContactEnterprise);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createdInviteContactEnterpriseViewModel", createdInviteContactEnterpriseViewModel);
			InviteContactEnterpriseOverride(callInfo, createdInviteContactEnterpriseViewModel);
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
		partial void DetailsStudentApplyOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id);

		[NonAction]
		public override System.Web.Mvc.ActionResult DetailsStudentApply(int id)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DetailsStudentApply);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
			DetailsStudentApplyOverride(callInfo, id);
			return callInfo;
		}

		[NonAction]
		partial void DetailsStudentApplyPostOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string command, int id);

		[NonAction]
		public override System.Web.Mvc.ActionResult DetailsStudentApplyPost(string command, int id)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DetailsStudentApplyPost);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "command", command);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
			DetailsStudentApplyPostOverride(callInfo, command, id);
			return callInfo;
		}

		[NonAction]
		partial void AcceptApplyConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.ContactEnterprise.AcceptApply acceptApply);

		[NonAction]
		public override System.Web.Mvc.ActionResult AcceptApplyConfirmation(Stagio.Web.ViewModels.ContactEnterprise.AcceptApply acceptApply)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.AcceptApplyConfirmation);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "acceptApply", acceptApply);
			AcceptApplyConfirmationOverride(callInfo, acceptApply);
			return callInfo;
		}

		[NonAction]
		partial void RefuseApplyConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult RefuseApplyConfirmation()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RefuseApplyConfirmation);
			RefuseApplyConfirmationOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void RemoveStageConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int idStage);

		[NonAction]
		public override System.Web.Mvc.ActionResult RemoveStageConfirmation(int idStage)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStageConfirmation);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "idStage", idStage);
			RemoveStageConfirmationOverride(callInfo, idStage);
			return callInfo;
		}

		[NonAction]
		partial void ReactivateStageConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int idStage);

		[NonAction]
		public override System.Web.Mvc.ActionResult ReactivateStageConfirmation(int idStage)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ReactivateStageConfirmation);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "idStage", idStage);
			ReactivateStageConfirmationOverride(callInfo, idStage);
			return callInfo;
		}

	}
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
