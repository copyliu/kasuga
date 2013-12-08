using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;

namespace Kasuga
{
	public class ArrangementLikeJoy : IArrangement, ICatalogItem
	{
		public string Name
		{
			get
			{
				string typeName;
				try
				{
					typeName = ArrangementLikeJoy.TypeName;
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
					empty = "左余白等増加";
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public ArrangementLikeJoy()
		{
		}

		public void Arrange(Page page)
		{
			double num;
			double num1;
			try
			{
				int count = page.Lines.Count;
				if (count > 0)
				{
					Point basePoint = page.BasePoint;
					double usableWidth = page.UsableWidth;
					double defaultAngle = page.DefaultAngle * 3.14159265358979 / 180;
					double distanceToNextLine = page.DistanceToNextLine;
					bool isTopBase = page.ParentalPart.IsTopBase;
					if (count > 1)
					{
						double width = 0;
						for (int i = count - 1; i >= 1; i--)
						{
							Size size = page.Lines[i].Size;
							width = (usableWidth - size.Width) / (double)i;
							if (this.DoLinesGoIntoUsableWidth(page, usableWidth, width))
							{
								break;
							}
						}
						double num2 = 0;
						if (page.Lines[0].Size.Width - width * (double)(count - 1) < page.MinOverlapping)
						{
							Size size1 = page.Lines[0].Size;
							width = (size1.Width - page.MinOverlapping) / (double)(count - 1);
							double num3 = 0;
							for (int j = 0; j < count; j++)
							{
								double num4 = width * (double)j;
								Size size2 = page.Lines[j].Size;
								num3 = Math.Max(num3, num4 + size2.Width);
							}
							num2 = (usableWidth - num3) / 2;
						}
						for (int k = 0; k < count; k++)
						{
							Line item = page.Lines[k];
							num1 = (!isTopBase ? -page.ParentalSub.FontSetCatalog.GetItem(item.DefaultFontSetName).Text.Size - distanceToNextLine * (double)(page.Lines.Count - (k + 1)) : -item.DefaultDistanceToRuby + distanceToNextLine * (double)k);
							item.Arrange(new Point(basePoint.X + (num2 + width * (double)k) * Math.Cos(defaultAngle) + num1 * Math.Sin(defaultAngle), basePoint.Y - (num2 + width * (double)k) * Math.Sin(defaultAngle) + num1 * Math.Cos(defaultAngle)));
						}
					}
					else
					{
						Line line = page.Lines[0];
						double width1 = (usableWidth - line.Size.Width) / 2;
						num = (!isTopBase ? -page.ParentalSub.FontSetCatalog.GetItem(line.DefaultFontSetName).Text.Size : -line.DefaultDistanceToRuby);
						line.Arrange(new Point(basePoint.X + width1 * Math.Cos(defaultAngle) - num * Math.Sin(defaultAngle), basePoint.Y - width1 * Math.Sin(defaultAngle) + num * Math.Cos(defaultAngle)));
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		protected bool DoLinesGoIntoUsableWidth(Page page, double usableWidth, double offsetUnit)
		{
			bool flag;
			try
			{
				int num = 0;
				while (num < page.Lines.Count)
				{
					if (page.Lines[num].Size.Width + offsetUnit * (double)num <= usableWidth)
					{
						num++;
					}
					else
					{
						flag = false;
						return flag;
					}
				}
				flag = true;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}
	}
}