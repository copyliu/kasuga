using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class Word
	{
		[XmlIgnore]
		public double? Angle
		{
			get
			{
				double? nullable;
				try
				{
					double angle = this.TextCharactors[0].Angle;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						if (angle == textCharactor.Angle)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						if (angle == rubyCharactor.Angle)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new double?(angle);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					nullable = null;
				}
				return nullable;
			}
			set
			{
				try
				{
					double? angle = this.Angle;
					double? nullable = value;
					if (((double)angle.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : angle.HasValue != nullable.HasValue) && value.HasValue)
					{
						double num = (double)value.Value;
						this.DefaultAngle = num;
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							textCharactor.Angle = num;
						}
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							rubyCharactor.Angle = num;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public List<Charactor> Charactors
		{
			get
			{
				List<Charactor> charactors;
				try
				{
					List<Charactor> charactors1 = new List<Charactor>();
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						charactors1.Add(textCharactor);
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						charactors1.Add(rubyCharactor);
					}
					charactors = charactors1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					charactors = null;
				}
				return charactors;
			}
		}

		[XmlIgnore]
		public string ColorSetName
		{
			get
			{
				string empty;
				try
				{
					string colorSetName = this.TextCharactors[0].ColorSetName;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						if (colorSetName == textCharactor.ColorSetName)
						{
							continue;
						}
						empty = string.Empty;
						return empty;
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						if (colorSetName == rubyCharactor.ColorSetName)
						{
							continue;
						}
						empty = string.Empty;
						return empty;
					}
					empty = colorSetName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this.ColorSetName != value && value != string.Empty)
					{
						this.DefaultColorSetName = value;
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							textCharactor.ColorSetName = value;
						}
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							rubyCharactor.ColorSetName = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public double DefaultAngle
		{
			get;
			set;
		}

		public string DefaultColorSetName
		{
			get;
			set;
		}

		public string DefaultFontSetName
		{
			get;
			set;
		}

		public double DistanceToRuby
		{
			get;
			set;
		}

		[XmlIgnore]
		public PlayTime FirstSingStart
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime singStart = this.TextCharactors[0].SingStart;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						singStart = PlayTime.Min(singStart, textCharactor.SingStart);
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						singStart = PlayTime.Min(singStart, rubyCharactor.SingStart);
					}
					empty = singStart;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = PlayTime.Empty;
				}
				return empty;
			}
		}

		[XmlIgnore]
		public string FontSetName
		{
			get
			{
				string empty;
				try
				{
					string fontSetName = this.TextCharactors[0].FontSetName;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						if (fontSetName == textCharactor.FontSetName)
						{
							continue;
						}
						empty = string.Empty;
						return empty;
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						if (fontSetName == rubyCharactor.FontSetName)
						{
							continue;
						}
						empty = string.Empty;
						return empty;
					}
					empty = fontSetName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this.FontSetName != value && value != string.Empty)
					{
						this.DefaultFontSetName = value;
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							textCharactor.FontSetName = value;
						}
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							rubyCharactor.FontSetName = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsDefaultWithoutSing
		{
			get;
			set;
		}

		public bool IsLikeUgaWord
		{
			get;
			set;
		}

		public bool IsSpacingEnabled
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool? IsWithoutSing
		{
			get
			{
				bool? nullable;
				try
				{
					bool isWithoutSing = this.TextCharactors[0].IsWithoutSing;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						if (isWithoutSing == textCharactor.IsWithoutSing)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						if (isWithoutSing == rubyCharactor.IsWithoutSing)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new bool?(isWithoutSing);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					nullable = null;
				}
				return nullable;
			}
			set
			{
				try
				{
					bool? isWithoutSing = this.IsWithoutSing;
					bool? nullable = value;
					if ((isWithoutSing.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isWithoutSing.HasValue != nullable.HasValue) && value.HasValue)
					{
						bool flag = value.Value;
						this.IsDefaultWithoutSing = flag;
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							textCharactor.IsWithoutSing = flag;
						}
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							rubyCharactor.IsWithoutSing = flag;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public PlayTime LastSingEnd
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime singEnd = this.TextCharactors[0].SingEnd;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						singEnd = PlayTime.Max(singEnd, textCharactor.SingEnd);
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						singEnd = PlayTime.Max(singEnd, rubyCharactor.SingEnd);
					}
					empty = singEnd;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = PlayTime.Empty;
				}
				return empty;
			}
		}

		[XmlIgnore]
		public Line ParentalLine
		{
			get;
			set;
		}

		[XmlIgnore]
		public Page ParentalPage
		{
			get
			{
				Page parentalPage;
				try
				{
					parentalPage = this.ParentalLine.ParentalPage;
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
					parentalPart = this.ParentalLine.ParentalPart;
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
					parentalSub = this.ParentalLine.ParentalSub;
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
		public string Ruby
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					for (int i = 0; i < this.RubyCharactors.Count; i++)
					{
						char chr = this.RubyCharactors[i].Char;
						str = string.Concat(str, chr.ToString());
					}
					empty = str;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public List<Charactor> RubyCharactors
		{
			get;
			set;
		}

		[XmlIgnore]
		protected Size RubySize
		{
			get
			{
				Size size;
				try
				{
					if (this.RubyCharactors.Count > 0)
					{
						double width = 0;
						double num = 0;
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							Size size1 = rubyCharactor.Size;
							width = width + size1.Width;
							num = Math.Max(num, size1.Height);
						}
						size = new Size(width, num);
					}
					else
					{
						size = Size.Empty;
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					size = Size.Empty;
				}
				return size;
			}
		}

		[XmlIgnore]
		public string Text
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					for (int i = 0; i < this.TextCharactors.Count; i++)
					{
						char chr = this.TextCharactors[i].Char;
						str = string.Concat(str, chr.ToString());
					}
					empty = str;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public List<Charactor> TextCharactors
		{
			get;
			set;
		}

		[XmlIgnore]
		public Size TextSize
		{
			get
			{
				Size size;
				try
				{
					if (this.TextCharactors.Count > 0)
					{
						double width = 0;
						double num = 0;
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							Size size1 = textCharactor.Size;
							width = width + size1.Width;
							num = Math.Max(num, size1.Height);
						}
						size = new Size(width, num);
					}
					else
					{
						size = Size.Empty;
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					size = Size.Empty;
				}
				return size;
			}
		}

		[XmlIgnore]
		public string TimeTaggedRuby
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					PlayTime singEnd = PlayTime.Empty;
					for (int i = 0; i < this.RubyCharactors.Count; i++)
					{
						Charactor item = this.RubyCharactors[i];
						if (item.SingStart != singEnd && item.IsSolidSingStart)
						{
							str = string.Concat(str, item.SingStart.TimeTag);
						}
						char chr = item.Char;
						str = string.Concat(str, chr.ToString());
						if (item.IsSolidSingEnd)
						{
							str = string.Concat(str, item.SingEnd.TimeTag);
						}
						singEnd = item.SingEnd;
					}
					empty = str;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				PlayTime empty;
				PlayTime playTime;
				try
				{
					if (this.TimeTaggedRuby != value)
					{
						this.RubyCharactors.Clear();
						int length = 0;
						while (length < value.Length)
						{
							Match match = PlayTime.HeadTimeTagRegex.Match(value.Substring(length));
							if (!match.Success)
							{
								empty = PlayTime.Empty;
							}
							else
							{
								empty = PlayTime.FromTimeTag(match.Value);
								length = length + match.Length;
							}
							if (length >= value.Length)
							{
								continue;
							}
							match = PlayTime.HeadTimeTagRegex.Match(value.Substring(length));
							if (match.Success)
							{
								continue;
							}
							char charArray = value.Substring(length, 1).ToCharArray()[0];
							length++;
							if (length >= value.Length)
							{
								playTime = PlayTime.Empty;
							}
							else
							{
								match = PlayTime.HeadTimeTagRegex.Match(value.Substring(length));
								playTime = (!match.Success ? PlayTime.Empty : PlayTime.FromTimeTag(match.Value));
							}
							Charactor charactor = new Charactor(this, charArray, CharactorKind.Ruby, empty, playTime, this.IsDefaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName);
							this.RubyCharactors.Add(charactor);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public string TimeTaggedText
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					PlayTime singEnd = PlayTime.Empty;
					for (int i = 0; i < this.TextCharactors.Count; i++)
					{
						Charactor item = this.TextCharactors[i];
						if (item.SingStart != singEnd && item.IsSolidSingStart)
						{
							str = string.Concat(str, item.SingStart.TimeTag);
						}
						char chr = item.Char;
						str = string.Concat(str, chr.ToString());
						if (item.IsSolidSingEnd)
						{
							str = string.Concat(str, item.SingEnd.TimeTag);
						}
						singEnd = item.SingEnd;
					}
					empty = str;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
			set
			{
				PlayTime empty;
				PlayTime playTime;
				try
				{
					if (this.TimeTaggedText != value)
					{
						this.TextCharactors.Clear();
						int length = 0;
						while (length < value.Length)
						{
							Match match = PlayTime.HeadTimeTagRegex.Match(value.Substring(length));
							if (!match.Success)
							{
								empty = PlayTime.Empty;
							}
							else
							{
								empty = PlayTime.FromTimeTag(match.Value);
								length = length + match.Length;
							}
							if (length >= value.Length)
							{
								continue;
							}
							match = PlayTime.HeadTimeTagRegex.Match(value.Substring(length));
							if (match.Success)
							{
								continue;
							}
							char charArray = value.Substring(length, 1).ToCharArray()[0];
							length++;
							if (length >= value.Length)
							{
								playTime = PlayTime.Empty;
							}
							else
							{
								match = PlayTime.HeadTimeTagRegex.Match(value.Substring(length));
								playTime = (!match.Success ? PlayTime.Empty : PlayTime.FromTimeTag(match.Value));
							}
							Charactor charactor = new Charactor(this, charArray, CharactorKind.Text, empty, playTime, this.IsDefaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName);
							this.TextCharactors.Add(charactor);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public string TimeTaggedWord
		{
			get
			{
				string timeTaggedText;
				try
				{
					if (this.RubyCharactors.Count <= 0)
					{
						timeTaggedText = this.TimeTaggedText;
					}
					else
					{
						string[] strArrays = new string[] { "{", this.TimeTaggedText, "|", this.TimeTaggedRuby, "}" };
						timeTaggedText = string.Concat(strArrays);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					timeTaggedText = string.Empty;
				}
				return timeTaggedText;
			}
		}

		[XmlIgnore]
		public PlayTime ViewEnd
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime viewEnd = this.TextCharactors[0].ViewEnd;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						if (viewEnd == textCharactor.ViewEnd)
						{
							continue;
						}
						empty = PlayTime.Empty;
						return empty;
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						if (viewEnd == rubyCharactor.ViewEnd)
						{
							continue;
						}
						empty = PlayTime.Empty;
						return empty;
					}
					empty = viewEnd;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = PlayTime.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this.ViewEnd != value && value != PlayTime.Empty)
					{
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							textCharactor.ViewEnd = value;
						}
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							rubyCharactor.ViewEnd = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public PlayTime ViewStart
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime viewStart = this.TextCharactors[0].ViewStart;
					foreach (Charactor textCharactor in this.TextCharactors)
					{
						if (viewStart == textCharactor.ViewStart)
						{
							continue;
						}
						empty = PlayTime.Empty;
						return empty;
					}
					foreach (Charactor rubyCharactor in this.RubyCharactors)
					{
						if (viewStart == rubyCharactor.ViewStart)
						{
							continue;
						}
						empty = PlayTime.Empty;
						return empty;
					}
					empty = viewStart;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = PlayTime.Empty;
				}
				return empty;
			}
			set
			{
				try
				{
					if (this.ViewStart != value && value != PlayTime.Empty)
					{
						foreach (Charactor textCharactor in this.TextCharactors)
						{
							textCharactor.ViewStart = value;
						}
						foreach (Charactor rubyCharactor in this.RubyCharactors)
						{
							rubyCharactor.ViewStart = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public Size WordSize
		{
			get
			{
				double num;
				Size empty;
				try
				{
					Size textSize = this.TextSize;
					Size rubySize = this.RubySize;
					if (textSize == Size.Empty && rubySize == Size.Empty)
					{
						empty = Size.Empty;
					}
					else if (textSize == Size.Empty)
					{
						empty = new Size(rubySize.Width, rubySize.Height + this.ParentalSub.FontSetCatalog.GetItem(this.FontSetName).Text.Size + this.DistanceToRuby);
					}
					else if (rubySize != Size.Empty)
					{
						num = (!this.IsLikeUgaWord ? textSize.Width : Math.Max(textSize.Width, rubySize.Width));
						double height = textSize.Height + rubySize.Height + this.DistanceToRuby;
						empty = new Size(num, height);
					}
					else
					{
						empty = new Size(textSize.Width, textSize.Height + this.ParentalSub.FontSetCatalog.GetItem(this.FontSetName).Ruby.Size + this.DistanceToRuby);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = Size.Empty;
				}
				return empty;
			}
		}

		public Word()
		{
			try
			{
				this.TextCharactors = new List<Charactor>();
				this.RubyCharactors = new List<Charactor>();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public Word(Line parentalLine, double distanceToRuby, bool isSpacingEnabled, bool isLikeUgaWord, bool isDefaultWithoutSing, double defaultAngle, string defaultFontSetName, string defaultColorSetName)
		{
			try
			{
				this.ParentalLine = parentalLine;
				this.TextCharactors = new List<Charactor>();
				this.RubyCharactors = new List<Charactor>();
				this.DistanceToRuby = distanceToRuby;
				this.IsSpacingEnabled = isSpacingEnabled;
				this.IsLikeUgaWord = isLikeUgaWord;
				this.IsDefaultWithoutSing = isDefaultWithoutSing;
				this.DefaultAngle = defaultAngle;
				this.DefaultFontSetName = defaultFontSetName;
				this.DefaultColorSetName = defaultColorSetName;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Arrange(Point basePoint)
		{
			double count;
			double num;
			double count1;
			double num1;
			try
			{
				double width = this.TextSize.Width;
				double width1 = this.RubySize.Width;
				if (width >= width1 || !this.IsLikeUgaWord)
				{
					count = 0;
					count1 = 0;
					if (this.RubyCharactors.Count <= 1 || !this.IsSpacingEnabled || width < width1)
					{
						num = 0;
						num1 = (width - width1) / 2;
					}
					else
					{
						num = (width - width1) / ((double)(this.RubyCharactors.Count - 1) * 2);
						num1 = num * (double)(this.RubyCharactors.Count - 1) / 2;
					}
				}
				else
				{
					num = 0;
					num1 = 0;
					if (this.TextCharactors.Count <= 1 || !this.IsSpacingEnabled)
					{
						count = 0;
						count1 = (width1 - width) / 2;
					}
					else
					{
						count = (width1 - width) / ((double)(this.TextCharactors.Count - 1) * 2);
						count1 = count * ((double)(this.TextCharactors.Count - 1) / 2);
					}
				}
				double defaultAngle = this.DefaultAngle * 3.14159265358979 / 180;
				Point point = new Point(basePoint.X + count1 * Math.Cos(defaultAngle), basePoint.Y - count1 * Math.Sin(defaultAngle));
				for (int i = 0; i < this.TextCharactors.Count; i++)
				{
					this.TextCharactors[i].LeftTop = point;
					double x = point.X;
					Size size = this.TextCharactors[i].Size;
					point.X = x + (size.Width + count) * Math.Cos(defaultAngle);
					double y = point.Y;
					Size size1 = this.TextCharactors[i].Size;
					point.Y = y - (size1.Width + count) * Math.Sin(defaultAngle);
				}
				point = new Point(basePoint.X + num1 * Math.Cos(defaultAngle) + this.DistanceToRuby * Math.Sin(defaultAngle), basePoint.Y - num1 * Math.Sin(defaultAngle) + this.DistanceToRuby * Math.Cos(defaultAngle));
				for (int j = 0; j < this.RubyCharactors.Count; j++)
				{
					this.RubyCharactors[j].LeftTop = point;
					double x1 = point.X;
					Size size2 = this.RubyCharactors[j].Size;
					point.X = x1 + (size2.Width + num) * Math.Cos(defaultAngle);
					double y1 = point.Y;
					Size size3 = this.RubyCharactors[j].Size;
					point.Y = y1 - (size3.Width + num) * Math.Sin(defaultAngle);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Initialize(Line parentalLine)
		{
			try
			{
				this.ParentalLine = parentalLine;
				foreach (Charactor charactor in this.Charactors)
				{
					charactor.Initialize(this);
				}
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
				foreach (Charactor textCharactor in this.TextCharactors)
				{
					textCharactor.Move(x, y);
				}
				foreach (Charactor rubyCharactor in this.RubyCharactors)
				{
					rubyCharactor.Move(x, y);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void PutRubySingTime()
		{
			try
			{
				string timeTaggedRuby = this.TimeTaggedRuby;
				int num = 0;
				int length = 0;
			Label1:
				while (length < timeTaggedRuby.Length)
				{
					while (length < timeTaggedRuby.Length)
					{
						Match match = PlayTime.HeadSyllableRegex.Match(timeTaggedRuby.Substring(length));
						if (match.Success)
						{
							PlayTime playTime = PlayTime.FromTimeTag(match.Groups[1].Value);
							PlayTime playTime1 = PlayTime.FromTimeTag(match.Groups[3].Value);
							PlayTimeSpan playTimeSpan = playTime1 - playTime;
							int length1 = match.Groups[2].Length;
							if (length1 > 1)
							{
								Charactor[] item = new Charactor[length1];
								double width = 0;
								for (int i = 0; i < length1; i++)
								{
									item[i] = this.RubyCharactors[num + i];
									width = width + item[i].Size.Width;
								}
								double width1 = 0;
								for (int j = 0; j < length1 - 1; j++)
								{
									width1 = width1 + item[j].Size.Width;
									PlayTime playTime2 = playTime + (playTimeSpan * (width1 / width));
									if (!item[j].IsSolidSingEnd)
									{
										item[j].SingEnd = playTime2;
									}
									if (!item[j + 1].IsSolidSingStart)
									{
										item[j + 1].SingStart = playTime2;
									}
								}
							}
							length = length + match.Groups[1].Length + length1;
							num = num + length1;
							goto Label1;
						}
						else
						{
							length++;
							num++;
						}
					}
					return;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public static List<Word> Split(Word word)
		{
			List<Word> words;
			try
			{
				List<Word> words1 = new List<Word>();
				for (int i = 0; i < word.TextCharactors.Count; i++)
				{
					Word word1 = new Word(word.ParentalLine, word.DistanceToRuby, word.IsSpacingEnabled, word.IsLikeUgaWord, word.IsDefaultWithoutSing, word.DefaultAngle, word.DefaultFontSetName, word.DefaultColorSetName);
					word1.TextCharactors.Add(word.TextCharactors[i]);
					word.TextCharactors[i].ParentalWord = word1;
					if (i == 0)
					{
						foreach (Charactor rubyCharactor in word.RubyCharactors)
						{
							rubyCharactor.ParentalWord = word1;
							word1.RubyCharactors.Add(rubyCharactor);
						}
					}
					words1.Add(word1);
				}
				words = words1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				words = null;
			}
			return words;
		}

		public static Word Unite(List<Word> words)
		{
			Word word;
			try
			{
				Word word1 = new Word(words[0].ParentalLine, words[0].DistanceToRuby, words[0].IsSpacingEnabled, words[0].IsLikeUgaWord, words[0].IsDefaultWithoutSing, words[0].DefaultAngle, words[0].DefaultFontSetName, words[0].DefaultColorSetName);
				foreach (Word word2 in words)
				{
					foreach (Charactor textCharactor in word2.TextCharactors)
					{
						textCharactor.ParentalWord = word1;
						word1.TextCharactors.Add(textCharactor);
					}
					foreach (Charactor rubyCharactor in word2.RubyCharactors)
					{
						rubyCharactor.ParentalWord = word1;
						word1.RubyCharactors.Add(rubyCharactor);
					}
				}
				word = word1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				word = null;
			}
			return word;
		}
	}
}