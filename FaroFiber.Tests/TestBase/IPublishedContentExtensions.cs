using Moq;
using Umbraco.Core.Models.PublishedContent;

namespace FaroFiber.Tests.TestBase
{
	internal static class IPublishedContentExtensions
	{
		public static void MockGetProperty<TValue>(this Mock<IPublishedContent> content, string propertyAlias, TValue returnValue)
		{
			var property = UmbracoTestsHelper.GetPublishedPropertyMock(returnValue);
			content.Setup(x => x.GetProperty(propertyAlias)).Returns(property);
		}
	}
}