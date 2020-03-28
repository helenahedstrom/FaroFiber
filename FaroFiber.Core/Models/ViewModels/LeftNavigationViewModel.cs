using System.Collections.Generic;
using System.Linq;
using FaroFiber.Core.Classes;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace FaroFiber.Core.Models.ViewModels
{
	public class LeftNavigationViewModel
	{
		public LeftNavigationViewModel(ILayout contentModel)
		{
			this.Items = contentModel.AncestorOrSelf(2).Children.FilterInvalidPages();
			this.Hide = !this.Items.Any() || contentModel.HideInLeftNavigation;
		}

		public IEnumerable<IPublishedContent> Items { get; }

		public bool Hide { get; }
	}
}