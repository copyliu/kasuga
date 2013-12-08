using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class SolidColor : BasicColorEx
	{
		[XmlIgnore]
		public override System.Windows.Media.Brush Brush
		{
			get
			{
				System.Windows.Media.Brush solidColorBrush;
				try
				{
					solidColorBrush = new SolidColorBrush(base[0].ColorAlpha.Color);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					solidColorBrush = null;
				}
				return solidColorBrush;
			}
		}

		public override string Name
		{
			get
			{
				return SolidColor.TypeName;
			}
		}

		public static string TypeName
		{
			get
			{
				return "単色";
			}
		}

		public SolidColor()
		{
		}

		public SolidColor(ColorAlpha colorAlpha)
		{
			try
			{
				base.Add(new SolidColorItem()
				{
					ColorAlpha = colorAlpha
				});
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}