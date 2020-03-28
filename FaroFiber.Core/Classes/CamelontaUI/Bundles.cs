using System.Configuration;
using System.Web.Optimization;

namespace FaroFiber.Core.Classes.CamelontaUI
{
	public class Bundles
	{
		public static void DisableBundles()
		{
			var disableBundles = ConfigurationManager.AppSettings["disableBundles"] ?? "false";
			if (bool.Parse(disableBundles))
			{
				foreach (var bundle in BundleTable.Bundles)
				{
					bundle.Transforms.Clear();
				}
				BundleTable.EnableOptimizations = false;
			}
			else
			{
				BundleTable.EnableOptimizations = true;
			}
		}

		public static AsIsBundleOrderer AsIsBundleOrderer => new AsIsBundleOrderer();
	}
}
