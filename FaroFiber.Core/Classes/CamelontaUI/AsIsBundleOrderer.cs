using System.Collections.Generic;
using System.Web.Optimization;

namespace FaroFiber.Core.Classes.CamelontaUI
{
	public class AsIsBundleOrderer : IBundleOrderer
	{
		public IEnumerable<BundleFile> OrderFiles(BundleContext context, IEnumerable<BundleFile> files)
		{
			return files;
		}
	}
}
