using FaroFiber.Core.Classes;
using FaroFiber.Core.Models.GeneratedModels;

namespace FaroFiber.Core.Models.DataModels
{
	public class NewsItem
	{
		public NewsItem(News contentModel)
		{
			this.Url = contentModel.Url;
			this.Name = contentModel.Name;
			this.CreateDate = contentModel.CreateDate.ToString("yyyy-MM-dd");
			this.Teaser = Meta.PageTeaser(contentModel);
		}

		public string Url { get; }

		public string Name { get; }

		public string CreateDate { get; }

		public string Teaser { get; }
	}
}