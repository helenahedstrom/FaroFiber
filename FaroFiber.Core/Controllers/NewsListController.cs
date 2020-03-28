using FaroFiber.Core.Models.ContentModels;
using FaroFiber.Core.Models.GeneratedModels;
using FaroFiber.Core.Models.ViewModels;
using Umbraco.Web.Models;

namespace FaroFiber.Core.Controllers
{
	public class NewsListController : BaseRenderMvcController<NewsList>
	{
		public override ContentModel<NewsList> GetContentModel(NewsList content)
		{
			int.TryParse(UmbracoContext.HttpContext.Request.QueryString["q"], out var skip);
			var viewModel = new NewsListViewModel(content, skip);

			return new NewsListContentModel(content)
			{
				ViewModel = viewModel
			};
		}
	}
}