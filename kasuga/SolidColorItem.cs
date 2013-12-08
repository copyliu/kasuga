using System;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	[Serializable]
	public class SolidColorItem : BasicColorExItem
	{
		public override Kasuga.ColorAlpha ColorAlpha
		{
			get;
			set;
		}

		public SolidColorItem()
		{
			this.ColorAlpha = Kasuga.ColorAlpha.MinValue;
		}

		public SolidColorItem(Kasuga.ColorAlpha colorAlpha)
		{
			this.ColorAlpha = colorAlpha;
		}
	}
}