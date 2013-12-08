using System;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Kasuga
{
	[Serializable]
	public class FontEx
	{
		public double BorderWidth
		{
			get;
			set;
		}

		public string FamilyName
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

		public double ScaleX
		{
			get;
			set;
		}

		public double ScaleY
		{
			get;
			set;
		}

		public double ShadowDepth
		{
			get;
			set;
		}

		public double Size
		{
			get;
			set;
		}

		public FontEx()
		{
		}

		public FontEx(string familyName, double size, bool isBold, bool isItalic, bool hasUnderline, bool hasStrikeout, double scaleX, double scaleY, double borderWidth, double shadowDepth)
		{
			try
			{
				this.FamilyName = familyName;
				this.Size = size;
				this.IsBold = isBold;
				this.IsItalic = isItalic;
				this.HasUnderline = hasUnderline;
				this.HasStrikeout = hasStrikeout;
				this.ScaleX = scaleX;
				this.ScaleY = scaleY;
				this.BorderWidth = borderWidth;
				this.ShadowDepth = shadowDepth;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}