using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace FaroFiber.Core.Models.DataModels
{
	public class MenuItems
	{
		public IPublishedContent CurrentPage { get; set; }

		public IEnumerable<IPublishedContent> Pages { get; set; }

		public string Type { get; set; }

		public int Level { get; set; }
	}
}