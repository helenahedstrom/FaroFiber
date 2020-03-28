using System;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using FaroFiber.Core.Models.GeneratedModels;
using Newtonsoft.Json.Linq;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Content = FaroFiber.Core.Models.GeneratedModels.Content;

namespace FaroFiber.Core.Classes
{
	//TODO: Maybe rewrite to MetaHelper using DI
	public static class Meta
	{
		public static string PageTeaser(ILayout page, int truncate = 250)
		{
			var teaser = page.MetaDescription;
			if (!string.IsNullOrEmpty(teaser))
			{
				return teaser.Truncate(truncate);
			}

			teaser = PageMainContent(page);

			if (string.IsNullOrEmpty(teaser))
			{
				return string.Empty;
			}

			teaser = Regex.Replace(teaser.StripHtml(), @"\s+", " ");

			return teaser.Truncate(truncate);
		}

		public static string PageMainImage(ILayout page)
		{
			var previewImage = page.ImageForSocialMediaSharing?.Url ?? string.Empty;

			if (string.IsNullOrEmpty(previewImage))
			{
				var pageContent = PageMainContent(page);

				if (pageContent != null)
				{
					// Get the first image from the content
					previewImage = Regex.Match(pageContent, "<img.*?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
				}
			}

			if (string.IsNullOrEmpty(previewImage))
			{
                previewImage = Constants.FilesPath.DefaultSocialSharingImage;
			}

			return previewImage.Split('?').First();
		}

		private static string PageMainContent(IPublishedElement page)
		{
			var content = string.Empty;
			var contentMiddle = page.GetProperty(Content.GetModelPropertyType(l => l.ContentMiddle).Alias);
			if (contentMiddle != null && contentMiddle.HasValue())
			{
				content = contentMiddle.Value<IHtmlString>().ToHtmlString();
			}

			if (page.HasValue("grid"))
			{
				content = GetGridText(page.Value<JToken>("grid"));
			}

			return content;
		}

		public static string GetGridText(JToken content)
		{
			var sections = ((dynamic)content).sections;

			var combined = new StringBuilder();

			foreach (var section in sections)
			{
				foreach (var row in section.rows)
				{
					foreach (var area in row.areas)
					{
						foreach (var control in area.controls)
						{
							switch (control.editor.alias.ToString())
							{
								case "rte":
									{
										var html = control.value.ToString();
										var text = Regex.Replace(html, "<.*?>", "");
										text = HttpUtility.HtmlDecode(text);
										combined.AppendLine(text);
										break;
									}

								case "media":
									{
										var caption = control.value?.caption?.ToString();
										if (string.IsNullOrWhiteSpace(caption))
										{
											combined.AppendLine(caption);
										}
										break;
									}

								case "headline":
								case "quote":
									{
										combined.AppendLine(control.value.ToString());
										break;
									}
							}
						}
					}
				}
			}
			return combined.ToString();
		}

		public static string PageTitle(ILayout page)
		{
			var windowTitle = page.WindowTitleAndSocialMediaHeader;
			return string.IsNullOrEmpty(windowTitle) ? page.Name : windowTitle;

		}

		public static bool AutoHeader(this IPublishedContent page)
		{
			if (page.ContentType.Alias.Equals(NewsList.ModelTypeAlias, StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}

			var content = PageMainContent(page);
			return !content.Contains("<h1");
		}

		public static bool GridHasContent(IPublishedContent page, string gridAlias)
		{
			var result = false;
			var sections = ((dynamic)page.Value(gridAlias)).sections;

			foreach (var section in sections)
			{
				foreach (var row in section.rows)
				{
					foreach (var area in row.areas)
					{
						result = area.controls != null && ((JArray)area.controls).HasValues;
					}
				}
			}

			return result;
		}


		public static string RobotsContent(ILayout page)
		{
			var sb = new StringBuilder();
			sb.Append($"{(page.AllowRobotsIndex() ? Constants.Search.Index : Constants.Search.NoIndex)}," +
					$"{(page.AllowRobotsFollow() ? Constants.Search.Follow : Constants.Search.NoFollow)}");
			return sb.ToString();
		}
	}
}