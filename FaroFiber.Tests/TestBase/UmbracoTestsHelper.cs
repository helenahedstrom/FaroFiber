using Moq;
using Umbraco.Core.Models.PublishedContent;

namespace FaroFiber.Tests.TestBase
{
	internal static class UmbracoTestsHelper
	{
		public static IPublishedProperty GetPublishedPropertyMock<T>(T value)
		{
			var mock = new Mock<IPublishedProperty>();
			mock.Setup(l => l.GetValue(It.IsAny<string>(), It.IsAny<string>())).Returns(value);
			mock.Setup(l => l.HasValue(It.IsAny<string>(), It.IsAny<string>())).Returns(true);

			return mock.Object;
		}
	}
}