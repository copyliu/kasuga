using System;

namespace Kasuga
{
	public interface IArrangement : ICatalogItem
	{
		void Arrange(Page page);
	}
}