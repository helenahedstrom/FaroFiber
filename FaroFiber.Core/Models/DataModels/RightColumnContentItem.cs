using System.Web;

namespace FaroFiber.Core.Models.DataModels
{
	public class RightColumnContentItem
	{
		public RightColumnContentItem(IHtmlString text) => this.Text = text?.ToHtmlString() ?? string.Empty;

		public string Text { get; }
	}
}