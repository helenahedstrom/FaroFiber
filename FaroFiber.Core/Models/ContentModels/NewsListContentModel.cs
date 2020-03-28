using FaroFiber.Core.Models.GeneratedModels;
using FaroFiber.Core.Models.ViewModels;

namespace FaroFiber.Core.Models.ContentModels
{
	public class NewsListContentModel : BaseContentModel<NewsListViewModel, NewsList>
	{
		public NewsListContentModel(NewsList publishedContent)
			: base(publishedContent)
		{
		}
	}
}