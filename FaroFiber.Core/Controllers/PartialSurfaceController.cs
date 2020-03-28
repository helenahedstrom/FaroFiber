using System.Web.Mvc;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace FaroFiber.Core.Controllers
{
	public class PartialSurfaceController : SurfaceController
	{
		[HttpPost]
		public PartialViewResult CookieWarning(string nodeId)
		{
			var currentSite = Umbraco.Content(nodeId).AncestorOrSelf<Site>();
			return PartialView("~/Views/Partials/_CookieWarning.cshtml", currentSite);
		}
	}
}