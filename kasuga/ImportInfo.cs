using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows;

namespace Kasuga
{
	public class ImportInfo
	{
		public PlayTimeSpan AfterMargin
		{
			get;
			set;
		}

		public double Angle
		{
			get;
			set;
		}

		public string ArrangementName
		{
			get;
			set;
		}

		public PlayTimeSpan BeforeMargin
		{
			get;
			set;
		}

		public string ColorSetName
		{
			get;
			set;
		}

		public double DistanceToNextLine
		{
			get;
			set;
		}

		public double DistanceToRuby
		{
			get;
			set;
		}

		public string EffectName
		{
			get;
			set;
		}

		public string FileName
		{
			get;
			set;
		}

		public string FontSetName
		{
			get;
			set;
		}

		public bool IsAdd
		{
			get;
			set;
		}

		public bool IsCenteringEnabled
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

		public bool IsTopBase
		{
			get;
			set;
		}

		public bool IsWithoutSing
		{
			get;
			set;
		}

		public Point LeftCorner
		{
			get;
			set;
		}

		public double MinOverlapping
		{
			get;
			set;
		}

		public double UsableWidth
		{
			get;
			set;
		}

		public PlayTimeSpan ViewInterval
		{
			get;
			set;
		}

	    public bool Istxt2ass { get; set; }
        public string FileEncoding { get; set; }

		public ImportInfo(string fileName, bool isAdd, PlayTimeSpan beforeMargin, PlayTimeSpan afterMargin, PlayTimeSpan viewInterval, bool isTopBase, Point leftCorner, double usableWidth, double angle, string arrangementName, bool isCenteringEnabled, double minOverlapping, double distanceToNextLine, double distanceToRuby, bool isSpacingEnabled, bool isLikeUgaWord, string fontSetName, string colorSetName, string effectName, bool isWithoutSing,bool istxt2ass,string fileEncoding)
		{
			try
			{
				this.FileName = fileName;
				this.IsAdd = isAdd;
				this.EffectName = effectName;
				this.BeforeMargin = beforeMargin;
				this.AfterMargin = afterMargin;
				this.ViewInterval = viewInterval;
				this.IsTopBase = isTopBase;
				this.LeftCorner = leftCorner;
				this.UsableWidth = usableWidth;
				this.Angle = angle;
				this.ArrangementName = arrangementName;
				this.IsCenteringEnabled = isCenteringEnabled;
				this.MinOverlapping = minOverlapping;
				this.DistanceToNextLine = distanceToNextLine;
				this.DistanceToRuby = distanceToRuby;
				this.IsSpacingEnabled = isSpacingEnabled;
				this.IsLikeUgaWord = isLikeUgaWord;
				this.IsWithoutSing = isWithoutSing;
				this.FontSetName = fontSetName;
				this.ColorSetName = colorSetName;
			    this.Istxt2ass = istxt2ass;
			    this.FileEncoding = fileEncoding;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}
	}
}