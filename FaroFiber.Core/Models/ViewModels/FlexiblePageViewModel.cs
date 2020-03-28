using System.Linq;
using FaroFiber.Core.Classes;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Web;

namespace FaroFiber.Core.Models.ViewModels
{
	public class FlexiblePageViewModel
	{
		public FlexiblePageViewModel(FlexiblePage contentModel)
		{
			this.HasRightColumn = contentModel.RightColumnContent?.Any() == true;
			this.InsideContainer = contentModel.AncestorOrSelf(maxLevel: 2).Children.FilterInvalidPages().Any() && contentModel.HideInLeftNavigation;
		}

		public bool HasRightColumn { get; }

		public bool InsideContainer { get; }
	}
}