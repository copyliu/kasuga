using Kasuga;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;

namespace 春日
{
	public class PartViewModel
	{
		protected Kasuga.Part _part;

		protected MainViewModel _parentalViewModel;

		public string AfterMargin
		{
			get
			{
				string empty;
				try
				{
					PlayTimeSpan afterMargin = this._part.AfterMargin;
					empty = (!afterMargin.IsEmpty ? ((double)afterMargin.Seconds.Value).ToString("F2") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						this._part.AfterMargin = new PlayTimeSpan(new double?(num));
						this.RaisePropertyChanged("AfterMargin");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Angle
		{
			get
			{
				string empty;
				try
				{
					double? angle = this._part.Angle;
					empty = (angle.HasValue ? ((double)angle.Value).ToString("F1") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						double? angle = this._part.Angle;
						if (((double)angle.GetValueOrDefault() != num ? true : !angle.HasValue))
						{
							this._part.Angle = new double?(num);
							this.RaisePropertyChanged("Angle");
							this._part.Arrange();
							this._parentalViewModel.ArrangeTextFromPartsGrid();
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ArrangementName
		{
			get
			{
				string arrangementName;
				try
				{
					arrangementName = this._part.ArrangementName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					arrangementName = string.Empty;
				}
				return arrangementName;
			}
			set
			{
				try
				{
					if (this._part.ArrangementName != value)
					{
						this._part.ArrangementName = value;
						this.RaisePropertyChanged("ArrangementName");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> ArrangementNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = new ObservableCollection<string>()
					{
						ArrangementLikeJoy.TypeName,
						LineHeadArrangement.TypeName
					};
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public string BasePoint
		{
			get
			{
				string empty;
				try
				{
					Point? basePoint = this._part.BasePoint;
					if (basePoint.HasValue)
					{
						string str = basePoint.Value.X.ToString("F1");
						double y = basePoint.Value.Y;
						empty = string.Concat(str, ", ", y.ToString("F1"));
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
					Match match = (new Regex("(\\-?\\d+\\.?\\d*).*?\\,.*?(\\-?\\d+\\.?\\d*)")).Match(value);
					if (match.Success)
					{
						double num = double.Parse(match.Groups[1].Value);
						double num1 = double.Parse(match.Groups[2].Value);
						this._part.BasePoint = new Point?(new Point(num, num1));
						this.RaisePropertyChanged("BasePoint");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string BeforeMargin
		{
			get
			{
				string empty;
				try
				{
					PlayTimeSpan beforeMargin = this._part.BeforeMargin;
					empty = (!beforeMargin.IsEmpty ? ((double)beforeMargin.Seconds.Value).ToString("F2") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						this._part.BeforeMargin = new PlayTimeSpan(new double?(num));
						this.RaisePropertyChanged("BeforeMargin");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ColorSetName
		{
			get
			{
				string colorSetName;
				try
				{
					colorSetName = this._part.ColorSetName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorSetName = string.Empty;
				}
				return colorSetName;
			}
			set
			{
				try
				{
					if (this._part.ColorSetName != value)
					{
						this._part.ColorSetName = value;
						this.RaisePropertyChanged("ColorSetName");
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> ColorSetNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					ObservableCollection<string> observableCollection1 = new ObservableCollection<string>();
					foreach (string name in this._part.ParentalSub.ColorSetCatalog.Names)
					{
						observableCollection1.Add(name);
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public string DistanceToNextLine
		{
			get
			{
				string empty;
				try
				{
					double? distanceToNextLine = this._part.DistanceToNextLine;
					empty = (distanceToNextLine.HasValue ? ((double)distanceToNextLine.Value).ToString("F1") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						double? distanceToNextLine = this._part.DistanceToNextLine;
						if (((double)distanceToNextLine.GetValueOrDefault() != num ? true : !distanceToNextLine.HasValue))
						{
							this._part.DistanceToNextLine = new double?(num);
							this.RaisePropertyChanged("DistanceToNextLine");
							this._part.Arrange();
							this._parentalViewModel.ArrangeTextFromPartsGrid();
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string DistanceToRuby
		{
			get
			{
				string empty;
				try
				{
					double? distanceToRuby = this._part.DistanceToRuby;
					empty = (distanceToRuby.HasValue ? ((double)distanceToRuby.Value).ToString("F1") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						double? distanceToRuby = this._part.DistanceToRuby;
						if (((double)distanceToRuby.GetValueOrDefault() != num ? true : !distanceToRuby.HasValue))
						{
							this._part.DistanceToRuby = new double?(num);
							this.RaisePropertyChanged("DistanceToRuby");
							this._part.Arrange();
							this._parentalViewModel.ArrangeTextFromPartsGrid();
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string FontSetName
		{
			get
			{
				string fontSetName;
				try
				{
					fontSetName = this._part.FontSetName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					fontSetName = string.Empty;
				}
				return fontSetName;
			}
			set
			{
				try
				{
					if (this._part.FontSetName != value)
					{
						this._part.FontSetName = value;
						this.RaisePropertyChanged("FontSetName");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> FontSetNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					ObservableCollection<string> observableCollection1 = new ObservableCollection<string>();
					foreach (string name in this._part.ParentalSub.FontSetCatalog.Names)
					{
						observableCollection1.Add(name);
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public bool? IsCenteringEnabled
		{
			get
			{
				bool? isCenteringEnabled;
				try
				{
					isCenteringEnabled = this._part.IsCenteringEnabled;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isCenteringEnabled = new bool?(false);
				}
				return isCenteringEnabled;
			}
			set
			{
				try
				{
					bool? isCenteringEnabled = this._part.IsCenteringEnabled;
					bool? nullable = value;
					if ((isCenteringEnabled.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isCenteringEnabled.HasValue != nullable.HasValue))
					{
						this._part.IsCenteringEnabled = value;
						this.RaisePropertyChanged("IsCenteringEnabled");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool? IsLikeUgaWord
		{
			get
			{
				bool? isLikeUgaWord;
				try
				{
					isLikeUgaWord = this._part.IsLikeUgaWord;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isLikeUgaWord = new bool?(false);
				}
				return isLikeUgaWord;
			}
			set
			{
				try
				{
					bool? isLikeUgaWord = this._part.IsLikeUgaWord;
					bool? nullable = value;
					if ((isLikeUgaWord.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isLikeUgaWord.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._part.IsLikeUgaWord = value;
						this.RaisePropertyChanged("IsLikeUgaWord");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool? IsSpacingEnabled
		{
			get
			{
				bool? isSpacingEnabled;
				try
				{
					isSpacingEnabled = this._part.IsSpacingEnabled;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isSpacingEnabled = new bool?(false);
				}
				return isSpacingEnabled;
			}
			set
			{
				try
				{
					bool? isSpacingEnabled = this._part.IsSpacingEnabled;
					bool? nullable = value;
					if ((isSpacingEnabled.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isSpacingEnabled.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._part.IsSpacingEnabled = value;
						this.RaisePropertyChanged("IsSpacingEnabled");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
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
			get
			{
				bool isTopBase;
				try
				{
					isTopBase = this._part.IsTopBase;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isTopBase = false;
				}
				return isTopBase;
			}
			set
			{
				try
				{
					if (this._part.IsTopBase != value)
					{
						this._part.IsTopBase = value;
						this.RaisePropertyChanged("IsTopBase");
						this._part.Arrange();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool? IsWithoutSing
		{
			get
			{
				bool? isWithoutSing;
				try
				{
					isWithoutSing = this._part.IsWithoutSing;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isWithoutSing = new bool?(false);
				}
				return isWithoutSing;
			}
			set
			{
				try
				{
					bool? isWithoutSing = this._part.IsWithoutSing;
					bool? nullable = value;
					if ((isWithoutSing.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isWithoutSing.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._part.IsWithoutSing = value;
						this.RaisePropertyChanged("IsWithoutSing");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string MinOverlapping
		{
			get
			{
				string empty;
				try
				{
					double? minOverlapping = this._part.MinOverlapping;
					empty = (minOverlapping.HasValue ? ((double)minOverlapping.Value).ToString("F1") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						double? minOverlapping = this._part.MinOverlapping;
						if (((double)minOverlapping.GetValueOrDefault() != num ? true : !minOverlapping.HasValue))
						{
							this._part.MinOverlapping = new double?(num);
							this.RaisePropertyChanged("MinOverlapping");
							this._part.Arrange();
							this._parentalViewModel.ArrangeTextFromPartsGrid();
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string OutputName
		{
			get
			{
				string outputName;
				try
				{
					outputName = this._part.OutputName;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					outputName = string.Empty;
				}
				return outputName;
			}
			set
			{
				try
				{
					if (this._part.OutputName != value)
					{
						this._part.OutputName = value;
						this.RaisePropertyChanged("OutputName");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> OutputNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					ObservableCollection<string> observableCollection1 = new ObservableCollection<string>();
					foreach (string name in this._part.ParentalSub.OutputCatalog.Names)
					{
						observableCollection1.Add(name);
					}
					observableCollection = observableCollection1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public Kasuga.Part Part
		{
			get
			{
				Kasuga.Part part;
				try
				{
					part = this._part;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					part = null;
				}
				return part;
			}
		}

		public string TimeTaggedText
		{
			get
			{
				string timeTaggedText;
				try
				{
					timeTaggedText = this._part.TimeTaggedText;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					timeTaggedText = string.Empty;
				}
				return timeTaggedText;
			}
			set
			{
				try
				{
					string str = value.Replace("\\N", Environment.NewLine);
					if (this._part.TimeTaggedText != str)
					{
						this._part.TimeTaggedText = str;
						this.RaisePropertyChanged("TimeTaggedText");
						this._part.Arrange();
						this._part.PutSingTimes();
						foreach (Word word in this._part.Words)
						{
							word.PutRubySingTime();
						}
						this._part.PutViewTimes();
						this._parentalViewModel.UpdatePagesGrid();
						this._parentalViewModel.UpdateLinesGrid();
						this._parentalViewModel.UpdateWordsGrid();
						this._parentalViewModel.UpdateCharactorsGrid();
						this._parentalViewModel.ArrangeTextFromPartsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string UsableWidth
		{
			get
			{
				string empty;
				try
				{
					double? usableWidth = this._part.UsableWidth;
					empty = (usableWidth.HasValue ? ((double)usableWidth.Value).ToString("F1") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						double? usableWidth = this._part.UsableWidth;
						if (((double)usableWidth.GetValueOrDefault() != num ? true : !usableWidth.HasValue))
						{
							this._part.UsableWidth = new double?(num);
							this.RaisePropertyChanged("UsableWidth");
							this._part.Arrange();
							this._parentalViewModel.ArrangeTextFromPartsGrid();
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ViewInterval
		{
			get
			{
				string empty;
				try
				{
					PlayTimeSpan viewInterval = this._part.ViewInterval;
					empty = (!viewInterval.IsEmpty ? ((double)viewInterval.Seconds.Value).ToString("F2") : string.Empty);
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
				double num;
				try
				{
					if (double.TryParse(value, out num))
					{
						this._part.ViewInterval = new PlayTimeSpan(new double?(num));
						this.RaisePropertyChanged("ViewInterval");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public PartViewModel(Kasuga.Part part, MainViewModel parentalViewModel)
		{
			try
			{
				this._part = part;
				this._parentalViewModel = parentalViewModel;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void RaiseColorSetNamesChanged()
		{
			try
			{
				this.RaisePropertyChanged("ColorSetNames");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void RaiseFontSetNamesChanged()
		{
			try
			{
				this.RaisePropertyChanged("FontSetNames");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public void RaiseOutputNamesChanged()
		{
			try
			{
				this.RaisePropertyChanged("OutputNames");
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		protected void RaisePropertyChanged(string propertyName)
		{
			try
			{
				PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
				if (propertyChangedEventHandler != null)
				{
					propertyChangedEventHandler(this, new PropertyChangedEventArgs(propertyName));
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}