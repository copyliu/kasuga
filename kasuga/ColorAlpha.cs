using System;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public struct ColorAlpha
	{
		public static ColorAlpha MinValue;

		private byte _a;

		private byte _b;

		private byte _g;

		private byte _r;

		[XmlAttribute]
		public byte A
		{
			get
			{
				byte num;
				try
				{
					num = this._a;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					this._a = value;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public string AlphaString
		{
			get
			{
				string empty;
				try
				{
					byte a = this.A;
					empty = string.Concat("&H", a.ToString("X2"), "&");
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		[XmlAttribute]
		public byte B
		{
			get
			{
				byte num;
				try
				{
					num = this._b;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					this._b = value;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public System.Windows.Media.Color Color
		{
			get
			{
				System.Windows.Media.Color color;
				try
				{
					color = System.Windows.Media.Color.FromArgb((byte)(255 - this.A), this.R, this.G, this.B);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					color = new System.Windows.Media.Color();
				}
				return color;
			}
		}

		[XmlIgnore]
		public string ColorAlphaString
		{
			get
			{
				string empty;
				try
				{
					string[] str = new string[] { "&H", null, null, null, null, null };
					str[1] = this.A.ToString("X2");
					str[2] = this.B.ToString("X2");
					str[3] = this.G.ToString("X2");
					str[4] = this.R.ToString("X2");
					str[5] = "&";
					empty = string.Concat(str);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		[XmlIgnore]
		public string ColorString
		{
			get
			{
				string empty;
				try
				{
					string[] str = new string[] { "&H", null, null, null, null };
					str[1] = this.B.ToString("X2");
					str[2] = this.G.ToString("X2");
					str[3] = this.R.ToString("X2");
					str[4] = "&";
					empty = string.Concat(str);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		[XmlAttribute]
		public byte G
		{
			get
			{
				byte num;
				try
				{
					num = this._g;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					this._g = value;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public System.Windows.Media.Color OpaqueColor
		{
			get
			{
				System.Windows.Media.Color color;
				try
				{
					color = System.Windows.Media.Color.FromArgb(255, this.R, this.G, this.B);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					color = new System.Windows.Media.Color();
				}
				return color;
			}
		}

		[XmlAttribute]
		public byte R
		{
			get
			{
				byte num;
				try
				{
					num = this._r;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					num = 0;
				}
				return num;
			}
			set
			{
				try
				{
					this._r = value;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public SolidColorBrush SolidBrush
		{
			get
			{
				SolidColorBrush solidColorBrush;
				try
				{
					solidColorBrush = new SolidColorBrush(this.Color);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					solidColorBrush = null;
				}
				return solidColorBrush;
			}
		}

		static ColorAlpha()
		{
			ColorAlpha.MinValue = new ColorAlpha(0, 0, 0, 0);
		}

		public ColorAlpha(byte a, byte b, byte g, byte r)
		{
			try
			{
				this._a = a;
				this._b = b;
				this._g = g;
				this._r = r;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				this._a = 0;
				this._b = 0;
				this._g = 0;
				this._r = 0;
			}
		}

		public override bool Equals(object obj)
		{
			return this.Equals(obj);
		}

		public static ColorAlpha FromColor(System.Windows.Media.Color color)
		{
			ColorAlpha colorAlpha;
			try
			{
				colorAlpha = new ColorAlpha((byte)(255 - color.A), color.B, color.G, color.R);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				colorAlpha = ColorAlpha.MinValue;
			}
			return colorAlpha;
		}

		public static ColorAlpha FromColor(System.Windows.Media.Color color, byte alpha)
		{
			ColorAlpha colorAlpha;
			try
			{
				colorAlpha = new ColorAlpha(alpha, color.B, color.G, color.R);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				colorAlpha = ColorAlpha.MinValue;
			}
			return colorAlpha;
		}

		public static ColorAlpha FromColorAlphaString(string str)
		{
			ColorAlpha colorAlpha;
			try
			{
				Match match = (new Regex("^&H([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})([0-9A-Fa-f]{2})&$")).Match(str);
				if (match.Success)
				{
					byte num = byte.Parse(match.Groups[1].Value, NumberStyles.HexNumber);
					byte num1 = byte.Parse(match.Groups[2].Value, NumberStyles.HexNumber);
					byte num2 = byte.Parse(match.Groups[3].Value, NumberStyles.HexNumber);
					byte num3 = byte.Parse(match.Groups[4].Value, NumberStyles.HexNumber);
					colorAlpha = new ColorAlpha(num, num1, num2, num3);
				}
				else
				{
					colorAlpha = ColorAlpha.MinValue;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				colorAlpha = ColorAlpha.MinValue;
			}
			return colorAlpha;
		}

		public override int GetHashCode()
		{
			return this.GetHashCode();
		}

		public static bool IsColorAlphaString(string str)
		{
			bool success;
			try
			{
				success = (new Regex("^&H[0-9A-Fa-f]{2}[0-9A-Fa-f]{2}[0-9A-Fa-f]{2}[0-9A-Fa-f]{2}&$")).Match(str).Success;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				success = false;
			}
			return success;
		}

		public static bool operator ==(ColorAlpha color1, ColorAlpha color2)
		{
			bool flag;
			try
			{
				flag = (color1.A != color2.A || color1.R != color2.R || color1.G != color2.G ? false : color1.B == color2.B);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator !=(ColorAlpha color1, ColorAlpha color2)
		{
			bool flag;
			try
			{
				flag = (color1.A != color2.A || color1.R != color2.R || color1.G != color2.G ? true : color1.B != color2.B);
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