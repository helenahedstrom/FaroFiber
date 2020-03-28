using Umbraco.Core.Composing;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Trees;

namespace FaroFiber.Core.Components
{
	public class PreviewComponent : IComponent
	{
		public void Initialize()
		{
			TreeControllerBase.MenuRendering += TreeControllerBase_MenuRendering;
		}

		public void Terminate()
		{
		}

		private void TreeControllerBase_MenuRendering(TreeControllerBase sender, MenuRenderingEventArgs e)
		{
			if (sender.TreeAlias != "content")
			{
				return;
			}

			var url = "preview/?id=" + e.NodeId;
			var m = new MenuItem()
			{
				Name = "Preview",
				Icon = "eye",
				SeparatorBefore = true
			};

			m.ExecuteJsMethod("top.window.open(' " + url + "', 'preview');");
			e.Menu.Items.Insert(2, m);
		}
	}
}
