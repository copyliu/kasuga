using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class SplitColor : BasicColorEx
	{
		[XmlIgnore]
		public override System.Windows.Media.Brush Brush
		{
			get
			{
				System.Windows.Media.Brush linearGradientBrush;
				try
				{
					double widthRatio = 0;
					foreach (SplitColorItem splitColorItem in this)
					{
						widthRatio = widthRatio + splitColorItem.WidthRatio;
					}
					GradientStopCollection gradientStopCollections = new GradientStopCollection();
					double num = 0;
					for (int i = 0; i < base.Count; i++)
					{
						SplitColorItem item = (SplitColorItem)base[i];
						gradientStopCollections.Add(new GradientStop(item.ColorAlpha.Color, num));
						num = num + item.WidthRatio / widthRatio;
						gradientStopCollections.Add(new GradientStop(item.ColorAlpha.Color, num));
					}
					linearGradientBrush = new LinearGradientBrush(gradientStopCollections, 90);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					linearGradientBrush = null;
				}
				return linearGradientBrush;
			}
		}

		public override string Name
		{
			get
			{
				return SplitColor.TypeName;
			}
		}

		public static string TypeName
		{
			get
			{
				return "上下分割";
			}
		}

		public SplitColor()
		{
		}

		public SplitColor(int num)
		{
			try
			{
				for (int i = 0; i < num; i++)
				{
					base.Add(new SplitColorItem());
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}