using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace FaroFiber.Core.Models.ViewModels
{
	public class LayoutViewModel
	{
		public LayoutViewModel(IPublishedContent contentModel)
		{
			this.CurrentSite = contentModel.AncestorOrSelf<Site>();
			this.SearchPage = this.CurrentSite.Descendant<Search>();
		}

		public Site CurrentSite { get; }

		public Search SearchPage { get; }
	}
}