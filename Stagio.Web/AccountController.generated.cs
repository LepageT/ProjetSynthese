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
	public partial class AccountController
	{
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		protected AccountController(Dummy d) { }

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

		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public AccountController Actions { get { return MVC.Account; } }
		[GeneratedCode("T4MVC", "2.0")]
		public readonly string Area = "";
		[GeneratedCode("T4MVC", "2.0")]
		public readonly string Name = "Account";
		[GeneratedCode("T4MVC", "2.0")]
		public const string NameConst = "Account";

		static readonly ActionNamesClass s_actions = new ActionNamesClass();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionNamesClass ActionNames { get { return s_actions; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionNamesClass
		{
			public readonly string Login = "Login";
			public readonly string Logout = "Logout";
			public readonly string Details = "Details";
		}

		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionNameConstants
		{
			public const string Login = "Login";
			public const string Logout = "Logout";
			public const string Details = "Details";
		}


		static readonly ActionParamsClass_Login s_params_Login = new ActionParamsClass_Login();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Login LoginParams { get { return s_params_Login; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Login
		{
			public readonly string accountLoginViewModel = "accountLoginViewModel";
		}
		static readonly ActionParamsClass_Details s_params_Details = new ActionParamsClass_Details();
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public ActionParamsClass_Details DetailsParams { get { return s_params_Details; } }
		[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
		public class ActionParamsClass_Details
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
                public readonly string Details = "Details";
                public readonly string Login = "Login";
            }
            public readonly string Details = "~/Views/Account/Details.cshtml";
            public readonly string Login = "~/Views/Account/Login.cshtml";
		}
	}

	[GeneratedCode("T4MVC", "2.0"), DebuggerNonUserCode]
	public partial class T4MVC_AccountController : Stagio.Web.Controllers.AccountController
	{
		public T4MVC_AccountController() : base(Dummy.Instance) { }

		[NonAction]
		partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult Login()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
			LoginOverride(callInfo);
			return callInfo;
		}

		[NonAction]
		partial void LoginOverride(T4MVC_System_Web_Mvc_ActionResult callInfo, Stagio.Web.ViewModels.Account.Login accountLoginViewModel);

		[NonAction]
		public override System.Web.Mvc.ActionResult Login(Stagio.Web.ViewModels.Account.Login accountLoginViewModel)
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Login);
			ModelUnbinderHelpers.AddRouteValues(callInfo.RouteValueDictionary, "accountLoginViewModel", accountLoginViewModel);
			LoginOverride(callInfo, accountLoginViewModel);
			return callInfo;
		}

		[NonAction]
		partial void LogoutOverride(T4MVC_System_Web_Mvc_ActionResult callInfo);

		[NonAction]
		public override System.Web.Mvc.ActionResult Logout()
		{
			var callInfo = new T4MVC_System_Web_Mvc_ActionResult(Area, Name, ActionNames.Logout);
			LogoutOverride(callInfo);
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

	}
}

#endregion T4MVC
#pragma warning restore 1591, 3008, 3009
