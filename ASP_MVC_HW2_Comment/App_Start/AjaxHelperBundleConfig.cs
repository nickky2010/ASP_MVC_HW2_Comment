using System.Web.Optimization;

[assembly: WebActivatorEx.PostApplicationStartMethod(typeof(ASP_MVC_HW2_Comment.App_Start.AjaxHelperBundleConfig), "RegisterBundles")]

namespace ASP_MVC_HW2_Comment.App_Start
{
	public class AjaxHelperBundleConfig
	{
		public static void RegisterBundles()
		{
			BundleTable.Bundles.Add(new ScriptBundle("~/bundles/ajaxhelper").Include("~/Scripts/jquery.ajaxhelper.js"));
		}
	}
}