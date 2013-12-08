using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows;

namespace Kasuga
{
	public class Expression
	{
		public Expression()
		{
		}

		protected static string Calculate(string expression, Charactor charactor, AssStyle style)
		{
			double num;
			double num1;
			string str;
			try
			{
				MatchCollection matchCollections = (new Regex("\\((^[\\(\\)]+?)\\)")).Matches(expression);
				if (matchCollections.Count > 0)
				{
					string empty = string.Empty;
					int num2 = 0;
					while (num2 < matchCollections.Count)
					{
						if (num2 > 0)
						{
							int index = matchCollections[num2 - 1].Index + matchCollections[num2 - 1].Length;
							int index1 = matchCollections[num2].Index - index;
							empty = string.Concat(empty, expression.Substring(index, index1));
						}
						else
						{
							empty = string.Concat(empty, expression.Substring(0, matchCollections[num2].Index));
						}
						empty = string.Concat(empty, Kasuga.Expression.Calculate(matchCollections[num2].Groups[1].Value, charactor, style));
						if (num2 < matchCollections.Count - 1)
						{
							num2++;
						}
						else
						{
							empty = string.Concat(empty, expression.Substring(matchCollections[num2].Index + matchCollections[num2].Length));
							break;
						}
					}
					expression = empty;
				}
				expression = Kasuga.Expression.ReplaceInlineVariable(expression, charactor, style);
				while (true)
				{
					Match match = (new Regex("(\\-?\\d+\\.?\\d*)\\s*([\\*\\/\\%]{1})\\s*(\\-?\\d+\\.?\\d*)")).Match(expression);
					if (!match.Success)
					{
						break;
					}
					double num3 = double.Parse(match.Groups[1].Value);
					double num4 = double.Parse(match.Groups[3].Value);
					if (match.Groups[2].Value == "*")
					{
						num = num3 * num4;
					}
					else if (match.Groups[2].Value != "/")
					{
						num = (match.Groups[2].Value != "%" ? 0 : num3 % num4);
					}
					else
					{
						num = num3 / num4;
					}
					string empty1 = string.Empty;
					empty1 = string.Concat(empty1, expression.Substring(0, match.Index));
					empty1 = string.Concat(empty1, " ", num.ToString(), " ");
					empty1 = string.Concat(empty1, expression.Substring(match.Index + match.Length));
					expression = empty1;
				}
				while (true)
				{
					Match match1 = (new Regex("(\\-?\\d+\\.?\\d*)\\s*([\\+\\-]{1})\\s*(\\-?\\d+\\.?\\d*)")).Match(expression);
					if (!match1.Success)
					{
						break;
					}
					double num5 = double.Parse(match1.Groups[1].Value);
					double num6 = double.Parse(match1.Groups[3].Value);
					if (match1.Groups[2].Value != "+")
					{
						num1 = (match1.Groups[2].Value != "-" ? 0 : num5 - num6);
					}
					else
					{
						num1 = num5 + num6;
					}
					string str1 = string.Empty;
					str1 = string.Concat(str1, expression.Substring(0, match1.Index));
					str1 = string.Concat(str1, " ", num1.ToString(), " ");
					str1 = string.Concat(str1, expression.Substring(match1.Index + match1.Length));
					expression = str1;
				}
				str = expression.Replace(" ", string.Empty);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				str = expression;
			}
			return str;
		}

		public static string Convert(string expression, Charactor charactor, AssStyle style)
		{
			string str;
			try
			{
				MatchCollection matchCollections = (new Regex("\\!(.+?)\\!")).Matches(expression);
				if (matchCollections.Count > 0)
				{
					string empty = string.Empty;
					int num = 0;
					while (num < matchCollections.Count)
					{
						if (num > 0)
						{
							int index = matchCollections[num - 1].Index + matchCollections[num - 1].Length;
							int index1 = matchCollections[num].Index - index;
							empty = string.Concat(empty, expression.Substring(index, index1));
						}
						else
						{
							empty = string.Concat(empty, expression.Substring(0, matchCollections[num].Index));
						}
						empty = string.Concat(empty, Kasuga.Expression.Calculate(matchCollections[num].Groups[1].Value, charactor, style));
						if (num < matchCollections.Count - 1)
						{
							num++;
						}
						else
						{
							empty = string.Concat(empty, expression.Substring(matchCollections[num].Index + matchCollections[num].Length));
							break;
						}
					}
					expression = empty;
				}
				str = Kasuga.Expression.ReplaceInlineVariable(expression, charactor, style);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				str = expression;
			}
			return str;
		}

		protected static string ReplaceInlineVariable(string expression, Charactor charactor, AssStyle style)
		{
			string str;
			try
			{
				double width = charactor.ParentalSub.Resolution.Width;
				expression = expression.Replace("$ResWidth", width.ToString());
				double height = charactor.ParentalSub.Resolution.Height;
				expression = expression.Replace("$ResHeight", height.ToString());
				double x = charactor.ParentalPage.BasePoint.X;
				expression = expression.Replace("$BaseX", x.ToString());
				double y = charactor.ParentalPage.BasePoint.Y;
				expression = expression.Replace("$BaseY", y.ToString());
				double usableWidth = charactor.ParentalPage.UsableWidth;
				expression = expression.Replace("$UsageWidth", usableWidth.ToString());
				PlayTimeSpan viewDuration = charactor.ViewDuration;
				double? seconds = charactor.ViewDuration.Seconds;
				double num = Math.Round((double)seconds.Value);
				expression = expression.Replace("$ViewDuration", num.ToString());
				PlayTimeSpan singDuration = charactor.SingDuration;
				double? nullable = charactor.SingDuration.Seconds;
				double num1 = Math.Round((double)nullable.Value);
				expression = expression.Replace("$SingDuration", num1.ToString());
				double width1 = charactor.Size.Width;
				expression = expression.Replace("$Width", width1.ToString());
				double height1 = charactor.Size.Height;
				expression = expression.Replace("$Height", height1.ToString());
				double angle = charactor.Angle;
				expression = expression.Replace("$Angle", angle.ToString());
				double x1 = charactor.LeftTop.X;
				expression = expression.Replace("$LeftTopX", x1.ToString());
				double y1 = charactor.LeftTop.Y;
				expression = expression.Replace("$LeftTopY", y1.ToString());
				double x2 = charactor.CenterTop.X;
				expression = expression.Replace("$CenterTopX", x2.ToString());
				double y2 = charactor.CenterTop.Y;
				expression = expression.Replace("$CenterTopY", y2.ToString());
				double num2 = charactor.RightTop.X;
				expression = expression.Replace("$RightTopX", num2.ToString());
				double y3 = charactor.RightTop.Y;
				expression = expression.Replace("$RightTopY", y3.ToString());
				double x3 = charactor.LeftMiddle.X;
				expression = expression.Replace("$LeftMiddleX", x3.ToString());
				double num3 = charactor.LeftMiddle.Y;
				expression = expression.Replace("$LeftMiddleY", num3.ToString());
				double x4 = charactor.CenterMiddle.X;
				expression = expression.Replace("$CenterMiddleX", x4.ToString());
				double y4 = charactor.CenterMiddle.Y;
				expression = expression.Replace("$CenterMiddleY", y4.ToString());
				double num4 = charactor.RightMiddle.X;
				expression = expression.Replace("$RightMiddleX", num4.ToString());
				double y5 = charactor.RightMiddle.Y;
				expression = expression.Replace("$RightMiddleY", y5.ToString());
				double x5 = charactor.LeftBottom.X;
				expression = expression.Replace("$LeftBottomX", x5.ToString());
				double num5 = charactor.LeftBottom.Y;
				expression = expression.Replace("$LeftBottomY", num5.ToString());
				double x6 = charactor.CenterBottom.X;
				expression = expression.Replace("$CenterBottomX", x6.ToString());
				double y6 = charactor.CenterBottom.Y;
				expression = expression.Replace("$CenterBottomY", y6.ToString());
				double num6 = charactor.RightBottom.X;
				expression = expression.Replace("$RightBottomX", num6.ToString());
				double y7 = charactor.RightBottom.Y;
				expression = expression.Replace("$RightBottomY", y7.ToString());
				if (charactor.Angle == 0)
				{
					double x7 = charactor.LeftTop.X;
					expression = expression.Replace("$Left", x7.ToString());
					width = charactor.CenterTop.X;
					expression = expression.Replace("$Center", width.ToString());
					width = charactor.RightTop.X;
					expression = expression.Replace("$Right", width.ToString());
					width = charactor.LeftTop.Y;
					expression = expression.Replace("$Top", width.ToString());
					width = charactor.LeftMiddle.Y;
					expression = expression.Replace("$Middle", width.ToString());
					width = charactor.LeftBottom.Y;
					expression = expression.Replace("$Bottom", width.ToString());
				}
				expression = expression.Replace("$FontName", style.FontName);
				width = style.FontSize;
				expression = expression.Replace("$FontSize", width.ToString());
				int scaleX = style.ScaleX;
				expression = expression.Replace("$ScaleX", scaleX.ToString());
				scaleX = style.ScaleY;
				expression = expression.Replace("$ScaleY", scaleX.ToString());
				width = style.BorderWidth;
				expression = expression.Replace("$BorderWidth", width.ToString());
				width = style.ShadowDepth;
				expression = expression.Replace("$ShadowDepth", width.ToString());
				ColorAlpha primaryColor = style.PrimaryColor;
				expression = expression.Replace("$PrimaryColor", primaryColor.ColorString);
				primaryColor = style.PrimaryColor;
				expression = expression.Replace("$PrimaryAlpha", primaryColor.AlphaString);
				primaryColor = style.BorderColor;
				expression = expression.Replace("$BorderColor", primaryColor.ColorString);
				primaryColor = style.BorderColor;
				expression = expression.Replace("$BorderAlpha", primaryColor.AlphaString);
				primaryColor = style.ShadowColor;
				expression = expression.Replace("$ShadowColor", primaryColor.ColorString);
				primaryColor = style.ShadowColor;
				expression = expression.Replace("$ShadowAlpha", primaryColor.AlphaString);
				width = 2.71828182845905;
				expression = expression.Replace("$E", width.ToString());
				width = 3.14159265358979;
				expression = expression.Replace("$PI", width.ToString());
				str = expression;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				str = expression;
			}
			return str;
		}
	}
}