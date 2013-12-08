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
	public class Part
	{
		public PlayTimeSpan AfterMargin
		{
			get;
			set;
		}

		[XmlIgnore]
		public double? Angle
		{
			get
			{
				double? nullable;
				try
				{
					double? angle = this.Pages[0].Angle;
					foreach (Page page in this.Pages)
					{
						double? nullable1 = angle;
						double? angle1 = page.Angle;
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
						foreach (Page page in this.Pages)
						{
							page.Angle = new double?(num);
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
		public string ArrangementName
		{
			get
			{
				string str;
				try
				{
					string arrangementName = this.Pages[0].ArrangementName;
					foreach (Page page in this.Pages)
					{
						if (arrangementName == page.ArrangementName)
						{
							continue;
						}
						str = null;
						return str;
					}
					str = arrangementName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					str = null;
				}
				return str;
			}
			set
			{
				try
				{
					if (this.ArrangementName != value && value != string.Empty)
					{
						this.DefaultArrangementName = value;
						foreach (Page page in this.Pages)
						{
							page.ArrangementName = value;
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
		public Point? BasePoint
		{
			get
			{
				Point? nullable;
				try
				{
					Point basePoint = this.Pages[0].BasePoint;
					foreach (Page page in this.Pages)
					{
						if (basePoint == page.BasePoint)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new Point?(basePoint);
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
				bool flag;
				try
				{
					Point? basePoint = this.BasePoint;
					Point? nullable = value;
					if (basePoint.HasValue != nullable.HasValue)
					{
						flag = true;
					}
					else
					{
						flag = (!basePoint.HasValue ? false : basePoint.GetValueOrDefault() != nullable.GetValueOrDefault());
					}
					if (flag && value.HasValue)
					{
						Point point = value.Value;
						this.DefaultBasePoint = point;
						foreach (Page page in this.Pages)
						{
							page.BasePoint = point;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public PlayTimeSpan BeforeMargin
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
					foreach (Page page in this.Pages)
					{
						foreach (Charactor charactor in page.Charactors)
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
					string colorSetName = this.Pages[0].ColorSetName;
					foreach (Page page in this.Pages)
					{
						if (colorSetName == page.ColorSetName)
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
						foreach (Page page in this.Pages)
						{
							page.ColorSetName = value;
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

		public string DefaultArrangementName
		{
			get;
			set;
		}

		public Point DefaultBasePoint
		{
			get;
			set;
		}

		public string DefaultColorSetName
		{
			get;
			set;
		}

		public double DefaultDistanceToNextLine
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

		public double DefaultMinOverlapping
		{
			get;
			set;
		}

		public double DefaultUsableWidth
		{
			get;
			set;
		}

		[XmlIgnore]
		public double? DistanceToNextLine
		{
			get
			{
				double? nullable;
				try
				{
					double distanceToNextLine = this.Pages[0].DistanceToNextLine;
					foreach (Page page in this.Pages)
					{
						if (distanceToNextLine == page.DistanceToNextLine)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new double?(distanceToNextLine);
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
					double? distanceToNextLine = this.DistanceToNextLine;
					double? nullable = value;
					if (((double)distanceToNextLine.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : distanceToNextLine.HasValue != nullable.HasValue) && value.HasValue)
					{
						double num = (double)value.Value;
						this.DefaultDistanceToNextLine = num;
						foreach (Page page in this.Pages)
						{
							page.DistanceToNextLine = num;
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
		public double? DistanceToRuby
		{
			get
			{
				double? nullable;
				try
				{
					double? distanceToRuby = this.Pages[0].DistanceToRuby;
					foreach (Page page in this.Pages)
					{
						double? nullable1 = distanceToRuby;
						double? distanceToRuby1 = page.DistanceToRuby;
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
						foreach (Page page in this.Pages)
						{
							page.DistanceToRuby = new double?(num);
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
		public string FontSetName
		{
			get
			{
				string empty;
				try
				{
					string fontSetName = this.Pages[0].FontSetName;
					foreach (Page page in this.Pages)
					{
						if (fontSetName == page.FontSetName)
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
						foreach (Page page in this.Pages)
						{
							page.FontSetName = value;
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
		public bool? IsCenteringEnabled
		{
			get
			{
				bool? nullable;
				try
				{
					bool isCenteringEnabled = this.Pages[0].IsCenteringEnabled;
					foreach (Page page in this.Pages)
					{
						if (isCenteringEnabled == page.IsCenteringEnabled)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new bool?(isCenteringEnabled);
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
					bool? isCenteringEnabled = this.IsCenteringEnabled;
					bool? nullable = value;
					if ((isCenteringEnabled.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isCenteringEnabled.HasValue != nullable.HasValue) && value.HasValue)
					{
						bool flag = value.Value;
						this.IsDefaultCenteringEnabled = flag;
						foreach (Page page in this.Pages)
						{
							page.IsCenteringEnabled = flag;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsDefaultCenteringEnabled
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

		public bool IsDefaultWithoutSing
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
					bool? isLikeUgaWord = this.Pages[0].IsLikeUgaWord;
					foreach (Page page in this.Pages)
					{
						bool? nullable1 = isLikeUgaWord;
						bool? isLikeUgaWord1 = page.IsLikeUgaWord;
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
						foreach (Page page in this.Pages)
						{
							page.IsLikeUgaWord = new bool?(flag);
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
					bool? isSpacingEnabled = this.Pages[0].IsSpacingEnabled;
					foreach (Page page in this.Pages)
					{
						bool? nullable1 = isSpacingEnabled;
						bool? isSpacingEnabled1 = page.IsSpacingEnabled;
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
						foreach (Page page in this.Pages)
						{
							page.IsSpacingEnabled = new bool?(flag);
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsTopBase
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
					bool? isWithoutSing = this.Pages[0].IsWithoutSing;
					foreach (Page page in this.Pages)
					{
						bool? nullable1 = isWithoutSing;
						bool? isWithoutSing1 = page.IsWithoutSing;
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
						this.IsDefaultWithoutSing = flag;
						foreach (Page page in this.Pages)
						{
							page.IsWithoutSing = new bool?(flag);
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
		public List<Line> Lines
		{
			get
			{
				List<Line> lines;
				try
				{
					List<Line> lines1 = new List<Line>();
					foreach (Page page in this.Pages)
					{
						foreach (Line line in page.Lines)
						{
							lines1.Add(line);
						}
					}
					lines = lines1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					lines = null;
				}
				return lines;
			}
		}

		[XmlIgnore]
		public double? MinOverlapping
		{
			get
			{
				double? nullable;
				try
				{
					double minOverlapping = this.Pages[0].MinOverlapping;
					foreach (Page page in this.Pages)
					{
						if (minOverlapping == page.MinOverlapping)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new double?(minOverlapping);
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
					double? minOverlapping = this.MinOverlapping;
					double? nullable = value;
					if (((double)minOverlapping.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : minOverlapping.HasValue != nullable.HasValue) && value.HasValue)
					{
						double num = (double)value.Value;
						this.DefaultMinOverlapping = num;
						foreach (Page page in this.Pages)
						{
							page.MinOverlapping = num;
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
		public BasicOutput Output
		{
			get
			{
				BasicOutput item;
				try
				{
					item = this.ParentalSub.OutputCatalog.GetItem(this.OutputName);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					item = null;
				}
				return item;
			}
		}

		public string OutputName
		{
			get;
			set;
		}

		public List<Page> Pages
		{
			get;
			set;
		}

		[XmlIgnore]
		public Sub ParentalSub
		{
			get;
			set;
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
					foreach (Page page in this.Pages)
					{
						foreach (Charactor rubyCharactor in page.RubyCharactors)
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
					for (int i = 0; i < this.Pages.Count; i++)
					{
						if (i > 0)
						{
							str = string.Concat(str, Environment.NewLine);
						}
						str = string.Concat(str, this.Pages[i].Text);
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
					foreach (Page page in this.Pages)
					{
						foreach (Charactor textCharactor in page.TextCharactors)
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
					for (int i = 0; i < this.Pages.Count; i++)
					{
						if (i > 0)
						{
							str = string.Concat(str, Environment.NewLine);
						}
						str = string.Concat(str, this.Pages[i].TimeTaggedText);
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
						this.Pages.Clear();
						string[] newLine = new string[] { Environment.NewLine };
						string[] strArrays = value.Split(newLine, StringSplitOptions.None);
						for (int i = 0; i < (int)strArrays.Length; i++)
						{
							if (PlayTime.TimeTagRegex.IsMatch(strArrays[i]))
							{
								Page page = new Page(this, this.DefaultBasePoint, this.DefaultUsableWidth, this.DefaultAngle, this.DefaultArrangementName, this.IsDefaultCenteringEnabled, this.DefaultMinOverlapping, this.DefaultDistanceToNextLine, this.DefaultDistanceToRuby, this.IsDefaultSpacingEnabled, this.IsDefaultLikeUgaWord, this.IsDefaultWithoutSing, this.DefaultFontSetName, this.DefaultColorSetName);
								Line line = new Line(page, strArrays[i], this.DefaultDistanceToRuby, this.IsDefaultSpacingEnabled, this.IsDefaultLikeUgaWord, this.IsDefaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName);
								if (line.Charactors.Count > 0)
								{
									page.Lines.Add(line);
									this.Pages.Add(page);
								}
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

		[XmlIgnore]
		public double? UsableWidth
		{
			get
			{
				double? nullable;
				try
				{
					double usableWidth = this.Pages[0].UsableWidth;
					foreach (Page page in this.Pages)
					{
						if (usableWidth == page.UsableWidth)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new double?(usableWidth);
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
					double? usableWidth = this.UsableWidth;
					double? nullable = value;
					if (((double)usableWidth.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : usableWidth.HasValue != nullable.HasValue) && value.HasValue)
					{
						double num = (double)value.Value;
						this.DefaultUsableWidth = num;
						foreach (Page page in this.Pages)
						{
							page.UsableWidth = num;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public PlayTimeSpan ViewInterval
		{
			get;
			set;
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
					foreach (Page page in this.Pages)
					{
						foreach (Word word in page.Words)
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

		public Part()
		{
			try
			{
				this.Pages = new List<Page>();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public Part(Sub sub, string timeTagText, string effectName, bool isTopBase, PlayTimeSpan beforeMargin, PlayTimeSpan afterMargin, PlayTimeSpan viewInterval, Point defaultLeftCorner, double defaultUsableWidth, double defaultAngle, string defaultArrangementName, bool isDefaultCenteringEnabled, double defaultMinOverlapping, double defaultDistanceToNextLine, double defaultDistanceToRuby, bool isDefaultSpacingEnabled, bool isDefaultLikeUgaWord, bool isDefaultWithoutSing, string defaultFontSetName, string defaultColorSetName)
		{
			try
			{
				this.Pages = new List<Page>();
				this.ParentalSub = sub;
				this.IsTopBase = isTopBase;
				this.OutputName = effectName;
				this.BeforeMargin = beforeMargin;
				this.AfterMargin = afterMargin;
				this.ViewInterval = viewInterval;
				this.DefaultBasePoint = defaultLeftCorner;
				this.DefaultUsableWidth = defaultUsableWidth;
				this.DefaultAngle = defaultAngle;
				this.DefaultArrangementName = defaultArrangementName;
				this.IsDefaultCenteringEnabled = isDefaultCenteringEnabled;
				this.DefaultMinOverlapping = defaultMinOverlapping;
				this.DefaultDistanceToNextLine = defaultDistanceToNextLine;
				this.DefaultDistanceToRuby = defaultDistanceToRuby;
				this.IsDefaultSpacingEnabled = isDefaultSpacingEnabled;
				this.IsDefaultLikeUgaWord = isDefaultLikeUgaWord;
				this.IsDefaultWithoutSing = isDefaultWithoutSing;
				this.DefaultFontSetName = defaultFontSetName;
				this.DefaultColorSetName = defaultColorSetName;
				this.TimeTaggedText = timeTagText;
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
				foreach (Page page in this.Pages)
				{
					page.Arrange();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public List<AssDialogue> ConvertToAss(ref List<AssStyle> styles)
		{
			List<AssDialogue> ass;
			try
			{
				ass = this.Output.ConvertToAss(this, ref styles);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				ass = null;
			}
			return ass;
		}

		public void Initialize(Sub parentalSub)
		{
			try
			{
				this.ParentalSub = parentalSub;
				foreach (Page page in this.Pages)
				{
					page.Initialize(this);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void PutSingTimes()
		{
			try
			{
				string empty = string.Empty;
				PlayTime singEnd = PlayTime.Empty;
				foreach (Charactor textCharactor in this.TextCharactors)
				{
					if (textCharactor.SingStart != singEnd && textCharactor.IsSolidSingStart)
					{
						empty = string.Concat(empty, textCharactor.SingStart.TimeTag);
					}
					char chr = textCharactor.Char;
					empty = string.Concat(empty, chr.ToString());
					if (!textCharactor.IsSolidSingEnd)
					{
						singEnd = PlayTime.Empty;
					}
					else
					{
						empty = string.Concat(empty, textCharactor.SingEnd.TimeTag);
						singEnd = textCharactor.SingEnd;
					}
				}
				int num = 0;
				int length = 0;
			Label1:
				while (length < empty.Length)
				{
					while (length < empty.Length)
					{
						Match match = PlayTime.HeadSyllableRegex.Match(empty.Substring(length));
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
									item[i] = this.TextCharactors[num + i];
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

		public void PutViewTimes()
		{
			try
			{
				PlayTimeSpan beforeMargin = (this.BeforeMargin + this.AfterMargin) + this.ViewInterval;
				int num = 0;
				while (num < this.Pages.Count)
				{
					Page item = this.Pages[num];
					if (num <= 0)
					{
						item.ViewStart = item.FirstSingStart - this.BeforeMargin;
					}
					if (num < this.Pages.Count - 1)
					{
						Page firstSingStart = this.Pages[num + 1];
						if ((firstSingStart.FirstSingStart - item.LastSingEnd) >= beforeMargin)
						{
							item.ViewEnd = item.LastSingEnd + this.AfterMargin;
							firstSingStart.ViewStart = firstSingStart.FirstSingStart - this.BeforeMargin;
						}
						else if (!this.IsTopBase)
						{
							PlayTime empty = PlayTime.Empty;
							PlayTime playTime = PlayTime.Empty;
							for (int i = 0; i < item.Lines.Count || i < firstSingStart.Lines.Count; i++)
							{
								if (i >= item.Lines.Count)
								{
									firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].ViewStart = firstSingStart.FirstSingStart - this.BeforeMargin;
								}
								else if (i < firstSingStart.Lines.Count)
								{
									empty = item.Lines[item.Lines.Count - (i + 1)].LastSingEnd;
									playTime = firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].FirstSingStart;
									if ((playTime - empty) <= beforeMargin)
									{
										item.Lines[item.Lines.Count - (i + 1)].ViewEnd = empty + this.AfterMargin;
										firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].ViewStart = playTime - this.BeforeMargin;
									}
									else if (i <= 0)
									{
										item.Lines[item.Lines.Count - (i + 1)].ViewEnd = PlayTime.Min(empty + this.AfterMargin, playTime - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].ViewStart = PlayTime.Min(empty + this.AfterMargin + this.ViewInterval, playTime - this.BeforeMargin);
									}
									else if (item.Lines.Count >= firstSingStart.Lines.Count && i >= item.Lines.Count - 1)
									{
										item.Lines[item.Lines.Count - (i + 1)].ViewEnd = PlayTime.Max(empty + this.AfterMargin, playTime - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].ViewStart = PlayTime.Max(empty + this.AfterMargin + this.ViewInterval, playTime - this.BeforeMargin);
									}
									else if (i >= firstSingStart.Lines.Count - 1)
									{
										item.Lines[item.Lines.Count - (i + 1)].ViewEnd = PlayTime.Max(empty + this.AfterMargin, playTime - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].ViewStart = PlayTime.Max(empty + this.AfterMargin + this.ViewInterval, playTime - this.BeforeMargin);
									}
									else
									{
										item.Lines[item.Lines.Count - (i + 1)].ViewEnd = PlayTime.Max(empty + this.AfterMargin, firstSingStart.FirstSingStart - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[firstSingStart.Lines.Count - (i + 1)].ViewStart = PlayTime.Max(empty + this.AfterMargin + this.ViewInterval, firstSingStart.FirstSingStart - this.BeforeMargin);
									}
								}
								else
								{
									item.Lines[item.Lines.Count - (i + 1)].ViewEnd = PlayTime.Max(empty + this.AfterMargin, firstSingStart.Lines[0].FirstSingStart - (this.BeforeMargin + this.ViewInterval));
								}
							}
						}
						else
						{
							PlayTime lastSingEnd = PlayTime.Empty;
							PlayTime empty1 = PlayTime.Empty;
							for (int j = 0; j < item.Lines.Count || j < firstSingStart.Lines.Count; j++)
							{
								if (j >= item.Lines.Count)
								{
									firstSingStart.Lines[j].ViewStart = empty1 - this.BeforeMargin;
								}
								else if (j < firstSingStart.Lines.Count)
								{
									lastSingEnd = item.Lines[j].LastSingEnd;
									empty1 = firstSingStart.Lines[j].FirstSingStart;
									if ((empty1 - lastSingEnd) <= beforeMargin)
									{
										item.Lines[j].ViewEnd = lastSingEnd + this.AfterMargin;
										firstSingStart.Lines[j].ViewStart = empty1 - this.BeforeMargin;
									}
									else if (j >= item.Lines.Count - 1 && j >= firstSingStart.Lines.Count - 1)
									{
										item.Lines[j].ViewEnd = PlayTime.Min(lastSingEnd + this.AfterMargin, empty1 - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[j].ViewStart = PlayTime.Min(lastSingEnd + this.AfterMargin + this.ViewInterval, empty1 - this.BeforeMargin);
									}
									else if (item.Lines.Count <= firstSingStart.Lines.Count && j >= firstSingStart.Lines.Count - 1)
									{
										item.Lines[j].ViewEnd = PlayTime.Max(lastSingEnd + this.AfterMargin, empty1 - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[j].ViewStart = PlayTime.Max(lastSingEnd + this.AfterMargin + this.ViewInterval, empty1 - this.BeforeMargin);
									}
									else if (j >= item.Lines.Count - 1)
									{
										item.Lines[j].ViewEnd = PlayTime.Max(lastSingEnd + this.AfterMargin, empty1 - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[j].ViewStart = PlayTime.Max(lastSingEnd + this.AfterMargin + this.ViewInterval, empty1 - this.BeforeMargin);
									}
									else
									{
										item.Lines[j].ViewEnd = PlayTime.Min(item.LastSingEnd + this.AfterMargin, empty1 - (this.BeforeMargin + this.ViewInterval));
										firstSingStart.Lines[j].ViewStart = PlayTime.Min(item.LastSingEnd + this.AfterMargin + this.ViewInterval, empty1 - this.BeforeMargin);
									}
								}
								else
								{
									item.Lines[j].ViewEnd = item.LastSingEnd + this.AfterMargin;
								}
							}
						}
						num++;
					}
					else
					{
						item.ViewEnd = item.LastSingEnd + this.AfterMargin;
						return;
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