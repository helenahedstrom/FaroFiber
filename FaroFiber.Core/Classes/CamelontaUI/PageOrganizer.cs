//using FaroFiber.Core.Models.GeneratedModels;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using Umbraco.Core.Events;
//using Umbraco.Core.Models.Entities;
//using Umbraco.Core.Services;
//using Umbraco.Web.PublishedCache;

//namespace FaroFiber.Core.Classes.CamelontaUI
//{
//	public class PageOrganizer
//	{
//		public void MoveToDateFolder(SaveEventArgs<Umbraco.Core.Models.IContent> e, IContentService contentService, IPublishedContentCache contentCache,
//			string contentTypeToMove = News.ModelTypeAlias, string contentTypeOfContainer = YearlyNewsContainer.ModelTypeAlias, bool moveToMonth = false)
//		{
//			MoveToDateFolder(e, contentService, contentCache, new List<string> { contentTypeToMove }, contentTypeOfContainer, moveToMonth);
//		}

//		/// <summary>
//		/// Moves pages into year/month folders
//		/// </summary>
//		private void MoveToDateFolder(
//			SaveEventArgs<Umbraco.Core.Models.IContent> e,
//			IContentService contentService,
//			IPublishedContentCache contentCache,
//			ICollection<string> contentTypeToMove,
//			string contentTypeOfContainer = YearlyNewsContainer.ModelTypeAlias,
//			bool moveToMonth = false)
//		{
//			foreach (var page in e.SavedEntities)
//			{
//				var dirty = (IRememberBeingDirty)page;
//				var isNewEntity = dirty.WasPropertyDirty("Id");

//				if (!isNewEntity) return;

//				if (!contentTypeToMove.Contains(page.ContentType.Alias)) return;

//				var now = page.PublishDate ?? DateTime.Now;
//				var year = now.ToString("yyyy");
//				var month = now.ToString(format: "MMMM", CultureInfo.CurrentCulture);

//				Umbraco.Core.Models.IContent yearDocument = null;

//				var parent = contentService.GetParent(page);
//				if (parent.ContentType.Alias.Equals(MonthlyNewsContainer.ModelTypeAlias))
//				{
//					parent = contentService.GetParent(parent);
//				}

//				if (int.TryParse(parent.Name, out var n))
//				{
//					if (n.ToString().Length == 4)
//					{
//						yearDocument = parent;
//					}
//				}
//				if (yearDocument == null)
//				{
//					var yearPage = contentCache.GetById(parent.Id)
//						.Children
//						.FirstOrDefault(x => x.Name.Equals(year, StringComparison.OrdinalIgnoreCase));
//					if (yearPage != null)
//					{
//						yearDocument = contentService.GetById(yearPage.Id);
//					}
//				}

//				if (yearDocument == null)
//				{
//					yearDocument = contentService.CreateAndSave(year, parent.Id, contentTypeOfContainer);
//					contentService.SaveAndPublish(yearDocument);
//				}

//				if (moveToMonth)
//				{
//					var monthDocument = contentService.GetParent(page);
//					if (monthDocument != null &&
//						monthDocument.ContentType.Alias.Equals(MonthlyNewsContainer.ModelTypeAlias, StringComparison.OrdinalIgnoreCase))
//					{
//						contentService.Move(page, monthDocument.Id);
//					}
//					else
//					{
//						var monthPage = contentCache.GetById(yearDocument.Id)
//							.Children
//							.FirstOrDefault(x => x.Name.Equals(month, StringComparison.OrdinalIgnoreCase));
//						monthDocument = monthPage != null ? contentService.GetById(monthPage.Id)
//							: contentService.CreateAndSave(month, yearDocument.Id, MonthlyNewsContainer.ModelTypeAlias);
//						contentService.SaveAndPublish(monthDocument);
//						contentService.Move(page, monthDocument.Id);
//					}
//				}
//				else
//				{
//					contentService.Move(page, yearDocument.Id);
//				}

//				#region Sort year pages
//				try
//				{
//					var mainNewsPage = contentService.GetParent(yearDocument);

//					// SORT year-folders by year (newest first)
//					var sortedYearPages = contentService.GetPagedChildren(mainNewsPage.Id, long.MaxValue, int.MaxValue, out var l)
//						.OrderByDescending(p => p.Name).ToArray();

//					for (var i = 0; i < sortedYearPages.Count(); i++)
//					{
//						sortedYearPages[i].SortOrder = i;
//						contentService.SaveAndPublish(sortedYearPages[i]);
//					}
//				}
//				catch (Exception ex)
//				{
//					Serilog.Log.Logger.Error(ex, $"Type<{typeof(PageOrganizer)}>Could not sort year-documents for News");
//				}
//				#endregion
//			}
//		}
//	}
//}