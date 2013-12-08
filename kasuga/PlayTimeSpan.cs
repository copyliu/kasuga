using System;
using System.Reflection;
using System.Xml.Serialization;

namespace Kasuga
{
	[Serializable]
	public struct PlayTimeSpan
	{
		public static PlayTimeSpan Zero;

		public static PlayTimeSpan Empty;

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

		static PlayTimeSpan()
		{
			PlayTimeSpan.Zero = new PlayTimeSpan(new double?(0));
			PlayTimeSpan.Empty = new PlayTimeSpan(null);
		}

		public PlayTimeSpan(double? seconds)
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

		public static PlayTimeSpan operator +(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = span1.Seconds;
				double? seconds1 = span2.Seconds;
				if (seconds.HasValue & seconds1.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault() + (double)seconds1.GetValueOrDefault());
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

		public static PlayTimeSpan operator /(PlayTimeSpan span, double value)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = span.Seconds;
				double num = value;
				if (seconds.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault() / num);
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

		public static bool operator ==(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			bool flag;
			try
			{
				double? seconds = span1.Seconds;
				double? nullable = span2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? false : seconds.HasValue == nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator >(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			bool flag;
			try
			{
				double? seconds = span1.Seconds;
				double? nullable = span2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() <= (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator >=(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			bool flag;
			try
			{
				double? seconds = span1.Seconds;
				double? nullable = span2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() < (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator !=(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			bool flag;
			try
			{
				double? seconds = span1.Seconds;
				double? nullable = span2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() != (double)nullable.GetValueOrDefault() ? true : seconds.HasValue != nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator <(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			bool flag;
			try
			{
				double? seconds = span1.Seconds;
				double? nullable = span2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() >= (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static bool operator <=(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			bool flag;
			try
			{
				double? seconds = span1.Seconds;
				double? nullable = span2.Seconds;
				flag = ((double)seconds.GetValueOrDefault() > (double)nullable.GetValueOrDefault() ? false : seconds.HasValue & nullable.HasValue);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		public static PlayTimeSpan operator *(PlayTimeSpan span, double value)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = span.Seconds;
				double num = value;
				if (seconds.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault() * num);
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

		public static PlayTimeSpan operator -(PlayTimeSpan span1, PlayTimeSpan span2)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = span1.Seconds;
				double? seconds1 = span2.Seconds;
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

		public static PlayTimeSpan operator -(PlayTimeSpan span)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = span.Seconds;
				if (seconds.HasValue)
				{
					nullable = new double?(-(double)seconds.GetValueOrDefault());
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

		public static PlayTimeSpan operator +(PlayTimeSpan span)
		{
			PlayTimeSpan playTimeSpan;
			double? nullable;
			try
			{
				double? seconds = span.Seconds;
				if (seconds.HasValue)
				{
					nullable = new double?((double)seconds.GetValueOrDefault());
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
	}
}