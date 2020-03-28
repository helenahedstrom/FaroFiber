using System;
using System.Collections.Generic;
using System.Linq;
using FaroFiber.Core.Models.DataModels;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Web;

namespace FaroFiber.Core.Models.ViewModels
{
	public class NewsListViewModel
	{
		public NewsListViewModel(NewsList contentModel, int skip)
		{
			var news = contentModel.Descendants<News>().ToList();
			this.Take = 40;
			this.Skip = skip;
			this.CurrentPageNumber = skip > 0 ? ((skip / this.Take) + 1) : 1;
			this.CurrentPageItems = news.OrderByDescending(p => p.CreateDate).Skip(skip).Take(this.Take).Select(l => new NewsItem(l));
			this.ItemsCount = news.Count();
			this.AmountOfPages = Math.Ceiling(this.ItemsCount / this.Take);
		}

		public int Take { get; }

		public int Skip { get; set; }

		public int CurrentPageNumber { get; }

		public decimal ItemsCount { get; }

		public decimal AmountOfPages { get; }

		public IEnumerable<NewsItem> CurrentPageItems { get; }
	}
}