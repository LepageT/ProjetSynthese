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
	public partial class CoordinatorController
	{
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		protected CoordinatorController(Dummy d) { }

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
		public virtual System.Web.Mvc.ActionResult Create()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult StudentApplyList()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.StudentApplyList);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult UploadPost()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadPost);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult DetailsApplyStudent()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DetailsApplyStudent);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult Download()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Download);
		}
		[NonAction]
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public virtual System.Web.Mvc.ActionResult RemoveStudentFromListStudent()
		{
			return new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStudentFromListStudent);
		}

		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public CoordinatorController Actions { get { return MVC.Coordinator; } }
		[GeneratedCode("T4MVC", "2.0")]
		public readonly string Area = "";
		[GeneratedCode("T4MVC", "2.0")]
		public readonly string Name = "Coordinator";
		[GeneratedCode("T4MVC", "2.0")]
		public const string NameConst = "Coordinator";

		static readonly ActionNamesClass s_actions = new ActionNamesClass();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionNamesClass ActionNames { get { return s_actions; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionNamesClass
		{
			public readonly string Index = "Index";
			public readonly string InviteContactEnterprise = "InviteContactEnterprise";
			public readonly string InviteContactEnterpriseConfirmation = "InviteContactEnterpriseConfirmation";
			public readonly string Create = "Create";
			public readonly string Invite = "Invite";
			public readonly string InvitationSucceed = "InvitationSucceed";
			public readonly string CreateConfirmation = "CreateConfirmation";
			public readonly string StudentList = "StudentList";
			public readonly string StudentApplyList = "StudentApplyList";
			public readonly string Upload = "Upload";
			public readonly string UploadPost = "Upload";
			public readonly string ResultCreateList = "ResultCreateList";
			public readonly string PostResultCreateList = "ResultCreateList";
			public readonly string CreateList = "CreateList";
			public readonly string CreateListPost = "CreateList";
			public readonly string DetailsApplyStudent = "DetailsApplyStudent";
			public readonly string Download = "Download";
			public readonly string SetApplyDates = "SetApplyDates";
			public readonly string InviteOneContactEnterprise = "InviteOneContactEnterprise";
			public readonly string InviteOneContactEnterpriseConfirmation = "InviteOneContactEnterpriseConfirmation";
			public readonly string BlockWebsiteAccess = "BlockWebsiteAccess";
			public readonly string BlockWebsiteAccessPost = "BlockWebsiteAccess";
			public readonly string RemoveStudentFromListStudent = "RemoveStudentFromListStudent";
			public readonly string RemoveStudent = "RemoveStudent";
			public readonly string RemoveStudentConfirmation = "RemoveStudentConfirmation";
			public readonly string ChangeSmtpOptions = "ChangeSmtpOptions";
		}

		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionNameConstants
		{
			public const string Index = "Index";
			public const string InviteContactEnterprise = "InviteContactEnterprise";
			public const string InviteContactEnterpriseConfirmation = "InviteContactEnterpriseConfirmation";
			public const string Create = "Create";
			public const string Invite = "Invite";
			public const string InvitationSucceed = "InvitationSucceed";
			public const string CreateConfirmation = "CreateConfirmation";
			public const string StudentList = "StudentList";
			public const string StudentApplyList = "StudentApplyList";
			public const string Upload = "Upload";
			public const string UploadPost = "Upload";
			public const string ResultCreateList = "ResultCreateList";
			public const string PostResultCreateList = "ResultCreateList";
			public const string CreateList = "CreateList";
			public const string CreateListPost = "CreateList";
			public const string DetailsApplyStudent = "DetailsApplyStudent";
			public const string Download = "Download";
			public const string SetApplyDates = "SetApplyDates";
			public const string InviteOneContactEnterprise = "InviteOneContactEnterprise";
			public const string InviteOneContactEnterpriseConfirmation = "InviteOneContactEnterpriseConfirmation";
			public const string BlockWebsiteAccess = "BlockWebsiteAccess";
			public const string BlockWebsiteAccessPost = "BlockWebsiteAccess";
			public const string RemoveStudentFromListStudent = "RemoveStudentFromListStudent";
			public const string RemoveStudent = "RemoveStudent";
			public const string RemoveStudentConfirmation = "RemoveStudentConfirmation";
			public const string ChangeSmtpOptions = "ChangeSmtpOptions";
		}


		static readonly ActionParamsClass_InviteContactEnterprise s_params_InviteContactEnterprise = new ActionParamsClass_InviteContactEnterprise();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_InviteContactEnterprise InviteContactEnterpriseParams { get { return s_params_InviteContactEnterprise; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_InviteContactEnterprise
		{
			public readonly string selectedIdContactEnterprise = "selectedIdContactEnterprise";
			public readonly string messageInvitation = "messageInvitation";
		}
		static readonly ActionParamsClass_Create s_params_Create = new ActionParamsClass_Create();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Create CreateParams { get { return s_params_Create; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Create
		{
			public readonly string token = "token";
			public readonly string createdCoordinator = "createdCoordinator";
		}
		static readonly ActionParamsClass_Invite s_params_Invite = new ActionParamsClass_Invite();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Invite InviteParams { get { return s_params_Invite; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Invite
		{
			public readonly string createdInvite = "createdInvite";
		}
		static readonly ActionParamsClass_StudentApplyList s_params_StudentApplyList = new ActionParamsClass_StudentApplyList();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_StudentApplyList StudentApplyListParams { get { return s_params_StudentApplyList; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_StudentApplyList
		{
			public readonly string studentId = "studentId";
		}
		static readonly ActionParamsClass_UploadPost s_params_UploadPost = new ActionParamsClass_UploadPost();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_UploadPost UploadPostParams { get { return s_params_UploadPost; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_UploadPost
		{
			public readonly string file = "file";
		}
		static readonly ActionParamsClass_DetailsApplyStudent s_params_DetailsApplyStudent = new ActionParamsClass_DetailsApplyStudent();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_DetailsApplyStudent DetailsApplyStudentParams { get { return s_params_DetailsApplyStudent; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_DetailsApplyStudent
		{
			public readonly string id = "id";
			public readonly string error = "error";
		}
		static readonly ActionParamsClass_Download s_params_Download = new ActionParamsClass_Download();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Download DownloadParams { get { return s_params_Download; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Download
		{
			public readonly string file = "file";
			public readonly string id = "id";
		}
		static readonly ActionParamsClass_SetApplyDates s_params_SetApplyDates = new ActionParamsClass_SetApplyDates();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_SetApplyDates SetApplyDatesParams { get { return s_params_SetApplyDates; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_SetApplyDates
		{
			public readonly string ApplyDates = "ApplyDates";
		}
		static readonly ActionParamsClass_InviteOneContactEnterprise s_params_InviteOneContactEnterprise = new ActionParamsClass_InviteOneContactEnterprise();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_InviteOneContactEnterprise InviteOneContactEnterpriseParams { get { return s_params_InviteOneContactEnterprise; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_InviteOneContactEnterprise
		{
			public readonly string createdInviteContactEnterpriseViewModel = "createdInviteContactEnterpriseViewModel";
		}
		static readonly ActionParamsClass_RemoveStudentFromListStudent s_params_RemoveStudentFromListStudent = new ActionParamsClass_RemoveStudentFromListStudent();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_RemoveStudentFromListStudent RemoveStudentFromListStudentParams { get { return s_params_RemoveStudentFromListStudent; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_RemoveStudentFromListStudent
		{
			public readonly string matricule = "matricule";
		}
		static readonly ActionParamsClass_RemoveStudent s_params_RemoveStudent = new ActionParamsClass_RemoveStudent();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_RemoveStudent RemoveStudentParams { get { return s_params_RemoveStudent; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_RemoveStudent
		{
			public readonly string idStudentsToRemove = "idStudentsToRemove";
		}
		static readonly ActionParamsClass_ChangeSmtpOptions s_params_ChangeSmtpOptions = new ActionParamsClass_ChangeSmtpOptions();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_ChangeSmtpOptions ChangeSmtpOptionsParams { get { return s_params_ChangeSmtpOptions; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_ChangeSmtpOptions
		{
			public readonly string command = "command";
			public readonly string smtpOption = "smtpOption";
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
                public readonly string BlockWebsiteAccess = "BlockWebsiteAccess";
                public readonly string ChangeSMTPOptions = "ChangeSMTPOptions";
                public readonly string Create = "Create";
                public readonly string CreateConfirmation = "CreateConfirmation";
                public readonly string CreateList = "CreateList";
                public readonly string DetailsApplyStudent = "DetailsApplyStudent";
                public readonly string Index = "Index";
                public readonly string InvitationSucceed = "InvitationSucceed";
                public readonly string Invite = "Invite";
                public readonly string InviteContactEnterprise = "InviteContactEnterprise";
                public readonly string InviteContactEnterpriseConfirmation = "InviteContactEnterpriseConfirmation";
                public readonly string InviteOneContactEnterprise = "InviteOneContactEnterprise";
                public readonly string InviteOneContactEnterpriseConfirmation = "InviteOneContactEnterpriseConfirmation";
                public readonly string RemoveStudent = "RemoveStudent";
                public readonly string RemoveStudentConfirmation = "RemoveStudentConfirmation";
                public readonly string ResultCreateList = "ResultCreateList";
                public readonly string SetApplyDates = "SetApplyDates";
                public readonly string StudentApplyList = "StudentApplyList";
                public readonly string StudentList = "StudentList";
                public readonly string Upload = "Upload";
            }
            public readonly string BlockWebsiteAccess = "~/Views/Coordinator/BlockWebsiteAccess.cshtml";
            public readonly string ChangeSMTPOptions = "~/Views/Coordinator/ChangeSMTPOptions.cshtml";
            public readonly string Create = "~/Views/Coordinator/Create.cshtml";
            public readonly string CreateConfirmation = "~/Views/Coordinator/CreateConfirmation.cshtml";
            public readonly string CreateList = "~/Views/Coordinator/CreateList.cshtml";
            public readonly string DetailsApplyStudent = "~/Views/Coordinator/DetailsApplyStudent.cshtml";
            public readonly string Index = "~/Views/Coordinator/Index.cshtml";
            public readonly string InvitationSucceed = "~/Views/Coordinator/InvitationSucceed.cshtml";
            public readonly string Invite = "~/Views/Coordinator/Invite.cshtml";
            public readonly string InviteContactEnterprise = "~/Views/Coordinator/InviteContactEnterprise.cshtml";
            public readonly string InviteContactEnterpriseConfirmation = "~/Views/Coordinator/InviteContactEnterpriseConfirmation.cshtml";
            public readonly string InviteOneContactEnterprise = "~/Views/Coordinator/InviteOneContactEnterprise.cshtml";
            public readonly string InviteOneContactEnterpriseConfirmation = "~/Views/Coordinator/InviteOneContactEnterpriseConfirmation.cshtml";
            public readonly string RemoveStudent = "~/Views/Coordinator/RemoveStudent.cshtml";
            public readonly string RemoveStudentConfirmation = "~/Views/Coordinator/RemoveStudentConfirmation.cshtml";
            public readonly string ResultCreateList = "~/Views/Coordinator/ResultCreateList.cshtml";
            public readonly string SetApplyDates = "~/Views/Coordinator/SetApplyDates.cshtml";
            public readonly string StudentApplyList = "~/Views/Coordinator/StudentApplyList.cshtml";
            public readonly string StudentList = "~/Views/Coordinator/StudentList.cshtml";
            public readonly string Upload = "~/Views/Coordinator/Upload.cshtml";
		}
	}

	[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
	public partial class T4MVC_CoordinatorController : Stagio.Web.Controllers.CoordinatorController
	{
		public T4MVC_CoordinatorController() : base(Dummy.Instance) { }

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
		partial void InviteContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteContactEnterprise()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteContactEnterprise);
			InviteContactEnterpriseOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void InviteContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Collections.Generic.IEnumerable<int> selectedIdContactEnterprise, string messageInvitation);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteContactEnterprise(System.Collections.Generic.IEnumerable<int> selectedIdContactEnterprise, string messageInvitation)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteContactEnterprise);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "selectedIdContactEnterprise", selectedIdContactEnterprise);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "messageInvitation", messageInvitation);
			InviteContactEnterpriseOverride(callInfo, selectedIdContactEnterprise, messageInvitation);
			return callInfo;
		}

		[NonAction]
		partial void InviteContactEnterpriseConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteContactEnterpriseConfirmation()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteContactEnterpriseConfirmation);
			InviteContactEnterpriseConfirmationOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string token);

		[NonAction]
		public override System.Web.Mvc.ActionResult Create(string token)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "token", token);
			CreateOverride(callInfo, token);
			return callInfo;
		}

		[NonAction]
		partial void CreateOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Coordinator.Create createdCoordinator);

		[NonAction]
		public override System.Web.Mvc.ActionResult Create(Stagio.Web.ViewModels.Coordinator.Create createdCoordinator)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Create);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createdCoordinator", createdCoordinator);
			CreateOverride(callInfo, createdCoordinator);
			return callInfo;
		}

		[NonAction]
		partial void InviteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult Invite()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Invite);
			InviteOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void InviteOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Coordinator.Invite createdInvite);

		[NonAction]
		public override System.Web.Mvc.ActionResult Invite(Stagio.Web.ViewModels.Coordinator.Invite createdInvite)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Invite);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createdInvite", createdInvite);
			InviteOverride(callInfo, createdInvite);
			return callInfo;
		}

		[NonAction]
		partial void InvitationSucceedOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult InvitationSucceed()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InvitationSucceed);
			InvitationSucceedOverride(callInfo);
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
		partial void StudentListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult StudentList()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.StudentList);
			StudentListOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void StudentApplyListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int studentId);

		[NonAction]
		public override System.Web.Mvc.ActionResult StudentApplyList(int studentId)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.StudentApplyList);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "studentId", studentId);
			StudentApplyListOverride(callInfo, studentId);
			return callInfo;
		}

		[NonAction]
		partial void UploadOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult Upload()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Upload);
			UploadOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void UploadPostOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Web.HttpPostedFileBase file);

		[NonAction]
		public override System.Web.Mvc.ActionResult UploadPost(System.Web.HttpPostedFileBase file)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.UploadPost);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "file", file);
			UploadPostOverride(callInfo, file);
			return callInfo;
		}

		[NonAction]
		partial void ResultCreateListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult ResultCreateList()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ResultCreateList);
			ResultCreateListOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void PostResultCreateListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult PostResultCreateList()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.PostResultCreateList);
			PostResultCreateListOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void CreateListOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult CreateList()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateList);
			CreateListOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void CreateListPostOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult CreateListPost()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.CreateListPost);
			CreateListPostOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void DetailsApplyStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int id, bool error);

		[NonAction]
		public override System.Web.Mvc.ActionResult DetailsApplyStudent(int id, bool error)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.DetailsApplyStudent);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "error", error);
			DetailsApplyStudentOverride(callInfo, id, error);
			return callInfo;
		}

		[NonAction]
		partial void DownloadOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string file, int id);

		[NonAction]
		public override System.Web.Mvc.ActionResult Download(string file, int id)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Download);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "file", file);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "id", id);
			DownloadOverride(callInfo, file, id);
			return callInfo;
		}

		[NonAction]
		partial void SetApplyDatesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult SetApplyDates()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetApplyDates);
			SetApplyDatesOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void SetApplyDatesOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Coordinator.ApplyDatesLimit ApplyDates);

		[NonAction]
		public override System.Web.Mvc.ActionResult SetApplyDates(Stagio.Web.ViewModels.Coordinator.ApplyDatesLimit ApplyDates)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.SetApplyDates);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "ApplyDates", ApplyDates);
			SetApplyDatesOverride(callInfo, ApplyDates);
			return callInfo;
		}

		[NonAction]
		partial void InviteOneContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteOneContactEnterprise()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteOneContactEnterprise);
			InviteOneContactEnterpriseOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void InviteOneContactEnterpriseOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Coordinator.InviteContactEnterprise createdInviteContactEnterpriseViewModel);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteOneContactEnterprise(Stagio.Web.ViewModels.Coordinator.InviteContactEnterprise createdInviteContactEnterpriseViewModel)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteOneContactEnterprise);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "createdInviteContactEnterpriseViewModel", createdInviteContactEnterpriseViewModel);
			InviteOneContactEnterpriseOverride(callInfo, createdInviteContactEnterpriseViewModel);
			return callInfo;
		}

		[NonAction]
		partial void InviteOneContactEnterpriseConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult InviteOneContactEnterpriseConfirmation()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.InviteOneContactEnterpriseConfirmation);
			InviteOneContactEnterpriseConfirmationOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void BlockWebsiteAccessOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult BlockWebsiteAccess()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.BlockWebsiteAccess);
			BlockWebsiteAccessOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void BlockWebsiteAccessPostOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult BlockWebsiteAccessPost()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.BlockWebsiteAccessPost);
			BlockWebsiteAccessPostOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void RemoveStudentFromListStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, int matricule);

		[NonAction]
		public override System.Web.Mvc.ActionResult RemoveStudentFromListStudent(int matricule)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStudentFromListStudent);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "matricule", matricule);
			RemoveStudentFromListStudentOverride(callInfo, matricule);
			return callInfo;
		}

		[NonAction]
		partial void RemoveStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult RemoveStudent()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStudent);
			RemoveStudentOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void RemoveStudentOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, System.Collections.Generic.IEnumerable<int> idStudentsToRemove);

		[NonAction]
		public override System.Web.Mvc.ActionResult RemoveStudent(System.Collections.Generic.IEnumerable<int> idStudentsToRemove)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStudent);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "idStudentsToRemove", idStudentsToRemove);
			RemoveStudentOverride(callInfo, idStudentsToRemove);
			return callInfo;
		}

		[NonAction]
		partial void RemoveStudentConfirmationOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult RemoveStudentConfirmation()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.RemoveStudentConfirmation);
			RemoveStudentConfirmationOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void ChangeSmtpOptionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult ChangeSmtpOptions()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeSmtpOptions);
			ChangeSmtpOptionsOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void ChangeSmtpOptionsOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, string command, Stagio.Web.ViewModels.Coordinator.SmtpOption smtpOption);

		[NonAction]
		public override System.Web.Mvc.ActionResult ChangeSmtpOptions(string command, Stagio.Web.ViewModels.Coordinator.SmtpOption smtpOption)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.ChangeSmtpOptions);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "command", command);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "smtpOption", smtpOption);
			ChangeSmtpOptionsOverride(callInfo, command, smtpOption);
			return callInfo;
		}

	}
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
