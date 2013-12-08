using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	[XmlInclude(typeof(SolidColor))]
	[XmlInclude(typeof(SplitColor))]
	public abstract class BasicColorEx : List<BasicColorExItem>, ICatalogItem
	{
		public abstract System.Windows.Media.Brush Brush
		{
			get;
		}

		public abstract string Name
		{
			get;
		}

		protected BasicColorEx()
		{
		}
	}
}