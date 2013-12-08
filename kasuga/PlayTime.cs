using System;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public struct PlayTime
	{
		public static PlayTime Zero;

		public static PlayTime Empty;

		public static Regex TimeTagRegex;

		public static Regex HeadTimeTagRegex;

		public static Regex FootTimeTagRegex;

		public static Regex HeadSyllableRegex;

		private double? _seconds;

		[XmlIgnore]
		public bool IsEmpty
		{
			get
			{
				bool hasValue;
				try
				{
					hasValue = !this.Seconds.HasValue;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasValue = false;
				}
				return hasValue;
			}
		}

		[XmlIgnore]
		public double? Seconds
		{
			get
			{
				double? nullable;
				try
				{
					nullable = this._seconds;
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
					this._seconds = value;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlText]
		public string SecondsString
		{
			get
			{
				string str;
				try
				{
					str = (!this.IsEmpty ? this.Seconds.ToString() : "Empty");
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
				double num;
				try
				{
					if (!double.TryParse(value, out num))
					{
						this.Seconds = null;
					}
					else
					{
						this.Seconds = new double?(num);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		[XmlIgnore]
		public string TimeTag
		{
			get
			{
				string empty;
				try
				{
					if (!this.IsEmpty)
					{
						double? seconds = this.Seconds;
						int num = (int)Math.Floor((double)seconds.Value / 60);
						double? nullable = this.Seconds;
						int num1 = (int)Math.Floor((double)nullable.Value - (double)num * 60);
						double? seconds1 = this.Seconds;
						int num2 = (int)Math.Floor(((double)seconds1.Value - ((double)num * 60 + (double)num1)) * 100);
						string[] str = new string[] { "[", num.ToString("D2"), ":", num1.ToString("D2"), ":", num2.ToString("D2"), "]" };
						empty = string.Concat(str);
					}
					else
					{
						empty = string.Empty;
					}
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
					this = PlayTime.FromTimeTag(value);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		static PlayTime()
		{
			PlayTime.Zero = new PlayTime(new double?(0));
			PlayTime.Empty = new PlayTime(null);
			PlayTime.TimeTagRegex = new Regex("\\[\\d{2}:[0-5]{1}\\d{1}:\\d{2}\\]");
			PlayTime.HeadTimeTagRegex = new Regex("^\\[\\d{2}:[0-5]{1}\\d{1}:\\d{2}\\]");
			PlayTime.FootTimeTagRegex = new Regex("\\[\\d{2}:[0-5]{1}\\d{1}:\\d{2}\\]$");
			PlayTime.HeadSyllableRegex = new Regex("^(\\[\\d{2}:[0-5]{1}\\d{1}:\\d{2}\\])(.*?)(\\[\\d{2}:[0-5]{1}\\d{1}:\\d{2}\\])");
		}

		public PlayTime(double? seconds)
		{
			try
			{
				this._seconds = seconds;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				this._seconds = null;
			}
		}

		public override bool Equals(object obj)
		{
			bool flag;
			try
			{
				flag = this.Equals(obj);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static PlayTime FromTimeTag(string timeTag)
		{
			PlayTime playTime;
			try
			{
				Match match = (new Regex("^\\[(\\d{2}):([0-5]{1}\\d{1}):(\\d{2})\\]$")).Match(timeTag);
				if (match.Success)
				{
					double num = (double)int.Parse(match.Groups[1].Value);
					double num1 = (double)int.Parse(match.Groups[2].Value);
					double num2 = (double)int.Parse(match.Groups[3].Value);
					playTime = new PlayTime(new double?(num * 60 + num1 + num2 / 100));
				}
				else
				{
					playTime = PlayTime.Empty;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				playTime = PlayTime.Empty;
			}
			return playTime;
		}

		public override int GetHashCode()
		{
			int hashCode;
			try
			{
				hashCode = this.GetHashCode();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				hashCode = 0;
			}
			return hashCode;
		}

		public static bool IsTimeTag(string str)
		{
			bool flag;
			try
			{
				flag = (new Regex("^\\[\\d{2}:[0-5]{1}\\d{1}:\\d{2}\\]$")).IsMatch(str);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static PlayTime Max(PlayTime time1, PlayTime time2)
		{
			PlayTime empty;
			try
			{
				if (time1 == PlayTime.Empty && time2 == PlayTime.Empty)
				{
					empty = PlayTime.Empty;
				}
				else if (time1 == PlayTime.Empty)
				{
					empty = time2;
				}
				else if (time2 != PlayTime.Empty)
				{
					empty = (time1 < time2 ? time2 : time1);
				}
				else
				{
					empty = time1;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				empty = PlayTime.Empty;
			}
			return empty;
		}

		public static PlayTime Min(PlayTime time1, PlayTime time2)
		{
			PlayTime empty;
			try
			{
				if (time1 == PlayTime.Empty && time2 == PlayTime.Empty)
				{
					empty = PlayTime.Empty;
				}
				else if (time1 == PlayTime.Empty)
				{
					empty = time2;
				}
				else if (time2 != PlayTime.Empty)
				{
					empty = (time1 > time2 ? time2 : time1);
				}
				else
				{
					empty = time1;
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				empty = PlayTime.Empty;
			}
			return empty;
		}

		public static PlayTime operator +(PlayTime time, PlayTimeSpan span)
		{
			PlayTime playTime;
			double? nullable;
			try
			{
				double? seconds = time.Seconds;
				double? seconds1 = span.Seconds;
				if (seconds.HasValue & seconds1.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault() + (double)seconds1.GetValueOrDefault());
				}
				else
				{
					nullable = null;
				}
				playTime = new PlayTime(nullable);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				playTime = PlayTime.Empty;
			}
			return playTime;
		}

		public static bool operator ==(PlayTime time1, PlayTime time2)
		{
			bool flag;
			try
			{
				double? seconds = time1.Seconds;
				double? nullable = time2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? false : seconds.HasValue == nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator >(PlayTime time1, PlayTime time2)
		{
			bool flag;
			try
			{
				double? seconds = time1.Seconds;
				double? nullable = time2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() <= (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator >=(PlayTime time1, PlayTime time2)
		{
			bool flag;
			try
			{
				double? seconds = time1.Seconds;
				double? nullable = time2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() < (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator !=(PlayTime time1, PlayTime time2)
		{
			bool flag;
			try
			{
				double? seconds = time1.Seconds;
				double? nullable = time2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : seconds.HasValue != nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator <(PlayTime time1, PlayTime time2)
		{
			bool flag;
			try
			{
				double? seconds = time1.Seconds;
				double? nullable = time2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() >= (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator <=(PlayTime time1, PlayTime time2)
		{
			bool flag;
			try
			{
				double? seconds = time1.Seconds;
				double? nullable = time2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() > (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static PlayTime operator -(PlayTime time, PlayTimeSpan span)
		{
			PlayTime playTime;
			double? nullable;
			try
			{
				double? seconds = time.Seconds;
				double? seconds1 = span.Seconds;
				if (seconds.HasValue & seconds1.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault() - (double)seconds1.GetValueOrDefault());
				}
				else
				{
					nullable = null;
				}
				playTime = new PlayTime(nullable);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				playTime = PlayTime.Empty;
			}
			return playTime;
		}

		public static PlayTimeSpan operator -(PlayTime time1, PlayTime time2)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = time1.Seconds;
				double? seconds1 = time2.Seconds;
				if (seconds.HasValue & seconds1.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault() - (double)seconds1.GetValueOrDefault());
				}
				else
				{
					nullable = null;
				}
				playTimeSpan = new PlayTimeSpan(nullable);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				playTimeSpan = PlayTimeSpan.Empty;
			}
			return playTimeSpan;
		}

		public override string ToString()
		{
			string empty;
			try
			{
				if (!this.IsEmpty)
				{
					double? seconds = this.Seconds;
					int num = (int)Math.Floor((double)seconds.Value / 3600);
					double? nullable = this.Seconds;
					int num1 = (int)Math.Floor(((double)nullable.Value - (double)num * 60 * 60) / 60);
					double? seconds1 = this.Seconds;
					int num2 = (int)Math.Floor((double)seconds1.Value - ((double)num * 60 * 60 + (double)num1 * 60));
					double? nullable1 = this.Seconds;
					int num3 = (int)Math.Floor(((double)nullable1.Value - ((double)num * 60 * 60 + (double)num1 * 60 + (double)num2)) * 100);
					string[] str = new string[] { num.ToString("D"), ":", num1.ToString("D2"), ":", num2.ToString("D2"), ".", num3.ToString("D2") };
					empty = string.Concat(str);
				}
				else
				{
					empty = string.Empty;
				}
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