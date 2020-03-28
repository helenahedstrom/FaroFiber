using System.Collections.Generic;
using System.Linq;
using FaroFiber.Core.Models.DataModels;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace FaroFiber.Core.Classes
{
	//TODO:Rewrite or remove
	public static class ExtensionMethods
	{
		public static List<IPublishedContent> FilterInvalidPages(this IEnumerable<IPublishedContent> pages)
		{
			return pages.Where(p => p.IsVisible() && p.ContentType.Alias != "Faqquestion" && p.ContentType.Alias != "folder").ToList();
		}

		/// <summary>
		/// Get page from Content picker ID
		/// </summary>
		/// <param name="helper">UmbracoHelper</param>
		/// <param name="page">Page to get property from</param>
		/// <param name="propertyAlias">Alias of Content picker property</param>
		/// <returns></returns>
		public static IPublishedContent GetIPublishedContent(this UmbracoHelper helper, IPublishedContent page, string propertyAlias)
		{
			var id = page.Value<int>(propertyAlias);
			return helper.Content(id);
		}

		public static Hero GetHero(this ILayout page)
		{
			var image = page.HeroImage;

			if (image != null)
			{
				return new Hero
				{
					Image = image.Url,
					Text = page.HeroText.ToHtmlString()
				};
			}

			return null;
		}

		public static bool AllowRobotsFollow(this ILayout layout)
		{
			return !layout.DisallowSearchEngineNavigation;
		}

		public static bool AllowRobotsIndex(this ILayout layout)
		{
			return !layout.DisallowSearchEngineToIndexPage;
		}

		public static IEnumerable<IPublishedContent> WhereAllowRobotsIndex(this IEnumerable<ILayout> pages)
		{
			return pages.Where(AllowRobotsIndex);
		}
	}
}