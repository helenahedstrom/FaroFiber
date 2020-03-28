using FaroFiber.Core.Models.ContentModels;
using FaroFiber.Core.Models.GeneratedModels;
using FaroFiber.Core.Models.ViewModels;
using Umbraco.Web.Models;

namespace FaroFiber.Core.Controllers
{
	public class FlexiblePageController : BaseRenderMvcController<FlexiblePage>
	{
		public override ContentModel<FlexiblePage> GetContentModel(FlexiblePage content)
		{
			var viewModel = new FlexiblePageViewModel(content);
			return new FlexiblePageContentModel(content)
			{
				ViewModel = viewModel
			};
		}
	}
}