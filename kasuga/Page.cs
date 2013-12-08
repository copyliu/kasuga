using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public class Page
	{
		[XmlIgnore]
		public double? Angle
		{
			get
			{
				double? nullable;
				try
				{
					double? angle = this.Lines[0].Angle;
					foreach (Line line in this.Lines)
					{
						double? nullable1 = angle;
						double? angle1 = line.Angle;
						if (((double)nullable1.GetValueOrDefault() != (double)angle1.GetValueOrDefault() ? false : nullable1.HasValue == angle1.HasValue))
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = angle;
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
						foreach (Line line in this.Lines)
						{
							line.Angle = new double?(num);
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
		public IArrangement Arrangement
		{
			get
			{
				IArrangement arrangementLikeJoy;
				try
				{
					if (this.ArrangementName == ArrangementLikeJoy.TypeName)
					{
						arrangementLikeJoy = new ArrangementLikeJoy();
					}
					else if (this.ArrangementName != LineHeadArrangement.TypeName)
					{
						arrangementLikeJoy = null;
					}
					else
					{
						arrangementLikeJoy = new LineHeadArrangement();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					arrangementLikeJoy = null;
				}
				return arrangementLikeJoy;
			}
		}

		public string ArrangementName
		{
			get;
			set;
		}

		public Point BasePoint
		{
			get;
			set;
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
					foreach (Line line in this.Lines)
					{
						foreach (Charactor charactor in line.Charactors)
						{
							charactors1.Add(charactor);
						}
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
					string colorSetName = this.Lines[0].ColorSetName;
					foreach (Line line in this.Lines)
					{
						if (colorSetName == line.ColorSetName)
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
						foreach (Line line in this.Lines)
						{
							line.ColorSetName = value;
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

		public double DefaultDistanceToRuby
		{
			get;
			set;
		}

		public string DefaultFontSetName
		{
			get;
			set;
		}

		public double DistanceToNextLine
		{
			get;
			set;
		}

		[XmlIgnore]
		public double? DistanceToRuby
		{
			get
			{
				double? nullable;
				try
				{
					double? distanceToRuby = this.Lines[0].DistanceToRuby;
					foreach (Line line in this.Lines)
					{
						double? nullable1 = distanceToRuby;
						double? distanceToRuby1 = line.DistanceToRuby;
						if (((double)nullable1.GetValueOrDefault() != (double)distanceToRuby1.GetValueOrDefault() ? false : nullable1.HasValue == distanceToRuby1.HasValue))
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = distanceToRuby;
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
					double? distanceToRuby = this.DistanceToRuby;
					double? nullable = value;
					if (((double)distanceToRuby.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : distanceToRuby.HasValue != nullable.HasValue) && value.HasValue)
					{
						double num = (double)value.Value;
						this.DefaultDistanceToRuby = num;
						foreach (Line line in this.Lines)
						{
							line.DistanceToRuby = new double?(num);
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
		public PlayTime FirstSingStart
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime firstSingStart = this.Lines[0].FirstSingStart;
					foreach (Line line in this.Lines)
					{
						firstSingStart = PlayTime.Min(firstSingStart, line.FirstSingStart);
					}
					empty = firstSingStart;
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
					string fontSetName = this.Lines[0].FontSetName;
					foreach (Line line in this.Lines)
					{
						if (fontSetName == line.FontSetName)
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
						foreach (Line line in this.Lines)
						{
							line.FontSetName = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsCenteringEnabled
		{
			get;
			set;
		}

		public bool IsDefaultLikeUgaWord
		{
			get;
			set;
		}

		public bool IsDefaultSpacingEnabled
		{
			get;
			set;
		}

		public bool IsDegaultWithoutSing
		{
			get;
			set;
		}

		[XmlIgnore]
		public bool? IsLikeUgaWord
		{
			get
			{
				bool? nullable;
				try
				{
					bool? isLikeUgaWord = this.Lines[0].IsLikeUgaWord;
					foreach (Line line in this.Lines)
					{
						bool? nullable1 = isLikeUgaWord;
						bool? isLikeUgaWord1 = line.IsLikeUgaWord;
						if ((nullable1.GetValueOrDefault() != isLikeUgaWord1.GetValueOrDefault() ? false : nullable1.HasValue == isLikeUgaWord1.HasValue))
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = isLikeUgaWord;
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
					bool? isLikeUgaWord = this.IsLikeUgaWord;
					bool? nullable = value;
					if ((isLikeUgaWord.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isLikeUgaWord.HasValue != nullable.HasValue) && value.HasValue)
					{
						bool flag = value.Value;
						this.IsDefaultLikeUgaWord = flag;
						foreach (Line line in this.Lines)
						{
							line.IsLikeUgaWord = new bool?(flag);
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
		public bool? IsSpacingEnabled
		{
			get
			{
				bool? nullable;
				try
				{
					bool? isSpacingEnabled = this.Lines[0].IsSpacingEnabled;
					foreach (Line line in this.Lines)
					{
						bool? nullable1 = isSpacingEnabled;
						bool? isSpacingEnabled1 = line.IsSpacingEnabled;
						if ((nullable1.GetValueOrDefault() != isSpacingEnabled1.GetValueOrDefault() ? false : nullable1.HasValue == isSpacingEnabled1.HasValue))
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = isSpacingEnabled;
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
					bool? isSpacingEnabled = this.IsSpacingEnabled;
					bool? nullable = value;
					if ((isSpacingEnabled.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isSpacingEnabled.HasValue != nullable.HasValue) && value.HasValue)
					{
						bool flag = value.Value;
						this.IsDefaultSpacingEnabled = flag;
						foreach (Line line in this.Lines)
						{
							line.IsSpacingEnabled = new bool?(flag);
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
		public bool? IsWithoutSing
		{
			get
			{
				bool? nullable;
				try
				{
					bool? isWithoutSing = this.Lines[0].IsWithoutSing;
					foreach (Line line in this.Lines)
					{
						bool? nullable1 = isWithoutSing;
						bool? isWithoutSing1 = line.IsWithoutSing;
						if ((nullable1.GetValueOrDefault() != isWithoutSing1.GetValueOrDefault() ? false : nullable1.HasValue == isWithoutSing1.HasValue))
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = isWithoutSing;
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
						this.IsDegaultWithoutSing = flag;
						foreach (Line line in this.Lines)
						{
							line.IsWithoutSing = new bool?(flag);
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
					PlayTime lastSingEnd = this.Lines[0].LastSingEnd;
					foreach (Line line in this.Lines)
					{
						lastSingEnd = PlayTime.Max(lastSingEnd, line.LastSingEnd);
					}
					empty = lastSingEnd;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = PlayTime.Empty;
				}
				return empty;
			}
		}

		public List<Line> Lines
		{
			get;
			set;
		}

		public double MinOverlapping
		{
			get;
			set;
		}

		[XmlIgnore]
		public Part ParentalPart
		{
			get;
			set;
		}

		[XmlIgnore]
		public Sub ParentalSub
		{
			get
			{
				Sub parentalSub;
				try
				{
					parentalSub = this.ParentalPart.ParentalSub;
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
		public List<Charactor> RubyCharactors
		{
			get
			{
				List<Charactor> charactors;
				try
				{
					List<Charactor> charactors1 = new List<Charactor>();
					foreach (Line line in this.Lines)
					{
						foreach (Charactor rubyCharactor in line.RubyCharactors)
						{
							charactors1.Add(rubyCharactor);
						}
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
		public string Text
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					for (int i = 0; i < this.Lines.Count; i++)
					{
						if (i > 0)
						{
							str = string.Concat(str, Environment.NewLine);
						}
						str = string.Concat(str, this.Lines[i].Text);
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

		[XmlIgnore]
		public List<Charactor> TextCharactors
		{
			get
			{
				List<Charactor> charactors;
				try
				{
					List<Charactor> charactors1 = new List<Charactor>();
					foreach (Line line in this.Lines)
					{
						foreach (Charactor textCharactor in line.TextCharactors)
						{
							charactors1.Add(textCharactor);
						}
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
		public string TimeTaggedText
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					for (int i = 0; i < this.Lines.Count; i++)
					{
						if (i > 0)
						{
							str = string.Concat(str, Environment.NewLine);
						}
						str = string.Concat(str, this.Lines[i].TimeTaggedText);
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
				try
				{
					if (this.TimeTaggedText != value)
					{
						this.Lines.Clear();
						string[] newLine = new string[] { Environment.NewLine };
						string[] strArrays = value.Split(newLine, StringSplitOptions.None);
						for (int i = 0; i < (int)strArrays.Length; i++)
						{
							Line line = new Line(this, strArrays[i], this.DefaultDistanceToRuby, this.IsDefaultSpacingEnabled, this.IsDefaultLikeUgaWord, this.IsDegaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName);
							this.Lines.Add(line);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public double UsableWidth
		{
			get;
			set;
		}

		[XmlIgnore]
		public PlayTime ViewEnd
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime viewEnd = this.Lines[0].ViewEnd;
					foreach (Line line in this.Lines)
					{
						if (viewEnd == line.ViewEnd)
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
						foreach (Line line in this.Lines)
						{
							line.ViewEnd = value;
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
					PlayTime viewStart = this.Lines[0].ViewStart;
					foreach (Line line in this.Lines)
					{
						if (viewStart == line.ViewStart)
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
						foreach (Line line in this.Lines)
						{
							line.ViewStart = value;
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
		public List<Word> Words
		{
			get
			{
				List<Word> words;
				try
				{
					List<Word> words1 = new List<Word>();
					foreach (Line line in this.Lines)
					{
						foreach (Word word in line.Words)
						{
							words1.Add(word);
						}
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
		}

		public Page()
		{
			try
			{
				this.Lines = new List<Line>();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public Page(Part parentalPart, Point basePoint, double usableWidth, double defaultAngle, string arrangementName, bool isCenteringEnabled, double minOverlapping, double distanceToNextLine, double defaultDistanceToRuby, bool isDefaultSpacingEnabled, bool isDefaultLikeUgaWord, bool isDefaultWithoutSing, string defaultFontSetName, string defaultColorSetName)
		{
			try
			{
				this.Lines = new List<Line>();
				this.ParentalPart = parentalPart;
				this.BasePoint = basePoint;
				this.UsableWidth = usableWidth;
				this.DefaultAngle = defaultAngle;
				this.ArrangementName = arrangementName;
				this.IsCenteringEnabled = isCenteringEnabled;
				this.MinOverlapping = minOverlapping;
				this.DistanceToNextLine = distanceToNextLine;
				this.DefaultDistanceToRuby = defaultDistanceToRuby;
				this.IsDefaultSpacingEnabled = isDefaultSpacingEnabled;
				this.IsDefaultLikeUgaWord = isDefaultLikeUgaWord;
				this.IsDegaultWithoutSing = isDefaultWithoutSing;
				this.DefaultFontSetName = defaultFontSetName;
				this.DefaultColorSetName = defaultColorSetName;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Arrange()
		{
			try
			{
				this.Arrangement.Arrange(this);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Initialize(Part parentalPart)
		{
			try
			{
				this.ParentalPart = parentalPart;
				foreach (Line line in this.Lines)
				{
					line.Initialize(this);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public static List<Page> Split(Page page)
		{
			List<Page> pages;
			try
			{
				List<Page> pages1 = new List<Page>();
				for (int i = 0; i < page.Lines.Count; i++)
				{
					Page page1 = new Page(page.ParentalPart, page.BasePoint, page.UsableWidth, page.DefaultAngle, page.ArrangementName, page.IsCenteringEnabled, page.MinOverlapping, page.DistanceToNextLine, page.DefaultDistanceToRuby, page.IsDefaultSpacingEnabled, page.IsDefaultLikeUgaWord, page.IsDegaultWithoutSing, page.DefaultFontSetName, page.DefaultColorSetName);
					page1.Lines.Add(page.Lines[i]);
					page.Lines[i].ParentalPage = page1;
					pages1.Add(page1);
				}
				pages = pages1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				pages = null;
			}
			return pages;
		}

		public static Page Unite(List<Page> pages)
		{
			Page page;
			try
			{
				Page page1 = new Page(pages[0].ParentalPart, pages[0].BasePoint, pages[0].UsableWidth, pages[0].DefaultAngle, pages[0].ArrangementName, pages[0].IsCenteringEnabled, pages[0].MinOverlapping, pages[0].DistanceToNextLine, pages[0].DefaultDistanceToRuby, pages[0].IsDefaultSpacingEnabled, pages[0].IsDefaultLikeUgaWord, pages[0].IsDegaultWithoutSing, pages[0].DefaultFontSetName, pages[0].DefaultColorSetName);
				foreach (Page page2 in pages)
				{
					foreach (Line line in page2.Lines)
					{
						line.ParentalPage = page1;
						page1.Lines.Add(line);
					}
				}
				page = page1;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				page = null;
			}
			return page;
		}
	}
}