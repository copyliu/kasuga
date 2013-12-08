using System;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	[Serializable]
	public class SplitColorItem : SolidColorItem
	{
		public double WidthRatio
		{
			get;
			set;
		}

		public SplitColorItem()
		{
			this.WidthRatio = 1;
		}

		public SplitColorItem(Kasuga.ColorAlpha colorAlpha) : base(colorAlpha)
		{
			this.WidthRatio = 1;
		}

		public SplitColorItem(Kasuga.ColorAlpha colorAlpha, double widthRatio) : base(colorAlpha)
		{
			this.WidthRatio = widthRatio;
		}
	}
}