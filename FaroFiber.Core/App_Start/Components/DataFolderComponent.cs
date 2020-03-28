using FaroFiber.Core.Classes.CamelontaUI;
using FaroFiber.Core.Models.GeneratedModels;
using Umbraco.Core.Composing;
using Umbraco.Core.Events;
using Umbraco.Core.Services;
using Umbraco.Core.Services.Implement;
using Umbraco.Web;
using IContent = Umbraco.Core.Models.IContent;

namespace FaroFiber.Core.Components
{
	public class DataFolderComponent : IComponent
	{
		private readonly IUmbracoContextFactory _context;

		public DataFolderComponent(IUmbracoContextFactory context)
		{
			_context = context;
		}

		public void Initialize()
		{
			ContentService.Saved += ContentService_Saved;
		}

		public void Terminate()
		{
		}

		private void ContentService_Saved(IContentService sender, SaveEventArgs<IContent> e)
		{
			using (var umbracoContext = _context.EnsureUmbracoContext())
			{
				var contentCache = umbracoContext.UmbracoContext.Content;
				//var pageOrganizer = new PageOrganizer();
				//pageOrganizer.MoveToDateFolder(e, sender, contentCache, News.ModelTypeAlias, YearlyNewsContainer.ModelTypeAlias, true);
			}
		}
	}
}