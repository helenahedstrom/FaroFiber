//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.1.0
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder;
using Umbraco.ModelsBuilder.Umbraco;

namespace FaroFiber.Core.Models.GeneratedModels
{
	/// <summary>Search</summary>
	[PublishedModel("search")]
	public partial class Search : PublishedContentModel, ILayout
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const string ModelTypeAlias = "search";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<Search, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public Search(IPublishedContent content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Disallow Search Engine Navigation: Prevents search engines to follow links from the page.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("disallowSearchEngineNavigation")]
		public bool DisallowSearchEngineNavigation => Layout.GetDisallowSearchEngineNavigation(this);

		///<summary>
		/// Disallow Search Engine To Index Page: Prevent page from appearing in search engine results.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("disallowSearchEngineToIndexPage")]
		public bool DisallowSearchEngineToIndexPage => Layout.GetDisallowSearchEngineToIndexPage(this);

		///<summary>
		/// Image
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("heroImage")]
		public IPublishedContent HeroImage => Layout.GetHeroImage(this);

		///<summary>
		/// Text
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("heroText")]
		public IHtmlString HeroText => Layout.GetHeroText(this);

		///<summary>
		/// Hide In Left Navigation
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("hideInLeftNavigation")]
		public bool HideInLeftNavigation => Layout.GetHideInLeftNavigation(this);

		///<summary>
		/// Image For Social Media Sharing: 1200 x 630
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("imageForSocialMediaSharing")]
		public IPublishedContent ImageForSocialMediaSharing => Layout.GetImageForSocialMediaSharing(this);

		///<summary>
		/// Description: This description is included in link lists and on Google search results.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("metaDescription")]
		public string MetaDescription => Layout.GetMetaDescription(this);

		///<summary>
		/// Navigation Name: Use this name for the page in the navigation.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("navigationName")]
		public string NavigationName => Layout.GetNavigationName(this);

		///<summary>
		/// Page Alias: Another URL to the page. Multiple URLs are separated by commas.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("pageAlias")]
		public string PageAlias => Layout.GetPageAlias(this);

		///<summary>
		/// Page Script: This script is rendered at the end of the body tag. Include your own script tags.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("pageScript")]
		public string PageScript => Layout.GetPageScript(this);

		///<summary>
		/// Page URL: Alternative page name. Alters the last part of the URL.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("pageUrl")]
		public string PageUrl => Layout.GetPageUrl(this);

		///<summary>
		/// Hide In Navigation: The page can be accessed but is not displayed in the navigation.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("umbracoNaviHide")]
		public bool UmbracoNaviHide => Layout.GetUmbracoNaviHide(this);

		///<summary>
		/// Window Title And Social Media Header: Enter something short and compelling about the content. Is used as a header when sharing on Social Media.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.1.0")]
		[ImplementPropertyType("windowTitleAndSocialMediaHeader")]
		public string WindowTitleAndSocialMediaHeader => Layout.GetWindowTitleAndSocialMediaHeader(this);
	}
}
