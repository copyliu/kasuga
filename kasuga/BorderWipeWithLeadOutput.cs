using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Kasuga
{
	[Serializable]
	public class BorderWipeWithLeadOutput : BasicOutput
	{
		public override object Detail
		{
			get
			{
				object leadEffects;
				try
				{
					leadEffects = new List<LeadEffect>()
					{
						this.LeadIn,
						this.LeadOut
					};
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					leadEffects = null;
				}
				return leadEffects;
			}
		}

		public LeadEffect LeadIn
		{
			get;
			set;
		}

		public LeadEffect LeadOut
		{
			get;
			set;
		}

		public override string TypeName
		{
			get
			{
				return "リード付き縁ワイプ";
			}
		}

		public BorderWipeWithLeadOutput()
		{
		}

		public BorderWipeWithLeadOutput(string name, LeadEffect leadIn, LeadEffect leadOut)
		{
			try
			{
				base.Name = name;
				this.LeadIn = leadIn;
				this.LeadOut = leadOut;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public override List<AssDialogue> ConvertToAss(Part part, ref List<AssStyle> styles)
		{
			List<AssDialogue> assDialogues;
			try
			{
				foreach (ColorSet colorSetCatalog in part.ParentalSub.ColorSetCatalog)
				{
					if (colorSetCatalog.BorderBeforeColor.Count <= 1 && colorSetCatalog.BorderAfterColor.Count <= 1 && colorSetCatalog.ShadowColor.Count <= 1)
					{
						continue;
					}
					MessageBox.Show("複数色の縁取り、影には対応していません。");
					assDialogues = null;
					return assDialogues;
				}
				foreach (Charactor charactor in part.Charactors)
				{
					if (charactor.Angle == 0)
					{
						continue;
					}
					MessageBox.Show("0°以外の角度には対応していません。");
					assDialogues = null;
					return assDialogues;
				}
				List<AssDialogue> assDialogues1 = new List<AssDialogue>();
				foreach (Line line in part.Lines)
				{
					assDialogues1.AddRange(this.LineCharactorsToDialogues(line.TextCharactors, ref styles));
					assDialogues1.AddRange(this.LineCharactorsToDialogues(line.RubyCharactors, ref styles));
				}
				assDialogues = assDialogues1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				assDialogues = null;
			}
			return assDialogues;
		}

		protected AssDialogue CreateLeadinDialogue(PlayTime start, PlayTime end, AssStyle style, Rect clip, Charactor charactor)
		{
			AssDialogue assDialogue;
			try
			{
				AssDialogue assDialogue1 = new AssDialogue()
				{
					IsComment = false,
					Layer = 0,
					Start = start,
					End = end,
					Style = style.Name,
					Actor = string.Empty,
					LeftMargin = 0,
					RightMargin = 0,
					VerticalMargin = 0,
					Effect = string.Empty
				};
				string[] str = new string[] { Kasuga.Expression.Convert(this.LeadIn.Expression, charactor, style), "{\\clip(", null, null, null, null, null, null, null, null, null };
				str[2] = clip.Left.ToString();
				str[3] = ",";
				str[4] = clip.Top.ToString();
				str[5] = ",";
				str[6] = clip.Right.ToString();
				str[7] = ",";
				str[8] = clip.Bottom.ToString();
				str[9] = ")}";
				str[10] = charactor.Char.ToString();
				assDialogue1.Text = string.Concat(str);
				assDialogue = assDialogue1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				assDialogue = null;
			}
			return assDialogue;
		}

		protected AssDialogue CreateLeadoutDialogue(PlayTime start, PlayTime end, AssStyle style, Rect clip, Charactor charactor)
		{
			AssDialogue assDialogue;
			try
			{
				AssDialogue assDialogue1 = new AssDialogue()
				{
					IsComment = false,
					Layer = 0,
					Start = start,
					End = end,
					Style = style.Name,
					Actor = string.Empty,
					LeftMargin = 0,
					RightMargin = 0,
					VerticalMargin = 0,
					Effect = string.Empty
				};
				string[] str = new string[] { Kasuga.Expression.Convert(this.LeadOut.Expression, charactor, style), "{\\clip(", null, null, null, null, null, null, null, null, null };
				str[2] = clip.Left.ToString();
				str[3] = ",";
				str[4] = clip.Top.ToString();
				str[5] = ",";
				str[6] = clip.Right.ToString();
				str[7] = ",";
				str[8] = clip.Bottom.ToString();
				str[9] = ")}";
				str[10] = charactor.Char.ToString();
				assDialogue1.Text = string.Concat(str);
				assDialogue = assDialogue1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				assDialogue = null;
			}
			return assDialogue;
		}

		protected AssDialogue CreateNonWipedDialogue(PlayTime start, PlayTime end, AssStyle style, Point point, Rect clip, string str)
		{
			AssDialogue assDialogue;
			try
			{
				AssDialogue assDialogue1 = new AssDialogue()
				{
					IsComment = false,
					Layer = 0,
					Start = start,
					End = end,
					Style = style.Name,
					Actor = string.Empty,
					LeftMargin = 0,
					RightMargin = 0,
					VerticalMargin = 0,
					Effect = string.Empty
				};
				string[] strArrays = new string[] { "{\\pos(", point.X.ToString(), ",", point.Y.ToString(), ")}{\\clip(", clip.Left.ToString(), ",", clip.Top.ToString(), ",", clip.Right.ToString(), ",", clip.Bottom.ToString(), ")}", str };
				assDialogue1.Text = string.Concat(strArrays);
				assDialogue = assDialogue1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				assDialogue = null;
			}
			return assDialogue;
		}

		protected AssDialogue CreateWipedDialogue(PlayTime start, PlayTime end, AssStyle style, Point point, Rect clip, double clipStart, double clipStop, bool isAfter, string str)
		{
			AssDialogue assDialogue;
			try
			{
				AssDialogue assDialogue1 = new AssDialogue()
				{
					IsComment = false,
					Layer = 0,
					Start = start,
					End = end,
					Style = style.Name,
					Actor = string.Empty,
					LeftMargin = 0,
					RightMargin = 0,
					VerticalMargin = 0,
					Effect = string.Empty
				};
				if (!isAfter)
				{
					string[] strArrays = new string[] { "{\\pos(", point.X.ToString(), ",", point.Y.ToString(), ")}{\\clip(", clipStart.ToString(), ",", clip.Top.ToString(), ",", clip.Right.ToString(), ",", clip.Bottom.ToString(), ")}{\\t(\\clip(", clipStop.ToString(), ",", clip.Top.ToString(), ",", clip.Right.ToString(), ",", clip.Bottom.ToString(), "))}", str };
					assDialogue1.Text = string.Concat(strArrays);
				}
				else
				{
					string[] strArrays1 = new string[] { "{\\pos(", point.X.ToString(), ",", point.Y.ToString(), ")}{\\clip(", clip.Left.ToString(), ",", clip.Top.ToString(), ",", clipStart.ToString(), ",", clip.Bottom.ToString(), ")}{\\t(\\clip(", clip.Left.ToString(), ",", clip.Top.ToString(), ",", clipStop.ToString(), ",", clip.Bottom.ToString(), "))}", str };
					assDialogue1.Text = string.Concat(strArrays1);
				}
				assDialogue = assDialogue1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				assDialogue = null;
			}
			return assDialogue;
		}

		protected List<AssDialogue> LineCharactorsToDialogues(List<Charactor> charactors, ref List<AssStyle> styles)
		{
			double y;
			double height;
			Charactor item;
			Charactor charactor;
			double widthRatio;
			double borderWidth;
			double x;
			double num;
			double y1;
			double height1;
			double x1;
			double num1;
			List<AssDialogue> assDialogues;
			string[] fontSetName;
			Point leftTop;
			Size resolution;
			char chr;
			try
			{
				List<AssDialogue> assDialogues1 = new List<AssDialogue>();
				for (int i = 0; i < charactors.Count; i++)
				{
					Charactor item1 = charactors[i];
					if (item1.Char != ' ' && item1.Char != '\u3000')
					{
						ColorSet colorSet = item1.ColorSet;
						FontEx fontEx = item1.FontEx;
						Point centerMiddle = item1.CenterMiddle;
						if (!item1.IsWithoutSing)
						{
							if (i < charactors.Count - 1)
							{
								item = charactors[i + 1];
								if (item1.SingEnd != item.SingStart || item1.RightTop.X + fontEx.BorderWidth < item.LeftTop.X - item.FontEx.BorderWidth)
								{
									item = null;
									charactor = null;
								}
								else if (i < charactors.Count - 2)
								{
									charactor = charactors[i + 2];
									if (item.SingEnd != charactor.SingStart || item.RightTop.X + item.FontEx.BorderWidth < charactor.LeftTop.X - charactor.FontEx.BorderWidth)
									{
										charactor = null;
									}
								}
								else
								{
									charactor = null;
								}
							}
							else
							{
								item = null;
								charactor = null;
							}
							for (int j = 0; j < colorSet.InnerBeforeColor.Count; j++)
							{
								AssStyle assStyle = new AssStyle();
								fontSetName = new string[] { "BorderWipe_", item1.FontSetName, "_", item1.Kind.ToString(), "_", item1.ColorSetName, "_Before_", j.ToString() };
								assStyle.Name = string.Concat(fontSetName);
								assStyle.FontName = fontEx.FamilyName;
								assStyle.FontSize = fontEx.Size;
								assStyle.PrimaryColor = colorSet.InnerBeforeColor[j].ColorAlpha;
								assStyle.SecondaryColor = ColorAlpha.MinValue;
								assStyle.BorderColor = colorSet.BorderBeforeColor[0].ColorAlpha;
								assStyle.ShadowColor = colorSet.ShadowColor[0].ColorAlpha;
								assStyle.IsBold = fontEx.IsBold;
								assStyle.IsItalic = fontEx.IsItalic;
								assStyle.HasUnderline = fontEx.HasUnderline;
								assStyle.HasStrikeout = fontEx.HasStrikeout;
								assStyle.ScaleX = (int)Math.Round(fontEx.ScaleX * 100);
								assStyle.ScaleY = (int)Math.Round(fontEx.ScaleY * 100);
								assStyle.Spacing = 0;
								assStyle.Angle = 0;
								assStyle.BorderStyle = BorderStyle.Normal;
								assStyle.BorderWidth = fontEx.BorderWidth;
								assStyle.ShadowDepth = fontEx.ShadowDepth;
								assStyle.HorizontalAlignment = Kasuga.HorizontalAlignment.Center;
								assStyle.VerticalAlignment = Kasuga.VerticalAlignment.Middle;
								assStyle.LeftMargin = 0;
								assStyle.RightMargin = 0;
								assStyle.VerticalMargin = 0;
								assStyle.Encoding = FontEncoding.Default;
								bool flag = false;
								foreach (AssStyle style in styles)
								{
									if (!style.Equals(assStyle))
									{
										continue;
									}
									flag = true;
									assStyle = style;
									break;
								}
								if (!flag)
								{
									styles.Add(assStyle);
								}
								if (colorSet.InnerBeforeColor.GetType() == typeof(SolidColor))
								{
									leftTop = item1.LeftTop;
									widthRatio = leftTop.Y - fontEx.BorderWidth;
									leftTop = item1.LeftBottom;
									borderWidth = leftTop.Y + fontEx.BorderWidth + fontEx.ShadowDepth;
								}
								else if (colorSet.InnerBeforeColor.GetType() != typeof(SplitColor))
								{
									widthRatio = 0;
									resolution = item1.ParentalSub.Resolution;
									borderWidth = resolution.Height;
								}
								else
								{
									widthRatio = item1.LeftTop.Y;
									double height2 = item1.Size.Height;
									double widthRatio1 = 0;
									foreach (SplitColorItem innerBeforeColor in colorSet.InnerBeforeColor)
									{
										widthRatio1 = widthRatio1 + innerBeforeColor.WidthRatio;
									}
									for (int k = 0; k < j; k++)
									{
										widthRatio = widthRatio + height2 * ((SplitColorItem)colorSet.InnerBeforeColor[k]).WidthRatio / widthRatio1;
									}
									borderWidth = widthRatio + height2 * ((SplitColorItem)colorSet.InnerBeforeColor[j]).WidthRatio / widthRatio1;
									if (j <= 0)
									{
										widthRatio = widthRatio - fontEx.BorderWidth;
									}
									if (j >= colorSet.InnerBeforeColor.Count - 1)
									{
										borderWidth = borderWidth + (fontEx.BorderWidth + fontEx.ShadowDepth);
									}
								}
								PlayTime viewStart = (item1.ViewStart + this.LeadIn.Offset) - this.LeadIn.Duration;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTimeSpan = viewStart - new PlayTimeSpan(new double?((leftTop.X + item1.ParentalPage.UsableWidth - centerMiddle.X) / (item1.ParentalPage.UsableWidth * this.LeadIn.Speed)));
								PlayTime playTime = item1.ViewStart + this.LeadIn.Offset;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTimeSpan1 = playTime - new PlayTimeSpan(new double?((leftTop.X + item1.ParentalPage.UsableWidth - centerMiddle.X) / (item1.ParentalPage.UsableWidth * this.LeadIn.Speed)));
								resolution = item1.ParentalSub.Resolution;
								AssDialogue assDialogue = this.CreateLeadinDialogue(playTimeSpan, playTimeSpan1, assStyle, new Rect(0, widthRatio, resolution.Width, borderWidth - widthRatio), item1);
								assDialogues1.Add(assDialogue);
								PlayTime viewStart1 = item1.ViewStart + this.LeadIn.Offset;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTime1 = viewStart1 - new PlayTimeSpan(new double?((leftTop.X + item1.ParentalPage.UsableWidth - centerMiddle.X) / (item1.ParentalPage.UsableWidth * this.LeadIn.Speed)));
								PlayTime singStart = item1.SingStart;
								resolution = item1.ParentalSub.Resolution;
								Rect rect = new Rect(0, widthRatio, resolution.Width, borderWidth - widthRatio);
								chr = item1.Char;
								AssDialogue assDialogue1 = this.CreateNonWipedDialogue(playTime1, singStart, assStyle, centerMiddle, rect, chr.ToString());
								assDialogues1.Add(assDialogue1);
								leftTop = item1.LeftTop;
								double x2 = leftTop.X - fontEx.BorderWidth;
								leftTop = item1.RightTop;
								double num2 = leftTop.X + fontEx.BorderWidth + fontEx.ShadowDepth;
								if (item == null || item.Char == ' ' || item.Char == '\u3000')
								{
									leftTop = item1.RightTop;
									x = leftTop.X + fontEx.BorderWidth;
								}
								else
								{
									leftTop = item.LeftTop;
									x = leftTop.X - item.FontEx.BorderWidth;
								}
								Rect rect1 = new Rect(x2, widthRatio, num2 - x2, borderWidth - widthRatio);
								PlayTime singStart1 = item1.SingStart;
								PlayTime singEnd = item1.SingEnd;
								chr = item1.Char;
								AssDialogue assDialogue2 = this.CreateWipedDialogue(singStart1, singEnd, assStyle, centerMiddle, rect1, x2, x, false, chr.ToString());
								assDialogues1.Add(assDialogue2);
								if (item != null && item.Char != ' ' && item.Char != '\u3000')
								{
									FontEx fontEx1 = item.FontEx;
									leftTop = item1.LeftTop;
									double x3 = leftTop.X - fontEx.BorderWidth;
									leftTop = item.RightTop;
									double num3 = leftTop.X + fontEx1.BorderWidth + fontEx1.ShadowDepth;
									leftTop = item.LeftTop;
									double x4 = leftTop.X - fontEx1.BorderWidth;
									if (charactor != null)
									{
										leftTop = charactor.LeftTop;
										num = leftTop.X - charactor.FontEx.BorderWidth;
									}
									else
									{
										leftTop = item.RightTop;
										num = leftTop.X + fontEx1.BorderWidth;
									}
									Rect rect2 = new Rect(x3, widthRatio, num3 - x3, borderWidth - widthRatio);
									PlayTime singStart2 = item.SingStart;
									PlayTime singEnd1 = item.SingEnd;
									chr = item1.Char;
									AssDialogue assDialogue3 = this.CreateWipedDialogue(singStart2, singEnd1, assStyle, centerMiddle, rect2, x4, num, false, chr.ToString());
									assDialogues1.Add(assDialogue3);
								}
							}
							for (int l = 0; l < colorSet.InnerAfterColor.Count; l++)
							{
								AssStyle familyName = new AssStyle();
								fontSetName = new string[] { "BorderWipe_", item1.FontSetName, "_", item1.Kind.ToString(), "_", item1.ColorSetName, "_After_", l.ToString() };
								familyName.Name = string.Concat(fontSetName);
								familyName.FontName = fontEx.FamilyName;
								familyName.FontSize = fontEx.Size;
								familyName.PrimaryColor = colorSet.InnerAfterColor[l].ColorAlpha;
								familyName.SecondaryColor = ColorAlpha.MinValue;
								familyName.BorderColor = colorSet.BorderAfterColor[0].ColorAlpha;
								familyName.ShadowColor = colorSet.ShadowColor[0].ColorAlpha;
								familyName.IsBold = fontEx.IsBold;
								familyName.IsItalic = fontEx.IsItalic;
								familyName.HasUnderline = fontEx.HasUnderline;
								familyName.HasStrikeout = fontEx.HasStrikeout;
								familyName.ScaleX = (int)Math.Round(fontEx.ScaleX * 100);
								familyName.ScaleY = (int)Math.Round(fontEx.ScaleY * 100);
								familyName.Spacing = 0;
								familyName.Angle = 0;
								familyName.BorderStyle = BorderStyle.Normal;
								familyName.BorderWidth = fontEx.BorderWidth;
								familyName.ShadowDepth = fontEx.ShadowDepth;
								familyName.HorizontalAlignment = Kasuga.HorizontalAlignment.Center;
								familyName.VerticalAlignment = Kasuga.VerticalAlignment.Middle;
								familyName.LeftMargin = 0;
								familyName.RightMargin = 0;
								familyName.VerticalMargin = 0;
								familyName.Encoding = FontEncoding.Default;
								bool flag1 = false;
								foreach (AssStyle style1 in styles)
								{
									if (!style1.Equals(familyName))
									{
										continue;
									}
									flag1 = true;
									familyName = style1;
									break;
								}
								if (!flag1)
								{
									styles.Add(familyName);
								}
								if (colorSet.InnerAfterColor.GetType() == typeof(SolidColor))
								{
									leftTop = item1.LeftTop;
									y1 = leftTop.Y - fontEx.BorderWidth;
									leftTop = item1.LeftBottom;
									height1 = leftTop.Y + fontEx.BorderWidth + fontEx.ShadowDepth;
								}
								else if (colorSet.InnerAfterColor.GetType() != typeof(SplitColor))
								{
									y1 = 0;
									resolution = item1.ParentalSub.Resolution;
									height1 = resolution.Height;
								}
								else
								{
									y1 = item1.LeftTop.Y;
									double height3 = item1.Size.Height;
									double widthRatio2 = 0;
									foreach (SplitColorItem innerAfterColor in colorSet.InnerAfterColor)
									{
										widthRatio2 = widthRatio2 + innerAfterColor.WidthRatio;
									}
									for (int m = 0; m < l; m++)
									{
										y1 = y1 + height3 * ((SplitColorItem)colorSet.InnerAfterColor[m]).WidthRatio / widthRatio2;
									}
									height1 = y1 + height3 * ((SplitColorItem)colorSet.InnerAfterColor[l]).WidthRatio / widthRatio2;
									if (l <= 0)
									{
										y1 = y1 - fontEx.BorderWidth;
									}
									if (l >= colorSet.InnerAfterColor.Count - 1)
									{
										height1 = height1 + (fontEx.BorderWidth + fontEx.ShadowDepth);
									}
								}
								leftTop = item1.LeftTop;
								double num4 = leftTop.X - fontEx.BorderWidth;
								leftTop = item1.RightTop;
								double x5 = leftTop.X + fontEx.BorderWidth + fontEx.ShadowDepth;
								if (item == null || item.Char == ' ' || item.Char == '\u3000')
								{
									leftTop = item1.RightTop;
									x1 = leftTop.X + fontEx.BorderWidth;
								}
								else
								{
									leftTop = item.LeftTop;
									x1 = leftTop.X - item.FontEx.BorderWidth;
								}
								Rect rect3 = new Rect(num4, y1, x5 - num4, height1 - y1);
								PlayTime playTime2 = item1.SingStart;
								PlayTime singEnd2 = item1.SingEnd;
								chr = item1.Char;
								AssDialogue assDialogue4 = this.CreateWipedDialogue(playTime2, singEnd2, familyName, centerMiddle, rect3, num4, x1, true, chr.ToString());
								assDialogues1.Add(assDialogue4);
								if (item == null || item.Char == ' ' || item.Char == '\u3000')
								{
									PlayTime singEnd3 = item1.SingEnd;
									PlayTime viewEnd = item1.ViewEnd + this.LeadOut.Offset;
									double num5 = centerMiddle.X;
									leftTop = item1.ParentalPage.BasePoint;
									PlayTime playTimeSpan2 = viewEnd + new PlayTimeSpan(new double?((num5 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
									resolution = item1.ParentalSub.Resolution;
									Rect rect4 = new Rect(0, y1, resolution.Width, height1 - y1);
									chr = item1.Char;
									AssDialogue assDialogue5 = this.CreateNonWipedDialogue(singEnd3, playTimeSpan2, familyName, centerMiddle, rect4, chr.ToString());
									assDialogues1.Add(assDialogue5);
								}
								else
								{
									FontEx fontEx2 = item.FontEx;
									leftTop = item1.LeftTop;
									double x6 = leftTop.X - fontEx.BorderWidth;
									leftTop = item.RightTop;
									double num6 = leftTop.X + fontEx2.BorderWidth + fontEx2.ShadowDepth;
									leftTop = item.LeftTop;
									double x7 = leftTop.X - fontEx2.BorderWidth;
									if (charactor != null)
									{
										leftTop = charactor.LeftTop;
										num1 = leftTop.X - charactor.FontEx.BorderWidth;
									}
									else
									{
										leftTop = item.RightTop;
										num1 = leftTop.X + fontEx2.BorderWidth;
									}
									Rect rect5 = new Rect(x6, y1, num6 - x6, height1 - y1);
									PlayTime singStart3 = item.SingStart;
									PlayTime playTime3 = item.SingEnd;
									chr = item1.Char;
									AssDialogue assDialogue6 = this.CreateWipedDialogue(singStart3, playTime3, familyName, centerMiddle, rect5, x7, num1, true, chr.ToString());
									assDialogues1.Add(assDialogue6);
									PlayTime singEnd4 = item.SingEnd;
									PlayTime viewEnd1 = item1.ViewEnd + this.LeadOut.Offset;
									double num7 = centerMiddle.X;
									leftTop = item1.ParentalPage.BasePoint;
									PlayTime playTimeSpan3 = viewEnd1 + new PlayTimeSpan(new double?((num7 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
									resolution = item1.ParentalSub.Resolution;
									Rect rect6 = new Rect(0, y1, resolution.Width, height1 - y1);
									chr = item1.Char;
									AssDialogue assDialogue7 = this.CreateNonWipedDialogue(singEnd4, playTimeSpan3, familyName, centerMiddle, rect6, chr.ToString());
									assDialogues1.Add(assDialogue7);
								}
								PlayTime viewEnd2 = item1.ViewEnd + this.LeadOut.Offset;
								double x8 = centerMiddle.X;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTimeSpan4 = viewEnd2 + new PlayTimeSpan(new double?((x8 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
								PlayTime viewEnd3 = (item1.ViewEnd + this.LeadOut.Offset) + this.LeadOut.Duration;
								double num8 = centerMiddle.X;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTime4 = viewEnd3 + new PlayTimeSpan(new double?((num8 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
								resolution = item1.ParentalSub.Resolution;
								AssDialogue assDialogue8 = this.CreateLeadoutDialogue(playTimeSpan4, playTime4, familyName, new Rect(0, y1, resolution.Width, height1 - y1), item1);
								assDialogues1.Add(assDialogue8);
							}
						}
						else
						{
							for (int n = 0; n < colorSet.InnerAfterColor.Count; n++)
							{
								AssStyle size = new AssStyle();
								fontSetName = new string[] { "BorderWipe_", item1.FontSetName, "_", item1.Kind.ToString(), "_", item1.ColorSetName, "_After_", n.ToString() };
								size.Name = string.Concat(fontSetName);
								size.FontName = fontEx.FamilyName;
								size.FontSize = fontEx.Size;
								size.PrimaryColor = colorSet.InnerAfterColor[n].ColorAlpha;
								size.SecondaryColor = ColorAlpha.MinValue;
								size.BorderColor = colorSet.BorderAfterColor[0].ColorAlpha;
								size.ShadowColor = colorSet.ShadowColor[0].ColorAlpha;
								size.IsBold = fontEx.IsBold;
								size.IsItalic = fontEx.IsItalic;
								size.HasUnderline = fontEx.HasUnderline;
								size.HasStrikeout = fontEx.HasStrikeout;
								size.ScaleX = (int)Math.Round(fontEx.ScaleX * 100);
								size.ScaleY = (int)Math.Round(fontEx.ScaleY * 100);
								size.Spacing = 0;
								size.Angle = 0;
								size.BorderStyle = BorderStyle.Normal;
								size.BorderWidth = fontEx.BorderWidth;
								size.ShadowDepth = fontEx.ShadowDepth;
								size.HorizontalAlignment = Kasuga.HorizontalAlignment.Center;
								size.VerticalAlignment = Kasuga.VerticalAlignment.Middle;
								size.LeftMargin = 0;
								size.RightMargin = 0;
								size.VerticalMargin = 0;
								size.Encoding = FontEncoding.Default;
								bool flag2 = false;
								foreach (AssStyle assStyle1 in styles)
								{
									if (!assStyle1.Equals(size))
									{
										continue;
									}
									flag2 = true;
									size = assStyle1;
									break;
								}
								if (!flag2)
								{
									styles.Add(size);
								}
								if (colorSet.InnerAfterColor.GetType() == typeof(SolidColor))
								{
									leftTop = item1.LeftTop;
									y = leftTop.Y - fontEx.BorderWidth;
									leftTop = item1.LeftBottom;
									height = leftTop.Y + fontEx.BorderWidth + fontEx.ShadowDepth;
								}
								else if (colorSet.InnerAfterColor.GetType() != typeof(SplitColor))
								{
									y = 0;
									resolution = item1.ParentalSub.Resolution;
									height = resolution.Height;
								}
								else
								{
									y = item1.LeftTop.Y;
									double height4 = item1.Size.Height;
									double widthRatio3 = 0;
									foreach (SplitColorItem splitColorItem in colorSet.InnerAfterColor)
									{
										widthRatio3 = widthRatio3 + splitColorItem.WidthRatio;
									}
									for (int o = 0; o < n; o++)
									{
										y = y + height4 * ((SplitColorItem)colorSet.InnerAfterColor[o]).WidthRatio / widthRatio3;
									}
									height = y + height4 * ((SplitColorItem)colorSet.InnerAfterColor[n]).WidthRatio / widthRatio3;
									if (n <= 0)
									{
										y = y - fontEx.BorderWidth;
									}
									if (n >= colorSet.InnerAfterColor.Count - 1)
									{
										height = height + (fontEx.BorderWidth + fontEx.ShadowDepth);
									}
								}
								PlayTime viewStart2 = (item1.ViewStart + this.LeadIn.Offset) - this.LeadIn.Duration;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTimeSpan5 = viewStart2 - new PlayTimeSpan(new double?((leftTop.X + item1.ParentalPage.UsableWidth - centerMiddle.X) / (item1.ParentalPage.UsableWidth * this.LeadIn.Speed)));
								PlayTime viewStart3 = item1.ViewStart + this.LeadIn.Offset;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTime5 = viewStart3 - new PlayTimeSpan(new double?((leftTop.X + item1.ParentalPage.UsableWidth - centerMiddle.X) / (item1.ParentalPage.UsableWidth * this.LeadIn.Speed)));
								resolution = item1.ParentalSub.Resolution;
								AssDialogue assDialogue9 = this.CreateLeadinDialogue(playTimeSpan5, playTime5, size, new Rect(0, y, resolution.Width, height - y), item1);
								assDialogues1.Add(assDialogue9);
								PlayTime viewStart4 = item1.ViewStart + this.LeadIn.Offset;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTimeSpan6 = viewStart4 - new PlayTimeSpan(new double?((leftTop.X + item1.ParentalPage.UsableWidth - centerMiddle.X) / (item1.ParentalPage.UsableWidth * this.LeadIn.Speed)));
								PlayTime viewEnd4 = item1.ViewEnd + this.LeadOut.Offset;
								double x9 = centerMiddle.X;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTime6 = viewEnd4 + new PlayTimeSpan(new double?((x9 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
								resolution = item1.ParentalSub.Resolution;
								Rect rect7 = new Rect(0, y, resolution.Width, height - y);
								chr = item1.Char;
								AssDialogue assDialogue10 = this.CreateNonWipedDialogue(playTimeSpan6, playTime6, size, centerMiddle, rect7, chr.ToString());
								assDialogues1.Add(assDialogue10);
								PlayTime viewEnd5 = item1.ViewEnd + this.LeadOut.Offset;
								double num9 = centerMiddle.X;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTimeSpan7 = viewEnd5 + new PlayTimeSpan(new double?((num9 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
								PlayTime viewEnd6 = (item1.ViewEnd + this.LeadOut.Offset) + this.LeadOut.Duration;
								double x10 = centerMiddle.X;
								leftTop = item1.ParentalPage.BasePoint;
								PlayTime playTime7 = viewEnd6 + new PlayTimeSpan(new double?((x10 - leftTop.X) / (item1.ParentalPage.UsableWidth * this.LeadOut.Speed)));
								resolution = item1.ParentalSub.Resolution;
								AssDialogue assDialogue11 = this.CreateLeadoutDialogue(playTimeSpan7, playTime7, size, new Rect(0, y, resolution.Width, height - y), item1);
								assDialogues1.Add(assDialogue11);
							}
						}
					}
				}
				assDialogues = assDialogues1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				assDialogues = null;
			}
			return assDialogues;
		}
	}
}