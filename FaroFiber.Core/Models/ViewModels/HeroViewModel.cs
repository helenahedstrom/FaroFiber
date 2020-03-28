using FaroFiber.Core.Models.DataModels;
using FaroFiber.Core.Models.GeneratedModels;

namespace FaroFiber.Core.Models.ViewModels
{
	public class HeroViewModel
	{
		public HeroViewModel(ILayout contentModel)
		{
			if (contentModel.HeroImage != null)
			{
				this.Hero = new Hero
				{
					Image = contentModel.HeroImage.Url,
					Text = contentModel.HeroText?.ToHtmlString() ?? string.Empty
				};
			}
		}

		public Hero Hero { get; }
	}
}