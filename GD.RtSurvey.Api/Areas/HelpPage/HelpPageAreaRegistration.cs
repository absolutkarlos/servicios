using System.Web.Http;
using System.Web.Mvc;
using GD.RtSurvey.Api.Areas.HelpPage.App_Start;

namespace GD.RtSurvey.Api.Areas.HelpPage
{
	public class HelpPageAreaRegistration : AreaRegistration
	{
		public override string AreaName => "HelpPage";

		public override void RegisterArea(AreaRegistrationContext context)
		{
			context.MapRoute(
				"HelpPage_Default",
				"Help/{action}/{apiId}",
				new { controller = "Help", action = "Index", apiId = UrlParameter.Optional });

			HelpPageConfig.Register(GlobalConfiguration.Configuration);
		}
	}
}