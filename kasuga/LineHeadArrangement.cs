using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace Kasuga
{
	public class LineHeadArrangement : IArrangement, ICatalogItem
	{
		public string Name
		{
			get
			{
				string typeName;
				try
				{
					typeName = LineHeadArrangement.TypeName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					typeName = string.Empty;
				}
				return typeName;
			}
		}

		public static string TypeName
		{
			get
			{
				string empty;
				try
				{
					empty = "行頭揃え";
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public LineHeadArrangement()
		{
		}

		public void Arrange(Page page)
		{
			try
			{
				int count = page.Lines.Count;
				if (count > 0)
				{
					Point basePoint = page.BasePoint;
					double defaultAngle = page.DefaultAngle * 3.14159265358979 / 180;
					double distanceToNextLine = page.DistanceToNextLine;
					if (!page.ParentalPart.IsTopBase)
					{
						for (int i = count - 1; i >= 0; i--)
						{
							Line item = page.Lines[i];
							double size = -page.ParentalSub.FontSetCatalog.GetItem(item.DefaultFontSetName).Text.Size - distanceToNextLine * (double)(page.Lines.Count - (i + 1));
							item.Arrange(new Point(basePoint.X + size * Math.Sin(defaultAngle), basePoint.Y + size * Math.Cos(defaultAngle)));
						}
					}
					else
					{
						for (int j = 0; j < count; j++)
						{
							Line line = page.Lines[j];
							double defaultDistanceToRuby = -line.DefaultDistanceToRuby + distanceToNextLine * (double)j;
							line.Arrange(new Point(basePoint.X + defaultDistanceToRuby * Math.Sin(defaultAngle), basePoint.Y + defaultDistanceToRuby * Math.Cos(defaultAngle)));
						}
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}