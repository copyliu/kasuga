using System;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	[XmlInclude(typeof(SolidColorItem))]
	[XmlInclude(typeof(SplitColorItem))]
	public abstract class BasicColorExItem
	{
		public abstract Kasuga.ColorAlpha ColorAlpha
		{
			get;
			set;
		}

		protected BasicColorExItem()
		{
		}
	}
}