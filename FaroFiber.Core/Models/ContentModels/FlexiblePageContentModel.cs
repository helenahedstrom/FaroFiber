using FaroFiber.Core.Models.GeneratedModels;
using FaroFiber.Core.Models.ViewModels;

namespace FaroFiber.Core.Models.ContentModels
{
	public class FlexiblePageContentModel : BaseContentModel<FlexiblePageViewModel, FlexiblePage>
	{
		public FlexiblePageContentModel(FlexiblePage publishedContent)
			: base(publishedContent)
		{
		}
	}
}