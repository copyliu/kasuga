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
	public class Line
	{
		[XmlIgnore]
		public double? Angle
		{
			get
			{
				double? nullable;
				try
				{
					double? angle = this.Words[0].Angle;
					foreach (Word word in this.Words)
					{
						double? nullable1 = angle;
						double? angle1 = word.Angle;
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
						foreach (Word word in this.Words)
						{
							word.Angle = new double?(num);
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
					foreach (Word word in this.Words)
					{
						foreach (Charactor charactor in word.Charactors)
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
					string colorSetName = this.Words[0].ColorSetName;
					foreach (Word word in this.Words)
					{
						if (colorSetName == word.ColorSetName)
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
						foreach (Word word in this.Words)
						{
							word.ColorSetName = value;
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

		[XmlIgnore]
		public double? DistanceToRuby
		{
			get
			{
				double? nullable;
				try
				{
					double distanceToRuby = this.Words[0].DistanceToRuby;
					foreach (Word word in this.Words)
					{
						if (distanceToRuby == word.DistanceToRuby)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new double?(distanceToRuby);
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
						foreach (Word word in this.Words)
						{
							word.DistanceToRuby = num;
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
					PlayTime firstSingStart = this.Words[0].FirstSingStart;
					foreach (Word word in this.Words)
					{
						firstSingStart = PlayTime.Min(firstSingStart, word.FirstSingStart);
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
					string fontSetName = this.Words[0].FontSetName;
					foreach (Word word in this.Words)
					{
						if (fontSetName == word.FontSetName)
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
						foreach (Word word in this.Words)
						{
							word.FontSetName = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
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
					bool isLikeUgaWord = this.Words[0].IsLikeUgaWord;
					foreach (Word word in this.Words)
					{
						if (isLikeUgaWord == word.IsLikeUgaWord)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new bool?(isLikeUgaWord);
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
						foreach (Word word in this.Words)
						{
							word.IsLikeUgaWord = flag;
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
					bool isSpacingEnabled = this.Words[0].IsSpacingEnabled;
					foreach (Word word in this.Words)
					{
						if (isSpacingEnabled == word.IsSpacingEnabled)
						{
							continue;
						}
						nullable = null;
						return nullable;
					}
					nullable = new bool?(isSpacingEnabled);
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
						foreach (Word word in this.Words)
						{
							word.IsSpacingEnabled = flag;
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
					bool? isWithoutSing = this.Words[0].IsWithoutSing;
					foreach (Word word in this.Words)
					{
						bool? nullable1 = isWithoutSing;
						bool? isWithoutSing1 = word.IsWithoutSing;
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
						foreach (Word word in this.Words)
						{
							word.IsWithoutSing = new bool?(flag);
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
					PlayTime lastSingEnd = this.Words[0].LastSingEnd;
					foreach (Word word in this.Words)
					{
						lastSingEnd = PlayTime.Max(lastSingEnd, word.LastSingEnd);
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

		[XmlIgnore]
		public Page ParentalPage
		{
			get;
			set;
		}

		[XmlIgnore]
		public Part ParentalPart
		{
			get
			{
				Part parentalPart;
				try
				{
					parentalPart = this.ParentalPage.ParentalPart;
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
					parentalSub = this.ParentalPage.ParentalSub;
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
					foreach (Word word in this.Words)
					{
						foreach (Charactor rubyCharactor in word.RubyCharactors)
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
		public System.Windows.Size Size
		{
			get
			{
				System.Windows.Size size;
				try
				{
					if (this.Words.Count > 0)
					{
						double width = 0;
						double num = 0;
						foreach (Word word in this.Words)
						{
							System.Windows.Size wordSize = word.WordSize;
							width = width + wordSize.Width;
							num = Math.Max(num, wordSize.Height);
						}
						size = new System.Windows.Size(width, num);
					}
					else
					{
						size = System.Windows.Size.Empty;
					}
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
		public string Text
		{
			get
			{
				string empty;
				try
				{
					string str = string.Empty;
					for (int i = 0; i < this.Words.Count; i++)
					{
						str = string.Concat(str, this.Words[i].Text);
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
					foreach (Word word in this.Words)
					{
						foreach (Charactor textCharactor in word.TextCharactors)
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
					foreach (Word word in this.Words)
					{
						str = string.Concat(str, word.TimeTaggedWord);
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
						this.Words.Clear();
						int length = 0;
						Regex regex = new Regex("\\A(.*?)\\{(.*?)\\|(.*?)\\}(.*)");
						while (length < value.Length)
						{
							Match match = regex.Match(value.Substring(length));
							if (match.Success)
							{
								if (match.Groups[1].Length > 0)
								{
									string str = match.Groups[1].Value;
									if (!PlayTime.FootTimeTagRegex.IsMatch(str))
									{
										Match match1 = PlayTime.HeadTimeTagRegex.Match(match.Groups[2].Value);
										Match match2 = PlayTime.HeadTimeTagRegex.Match(match.Groups[3].Value);
										if (match1.Success)
										{
											str = string.Concat(str, match1.Value);
										}
										else if (match2.Success)
										{
											str = string.Concat(str, match2.Value);
										}
									}
									Word word = new Word(this, this.DefaultDistanceToRuby, this.IsDefaultSpacingEnabled, this.IsDefaultLikeUgaWord, this.IsDefaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName)
									{
										TimeTaggedText = str
									};
									if (word.Charactors.Count > 0)
									{
										this.Words.Add(word);
									}
								}
								if (match.Groups[2].Length > 0 || match.Groups[3].Length > 0)
								{
									string str1 = match.Groups[2].Value;
									string str2 = match.Groups[3].Value;
									Match match3 = PlayTime.HeadTimeTagRegex.Match(str1);
									Match match4 = PlayTime.HeadTimeTagRegex.Match(str2);
									if (!match3.Success && match4.Success)
									{
										str1 = string.Concat(match4.Value, str1);
									}
									else if (match3.Success && !match4.Success)
									{
										str2 = string.Concat(match3.Value, str2);
									}
									match3 = PlayTime.FootTimeTagRegex.Match(str1);
									match4 = PlayTime.FootTimeTagRegex.Match(str2);
									if (match3.Success || !match4.Success)
									{
										if (match3.Success && !match4.Success)
										{
											str2 = string.Concat(str2, match3.Value);
										}
										else if (!match3.Success && !match4.Success)
										{
											string str3 = match.Groups[4].Value;
											Match match5 = regex.Match(str3);
											Match match6 = PlayTime.HeadTimeTagRegex.Match(str3);
											Match match7 = PlayTime.HeadTimeTagRegex.Match(match5.Groups[2].Value);
											Match match8 = PlayTime.HeadTimeTagRegex.Match(match5.Groups[3].Value);
											if (match6.Success)
											{
												str1 = string.Concat(str1, match6.Value);
												str2 = string.Concat(str2, match6.Value);
											}
											else if (match5.Groups[1].Length <= 0 && match7.Success)
											{
												str1 = string.Concat(str1, match7.Value);
												str2 = string.Concat(str2, match7.Value);
											}
											else if (match5.Groups[1].Length <= 0 && match8.Success)
											{
												str1 = string.Concat(str1, match8.Value);
												str2 = string.Concat(str2, match8.Value);
											}
										}
									}
									Word word1 = new Word(this, this.DefaultDistanceToRuby, this.IsDefaultSpacingEnabled, this.IsDefaultLikeUgaWord, this.IsDefaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName)
									{
										TimeTaggedText = str1,
										TimeTaggedRuby = str2
									};
									if (word1.Charactors.Count > 0)
									{
										this.Words.Add(word1);
									}
								}
								length = length + (match.Length - match.Groups[4].Length);
							}
							else
							{
								Word word2 = new Word(this, this.DefaultDistanceToRuby, this.IsDefaultSpacingEnabled, this.IsDefaultLikeUgaWord, this.IsDefaultWithoutSing, this.DefaultAngle, this.DefaultFontSetName, this.DefaultColorSetName)
								{
									TimeTaggedText = value.Substring(length)
								};
								if (word2.Charactors.Count <= 0)
								{
									break;
								}
								this.Words.Add(word2);
								break;
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
		public PlayTime ViewEnd
		{
			get
			{
				PlayTime empty;
				try
				{
					PlayTime viewEnd = this.Words[0].ViewEnd;
					foreach (Word word in this.Words)
					{
						if (viewEnd == word.ViewEnd)
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
						foreach (Word word in this.Words)
						{
							word.ViewEnd = value;
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
					PlayTime viewStart = this.Words[0].ViewStart;
					foreach (Word word in this.Words)
					{
						if (viewStart == word.ViewStart)
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
						foreach (Word word in this.Words)
						{
							word.ViewStart = value;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public List<Word> Words
		{
			get;
			set;
		}

		public Line()
		{
			try
			{
				this.Words = new List<Word>();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public Line(Page parentalPage, string timeTagText, double defaultDistanceToRuby, bool isDefaultSpacingEnabled, bool isDefaultLikeUgaWord, bool isDefaultWithoutSing, double defaultAngle, string defaultFontSetName, string defaultColorSetName)
		{
			try
			{
				this.Words = new List<Word>();
				this.ParentalPage = parentalPage;
				this.DefaultDistanceToRuby = defaultDistanceToRuby;
				this.IsDefaultSpacingEnabled = isDefaultSpacingEnabled;
				this.IsDefaultLikeUgaWord = isDefaultLikeUgaWord;
				this.IsDefaultWithoutSing = isDefaultWithoutSing;
				this.DefaultAngle = defaultAngle;
				this.DefaultFontSetName = defaultFontSetName;
				this.DefaultColorSetName = defaultColorSetName;
				this.TimeTaggedText = timeTagText;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Arrange(Point basePoint)
		{
			try
			{
				Point width = basePoint;
				double defaultAngle = this.DefaultAngle * 3.14159265358979 / 180;
				for (int i = 0; i < this.Words.Count; i++)
				{
					this.Words[i].Arrange(width);
					double x = width.X;
					System.Windows.Size wordSize = this.Words[i].WordSize;
					width.X = x + wordSize.Width * Math.Cos(defaultAngle);
					double y = width.Y;
					System.Windows.Size size = this.Words[i].WordSize;
					width.Y = y - size.Width * Math.Sin(defaultAngle);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void Initialize(Page parentalPage)
		{
			try
			{
				this.ParentalPage = parentalPage;
				foreach (Word word in this.Words)
				{
					word.Initialize(this);
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
				foreach (Word word in this.Words)
				{
					word.Move(x, y);
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}