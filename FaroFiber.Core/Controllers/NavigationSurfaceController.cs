using System.Web.Mvc;
using FaroFiber.Core.Models.DataModels;
using Umbraco.Web.Mvc;

namespace FaroFiber.Core.Controllers
{
    public class NavigationSurfaceController : SurfaceController
    {
        [HttpPost]
        public PartialViewResult GetSubmenus(string id, string currentNode, int level, string type)
        {
            var menuItems = new MenuItems
            {
                CurrentPage = Umbraco.Content(currentNode),
                Pages = Umbraco.Content(id).Children,
                Level = level + 1,
                Type = type
            };
            return PartialView("~/Views/Partials/_MenuItems.cshtml", menuItems);
        }
    }
}