using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	public class AssStyle
	{
		protected int Alignment
		{
			get
			{
				int horizontalAlignment;
				try
				{
					horizontalAlignment = (int)this.HorizontalAlignment + (int)this.VerticalAlignment;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					horizontalAlignment = 0;
				}
				return horizontalAlignment;
			}
		}

		public double Angle
		{
			get;
			set;
		}

		protected int Bold
		{
			get
			{
				int num;
				try
				{
					num = (!this.IsBold ? 0 : -1);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
		}

		public ColorAlpha BorderColor
		{
			get;
			set;
		}

		public Kasuga.BorderStyle BorderStyle
		{
			get;
			set;
		}

		public double BorderWidth
		{
			get;
			set;
		}

		public FontEncoding Encoding
		{
			get;
			set;
		}

		public string FontName
		{
			get;
			set;
		}

		public double FontSize
		{
			get;
			set;
		}

		public bool HasStrikeout
		{
			get;
			set;
		}

		public bool HasUnderline
		{
			get;
			set;
		}

		public Kasuga.HorizontalAlignment HorizontalAlignment
		{
			get;
			set;
		}

		public bool IsBold
		{
			get;
			set;
		}

		public bool IsItalic
		{
			get;
			set;
		}

		protected int Italic
		{
			get
			{
				int num;
				try
				{
					num = (!this.IsItalic ? 0 : -1);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
		}

		public int LeftMargin
		{
			get;
			set;
		}

		public string Name
		{
			get;
			set;
		}

		public ColorAlpha PrimaryColor
		{
			get;
			set;
		}

		public int RightMargin
		{
			get;
			set;
		}

		public int ScaleX
		{
			get;
			set;
		}

		public int ScaleY
		{
			get;
			set;
		}

		public ColorAlpha SecondaryColor
		{
			get;
			set;
		}

		public ColorAlpha ShadowColor
		{
			get;
			set;
		}

		public double ShadowDepth
		{
			get;
			set;
		}

		public double Spacing
		{
			get;
			set;
		}

		protected int Strikeout
		{
			get
			{
				int num;
				try
				{
					num = (!this.HasStrikeout ? 0 : -1);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
		}

		protected int Underline
		{
			get
			{
				int num;
				try
				{
					num = (!this.HasUnderline ? 0 : -1);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
		}

		public Kasuga.VerticalAlignment VerticalAlignment
		{
			get;
			set;
		}

		public int VerticalMargin
		{
			get;
			set;
		}

		public AssStyle()
		{
		}

		public override bool Equals(object obj)
		{
			bool flag;
			try
			{
				AssStyle assStyle = (AssStyle)obj;
				flag = (!(this.FontName == assStyle.FontName) || this.FontSize != assStyle.FontSize || !(this.PrimaryColor == assStyle.PrimaryColor) || !(this.SecondaryColor == assStyle.SecondaryColor) || !(this.BorderColor == assStyle.BorderColor) || this.IsBold != assStyle.IsBold || this.IsItalic != assStyle.IsItalic || this.HasUnderline != assStyle.HasUnderline || this.HasStrikeout != assStyle.HasStrikeout || this.ScaleX != assStyle.ScaleX || this.ScaleY != assStyle.ScaleY || this.Spacing != assStyle.Spacing || this.Angle != assStyle.Angle || this.BorderStyle != assStyle.BorderStyle || this.BorderWidth != assStyle.BorderWidth || this.ShadowDepth != assStyle.ShadowDepth || this.HorizontalAlignment != assStyle.HorizontalAlignment || this.VerticalAlignment != assStyle.VerticalAlignment || this.LeftMargin != assStyle.LeftMargin || this.RightMargin != assStyle.RightMargin || this.VerticalMargin != assStyle.VerticalMargin ? false : this.Encoding == assStyle.Encoding);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		public override string ToString()
		{
			string empty;
			try
			{
				object[] name = new object[] { "Style: ", this.Name, ",", this.FontName, ",", this.FontSize, ",", this.PrimaryColor.ColorAlphaString, ",", this.SecondaryColor.ColorAlphaString, ",", this.BorderColor.ColorAlphaString, ",", this.ShadowColor.ColorAlphaString, ",", this.Bold.ToString(), ",", this.Italic.ToString(), ",", this.Underline.ToString(), ",", this.Strikeout.ToString(), ",", this.ScaleX.ToString(), ",", this.ScaleY.ToString(), ",", this.Spacing.ToString(), ",", this.Angle.ToString(), ",", this.BorderStyle.ToString(), ",", this.BorderWidth.ToString(), ",", this.ShadowDepth.ToString(), ",", this.Alignment.ToString(), ",", this.LeftMargin.ToString(), ",", this.RightMargin.ToString(), ",", this.VerticalMargin.ToString(), ",", this.Encoding.ToString() };
				empty = string.Concat(name);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				empty = string.Empty;
			}
			return empty;
		}
	}
}