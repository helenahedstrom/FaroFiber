using System.Collections.Generic;
using System.Linq;
using Examine;

namespace FaroFiber.Core.Classes.Search
{
	public class CamelontaSearch
	{
		public List<ISearchResult> Search(string query, int skip = 0, int take = 20)
		{
			if (!string.IsNullOrEmpty(query))
			{
				var externalIndex = ExamineManager.Instance.Indexes.FirstOrDefault(x => x.Name == "ExternalIndex");

				if (externalIndex != null)
				{
					var searcher = externalIndex.GetSearcher();

					return searcher.Search(query).ToList();
				}
			}

			return null;
		}
	}
}