using System;
using System.Web.Mvc;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Composing;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;

namespace FaroFiber.Core.Controllers
{
	public abstract class BaseRenderMvcController<T> : RenderMvcController
		where T : IPublishedContent
	{
		public Func<string> GetViewNameDelegate { get; set; }

		public Func<T> GetContentModelDelegate { get; set; }

		public Func<UmbracoContext> GetUmbracoContextDelegate { get; set; }

		public override UmbracoContext UmbracoContext => GetUmbracoContextDelegate != null ? GetUmbracoContextDelegate() : Current.UmbracoContext;

		public virtual T CreateContentModel(IPublishedContent content) => (T)content;

		public T GetTypedModel() => GetContentModelDelegate != null ? GetContentModelDelegate() : CreateContentModel(CurrentPage);

		public virtual string GetViewName() => GetViewNameDelegate != null ? GetViewNameDelegate() : ControllerContext.RouteData.Values["action"].ToString();

		public virtual ContentModel<T> GetContentModel(T content) => new ContentModel<T>(content);

		[HttpGet]
		public override ActionResult Index(ContentModel model) => RenderDefaultView();

		[HttpGet]
		public virtual ActionResult RenderDefaultView()
		{
			var typedModel = GetTypedModel();

			return RenderDefaultView(typedModel);
		}

		[HttpGet]
		public virtual ActionResult RenderDefaultView(T contentModel)
		{
			var template = GetViewName();
			var model = GetContentModel(contentModel);

			if (model == null)
			{
				return HttpNotFound();
			}

			return View(template, model);
		}
	}
}