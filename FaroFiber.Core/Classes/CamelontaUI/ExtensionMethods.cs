using System;
using System.Collections.Generic;
using System.Linq;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace FaroFiber.Core.Classes.CamelontaUI
{
	public static class ExtensionMethods
	{
		#region IPublishedContent

		public static string NavName(this IPublishedContent page)
		{
			return page.HasProperty("navName") && page.HasValue("navName") ? page.Value<string>("navName") : page.Name;
		}

		public static string IfPageIsCurrent(this IPublishedContent page, ContentModel model, string cssClass)
		{
			return model.Content.Id == page.Id ? cssClass : null;
		}

		public static string IfPageIsCurrent(this IPublishedContent page, IPublishedContent currentPage, string cssClass)
		{
			return currentPage.Id == page.Id ? cssClass : null;
		}

		public static string IfPageIsActive(this IPublishedContent page, ContentModel model, string cssClass)
		{
			return page.IsAncestorOrSelf(model.Content) ? cssClass : null;
		}

		public static string IfPageIsActive(this IPublishedContent page, IPublishedContent currentPage, string cssClass)
		{
			return page.IsAncestorOrSelf(currentPage) ? cssClass : null;
		}

		public static string GetPageUrl(this IPublishedContent page)
		{
			var url = string.Empty;
			var externalLinklAlias = ExternalLink.GetModelPropertyType(l => l.ExternalLinkProperty).Alias;
			var internalLinklAlias = InternalLink.GetModelPropertyType(l => l.InternalLinkProperty).Alias;

			if (page == null)
			{
				return url;
			}

			if (page.ContentType.Alias.Equals(Home.ModelTypeAlias, StringComparison.OrdinalIgnoreCase) &&
				page.Parent.ContentType.Alias.Equals(Site.ModelTypeAlias))
			{
				var site = page.Parent;
				url = site.Url;
			}
			else if (page.HasProperty(externalLinklAlias))
			{
				url = page.Value<string>(externalLinklAlias);
			}
			else if (page.HasProperty(internalLinklAlias))
			{
				var destinationPage = page.Value<IPublishedContent>(internalLinklAlias);
				url = destinationPage?.Url ?? url;
			}
			else
			{
				url = page.Url;
			}

			return url;
		}

		public static bool AllowRobotsFollow(this IPublishedContent p)
		{
			return !p.GetProperty("disallowSearchEngineNavigation").Value<bool>();
		}

		public static bool AllowRobotsIndex(this IPublishedContent p)
		{
			return !p.GetProperty("disallowSearchEngineToIndexPage").Value<bool>();
		}

		public static IEnumerable<IPublishedContent> WhereAllowRobotsIndex(this IEnumerable<IPublishedContent> pages) => pages.Where(AllowRobotsIndex);

		#endregion

		#region String

		/// <summary>
		/// Truncate string at first word after set length
		/// </summary>
		[Obsolete("Use Umbraco own truncate method")]
		public static string TruncateAtWord(this string value, int length, string endWith = "...")
		{
			if (value == null || value.Length < length || value.IndexOf(" ", length, StringComparison.Ordinal) == -1)
			{
				return value;
			}

			return value.Substring(0, value.IndexOf(" ", length, StringComparison.Ordinal)) + endWith;
		}

		/// <summary>
		/// Languages are available in swedish and english
		/// </summary>
		public static string GetMonthFromNumber(this string number, bool englishMonthNames)
		{
			var fullMonthsEnglish = new[] { "January", "February", "Mars", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
			var fullMonthsSwedish = new[] { "Januari", "Februari", "Mars", "April", "Maj", "Juni", "Juli", "Augusti", "September", "Oktober", "November", "December" };

			if (!int.TryParse(number, out var n))
			{
				return number;
			}

			return englishMonthNames ? fullMonthsEnglish[n - 1] : fullMonthsSwedish[n - 1];
		}

		#endregion
	}
}