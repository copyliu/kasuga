using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class Charactor
	{
		public double Angle
		{
			get;
			set;
		}

		[XmlIgnore]
		public Point CenterBottom
		{
			get
			{
				Point rightBottom = this.RightBottom;
				Point leftBottom = this.LeftBottom;
				return new Point((rightBottom.X + leftBottom.X) / 2, (rightBottom.Y + leftBottom.Y) / 2);
			}
			set
			{
				Point centerBottom = this.CenterBottom;
				if (centerBottom != value)
				{
					double x = value.X - centerBottom.X;
					this.Move(x, value.Y - centerBottom.Y);
				}
			}
		}

		[XmlIgnore]
		public Point CenterMiddle
		{
			get
			{
				Point leftTop = this.LeftTop;
				Point rightBottom = this.RightBottom;
				return new Point((leftTop.X + rightBottom.X) / 2, (leftTop.Y + rightBottom.Y) / 2);
			}
			set
			{
				Point centerMiddle = this.CenterMiddle;
				if (centerMiddle != value)
				{
					double x = value.X - centerMiddle.X;
					this.Move(x, value.Y - centerMiddle.Y);
				}
			}
		}

		[XmlIgnore]
		public Point CenterTop
		{
			get
			{
				Point leftTop = this.LeftTop;
				Point rightTop = this.RightTop;
				return new Point((leftTop.X + rightTop.X) / 2, (leftTop.Y + rightTop.Y) / 2);
			}
			set
			{
				Point centerTop = this.CenterTop;
				if (centerTop != value)
				{
					double x = value.X - centerTop.X;
					this.Move(x, value.Y - centerTop.Y);
				}
			}
		}

		public char Char
		{
			get;
			set;
		}

		[XmlIgnore]
		public Kasuga.ColorSet ColorSet
		{
			get
			{
				Kasuga.ColorSet item;
				try
				{
					item = this.ParentalSub.ColorSetCatalog.GetItem(this.ColorSetName);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					item = null;
				}
				return item;
			}
		}

		public string ColorSetName
		{
			get;
			set;
		}

		[XmlIgnore]
		public Kasuga.FontEx FontEx
		{
			get
			{
				Kasuga.FontEx fontEx;
				try
				{
					fontEx = (this.Kind != CharactorKind.Text ? this.FontSet.Ruby : this.FontSet.Text);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					fontEx = null;
				}
				return fontEx;
			}
		}

		[XmlIgnore]
		public Kasuga.FontSet FontSet
		{
			get
			{
				Kasuga.FontSet item;
				try
				{
					item = this.ParentalSub.FontSetCatalog.GetItem(this.FontSetName);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					item = null;
				}
				return item;
			}
		}

		public string FontSetName
		{
			get;
			set;
		}

		[XmlIgnore]
		public System.Windows.Media.FormattedText FormattedText
		{
			get
			{
				FontStyle fontStyle;
				FontWeight fontWeight;
				System.Windows.Media.FormattedText formattedText;
				try
				{
					Kasuga.FontEx fontEx = this.FontEx;
					FontFamily fontFamily = new FontFamily(fontEx.FamilyName);
					fontStyle = (!fontEx.IsItalic ? FontStyles.Normal : FontStyles.Italic);
					fontWeight = (!fontEx.IsBold ? FontWeights.Normal : FontWeights.Bold);
					Typeface typeface = new Typeface(fontFamily, fontStyle, fontWeight, FontStretches.Normal);
					char chr = this.Char;
					formattedText = new System.Windows.Media.FormattedText(chr.ToString(), CultureInfo.InvariantCulture, FlowDirection.LeftToRight, typeface, fontEx.Size, Brushes.Black);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					formattedText = null;
				}
				return formattedText;
			}
		}

		public bool IsSolidSingEnd
		{
			get;
			set;
		}

		public bool IsSolidSingStart
		{
			get;
			set;
		}

		public bool IsWithoutSing
		{
			get;
			set;
		}

		public CharactorKind Kind
		{
			get;
			set;
		}

		[XmlIgnore]
		public Point LeftBottom
		{
			get
			{
				Point point;
				try
				{
					double angle = this.Angle * 3.14159265358979 / 180;
					double x = this.LeftTop.X;
					System.Windows.Size size = this.Size;
					double height = x + size.Height * Math.Sin(angle);
					double y = this.LeftTop.Y;
					System.Windows.Size size1 = this.Size;
					point = new Point(height, y + size1.Height * Math.Cos(angle));
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					point = new Point(0, 0);
				}
				return point;
			}
			set
			{
				try
				{
					Point leftBottom = this.LeftBottom;
					if (leftBottom != value)
					{
						double x = value.X - leftBottom.X;
						this.Move(x, value.Y - leftBottom.Y);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public Point LeftMiddle
		{
			get
			{
				Point leftBottom = this.LeftBottom;
				Point leftTop = this.LeftTop;
				return new Point((leftBottom.X + leftTop.X) / 2, (leftBottom.Y + leftTop.Y) / 2);
			}
			set
			{
				Point leftMiddle = this.LeftMiddle;
				if (leftMiddle != value)
				{
					double x = value.X - leftMiddle.X;
					this.Move(x, value.Y - leftMiddle.Y);
				}
			}
		}

		public Point LeftTop
		{
			get;
			set;
		}

		[XmlIgnore]
		public System.Windows.Size OriginalSize
		{
			get
			{
				System.Windows.Size size;
				try
				{
					System.Windows.Media.FormattedText formattedText = this.FormattedText;
					size = new System.Windows.Size(formattedText.WidthIncludingTrailingWhitespace, formattedText.Height);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					size = System.Windows.Size.Empty;
				}
				return size;
			}
		}

		[XmlIgnore]
		public Line ParentalLine
		{
			get
			{
				Line parentalLine;
				try
				{
					parentalLine = this.ParentalWord.ParentalLine;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					parentalLine = null;
				}
				return parentalLine;
			}
		}

		[XmlIgnore]
		public Page ParentalPage
		{
			get
			{
				Page parentalPage;
				try
				{
					parentalPage = this.ParentalWord.ParentalPage;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					parentalPage = null;
				}
				return parentalPage;
			}
		}

		[XmlIgnore]
		public Part ParentalPart
		{
			get
			{
				Part parentalPart;
				try
				{
					parentalPart = this.ParentalWord.ParentalPart;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					parentalPart = null;
				}
				return parentalPart;
			}
		}

		[XmlIgnore]
		public Sub ParentalSub
		{
			get
			{
				Sub parentalSub;
				try
				{
					parentalSub = this.ParentalWord.ParentalSub;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					parentalSub = null;
				}
				return parentalSub;
			}
		}

		[XmlIgnore]
		public Word ParentalWord
		{
			get;
			set;
		}

		[XmlIgnore]
		public Point RightBottom
		{
			get
			{
				Point point;
				try
				{
					double angle = this.Angle * 3.14159265358979 / 180;
					double x = this.LeftTop.X;
					System.Windows.Size size = this.Size;
					double width = x + size.Width * Math.Cos(angle);
					System.Windows.Size size1 = this.Size;
					double height = width + size1.Height * Math.Sin(angle);
					double y = this.LeftTop.Y;
					System.Windows.Size size2 = this.Size;
					double num = y - size2.Width * Math.Sin(angle);
					System.Windows.Size size3 = this.Size;
					point = new Point(height, num + size3.Height * Math.Cos(angle));
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					point = new Point(0, 0);
				}
				return point;
			}
			set
			{
				try
				{
					Point rightBottom = this.RightBottom;
					if (rightBottom != value)
					{
						double x = value.X - rightBottom.X;
						this.Move(x, value.Y - rightBottom.Y);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public Point RightMiddle
		{
			get
			{
				Point rightTop = this.RightTop;
				Point rightBottom = this.RightBottom;
				return new Point((rightTop.X + rightBottom.X) / 2, (rightTop.Y + rightBottom.Y) / 2);
			}
			set
			{
				Point rightMiddle = this.RightMiddle;
				if (rightMiddle != value)
				{
					double x = value.X - rightMiddle.X;
					this.Move(x, value.Y - rightMiddle.Y);
				}
			}
		}

		[XmlIgnore]
		public Point RightTop
		{
			get
			{
				Point point;
				try
				{
					double angle = this.Angle * 3.14159265358979 / 180;
					double x = this.LeftTop.X;
					System.Windows.Size size = this.Size;
					double width = x + size.Width * Math.Cos(angle);
					double y = this.LeftTop.Y;
					System.Windows.Size size1 = this.Size;
					point = new Point(width, y - size1.Width * Math.Sin(angle));
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					point = new Point(0, 0);
				}
				return point;
			}
			set
			{
				try
				{
					Point rightTop = this.RightTop;
					if (rightTop != value)
					{
						double x = value.X - rightTop.X;
						this.Move(x, value.Y - rightTop.Y);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public PlayTimeSpan SingDuration
		{
			get
			{
				PlayTimeSpan singEnd;
				try
				{
					singEnd = this.SingEnd - this.SingStart;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					singEnd = PlayTimeSpan.Empty;
				}
				return singEnd;
			}
		}

		public PlayTime SingEnd
		{
			get;
			set;
		}

		public PlayTime SingStart
		{
			get;
			set;
		}

		[XmlIgnore]
		public System.Windows.Size Size
		{
			get
			{
				System.Windows.Size size;
				try
				{
					System.Windows.Size originalSize = this.OriginalSize;
					Kasuga.FontEx fontEx = this.FontEx;
					size = new System.Windows.Size(originalSize.Width * fontEx.ScaleX, originalSize.Height * fontEx.ScaleY);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					size = System.Windows.Size.Empty;
				}
				return size;
			}
		}

		[XmlIgnore]
		public PlayTimeSpan ViewDuration
		{
			get
			{
				PlayTimeSpan viewEnd;
				try
				{
					viewEnd = this.ViewEnd - this.ViewStart;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					viewEnd = PlayTimeSpan.Empty;
				}
				return viewEnd;
			}
		}

		public PlayTime ViewEnd
		{
			get;
			set;
		}

		public PlayTime ViewStart
		{
			get;
			set;
		}

		public Charactor()
		{
		}

		public Charactor(Word parentalWord, char charactor, CharactorKind kind, PlayTime singStart, PlayTime singEnd, bool isWithoutSing, double angle, string fontSetName, string colorSetName)
		{
			try
			{
				this.ParentalWord = parentalWord;
				this.Char = charactor;
				this.Kind = kind;
				this.SingStart = singStart;
				this.SingEnd = singEnd;
				this.IsSolidSingStart = !singStart.IsEmpty;
				this.IsSolidSingEnd = !singEnd.IsEmpty;
				this.IsWithoutSing = isWithoutSing;
				this.Angle = angle;
				this.FontSetName = fontSetName;
				this.ColorSetName = colorSetName;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Draw(DrawingContext drawingContext)
		{
			try
			{
				drawingContext.DrawText(this.FormattedText, this.LeftTop);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Initialize(Word parentalWord)
		{
			try
			{
				this.ParentalWord = parentalWord;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Move(double x, double y)
		{
			try
			{
				Point leftTop = this.LeftTop;
				this.LeftTop = new Point(leftTop.X + x, leftTop.Y + y);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}