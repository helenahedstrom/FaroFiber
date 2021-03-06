﻿using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using FaroFiber.Core.Classes.CamelontaUI;
using Umbraco.Core.Composing;

namespace FaroFiber.Core.Components
{
	public class ApplicationComponent : IComponent
	{
		public void Initialize()
		{
			RegisterBundles(BundleTable.Bundles);
			RegisterRoutes(RouteTable.Routes);
		}

		public void Terminate()
		{
		}

		private void RegisterBundles(BundleCollection bundles)
		{
			// CSS
			const string cssPath = "~/css/";
			var cssFiles = new List<string>
			{
				"vendor/normalize.css", // Should be before base.css
                "vendor/bootstrap.css",
				"vendor/jquery.auto-complete.css", // Stylesheet for search
                
                "Bundled.css",

				"print.css"
			}.Select(cssFile => cssPath + cssFile).ToArray(); // Add CSS-path

			var styleBundle = bundles.GetBundleFor("~/bundles/styles");

			if (styleBundle == null)
			{
				// Always null initially (if no plugin adds files)
				styleBundle = new StyleBundle("~/bundles/styles").Include(cssFiles);
			}
			else
			{
				// If bundle is initialized in a plugin - it's NOT null (like in this case)
				styleBundle.Include(cssFiles);
			}

			styleBundle.Orderer = Bundles.AsIsBundleOrderer;
			bundles.Add(styleBundle);

			// Scripts
			const string scriptsPath = "~/scripts/";
			var jsFiles = new List<string>
			{
				"vendor/jquery-1.11.2.min.js",
				"vendor/modernizr.js",
				"vendor/js-cookie.2.0.js",
				"vendor/jquery.highlight.js", // Script for search
                "vendor/jquery.auto-complete.js", // Script for search
                

                "main.js",
				"nav.js",
				"helper.js",
				"video.js",
				"cookie-warning.js",
				"faq.js",
				"search.js", // Script for search
                "data-uniform-image-height.js"

			}.Select(jsFile => scriptsPath + jsFile).ToArray(); // Add scripts-path;
			var scriptBundle = new ScriptBundle("~/bundles/scripts").Include(jsFiles);
			scriptBundle.Orderer = Bundles.AsIsBundleOrderer;
			bundles.Add(scriptBundle);

			var ltIe9Files = new List<string>
			{
				 "vendor/ltie9/html5shiv.js",
				 "vendor/ltie9/respond.min.js" //Polyfill for media-queries. Needed for the bootstrap grid to function correctly.
            }.Select(jsFile => scriptsPath + jsFile).ToArray();
			bundles.Add(new ScriptBundle("~/bundles/ltIe9Scripts").Include(ltIe9Files));
		}

		public static void RegisterRoutes(RouteCollection routes)
		{
			routes.MapRoute(
				"sitemap.axd", // Route name
				"sitemap.axd", // URL
				new { controller = "Sitemap", action = "Index" }  // Parameter defaults
			);
		}
	}
}