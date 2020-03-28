using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web.Models;

namespace FaroFiber.Core.Models.ContentModels
{
	public abstract class BaseContentModel<TViewModel, TContentModel> : ContentModel<TContentModel>
		where TContentModel : IPublishedContent
	{
		protected BaseContentModel(TContentModel publishedContent)
			: base(publishedContent)
		{
		}

		public TViewModel ViewModel { get; set; }
	}
}