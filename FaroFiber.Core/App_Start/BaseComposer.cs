using FaroFiber.Core.Components;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace FaroFiber.Core
{
	[RuntimeLevel(MinLevel = RuntimeLevel.Run)]
	public class BaseComposer : IComposer
	{
		public void Compose(Composition composition)
		{
			composition.Components().Append<PreviewComponent>();
			composition.Components().Append<DataFolderComponent>();
			composition.Components().Append<ApplicationComponent>();
		}
	}
}