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
	public class PageViewModel
	{
		protected Kasuga.Page _page;

		protected MainViewModel _parentalViewModel;

		public string Angle
		{
			get
			{
				string empty;
				try
				{
					double? angle = this._page.Angle;
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
						double? angle = this._page.Angle;
						if (((double)angle.GetValueOrDefault() != num ? true : !angle.HasValue))
						{
							this._page.Angle = new double?(num);
							this.RaisePropertyChanged("Angle");
							this._page.Arrange();
							this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					arrangementName = this._page.ArrangementName;
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
					if (this._page.ArrangementName != value)
					{
						this._page.ArrangementName = value;
						this.RaisePropertyChanged("ArrangementName");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					Point basePoint = this._page.BasePoint;
					string str = basePoint.X.ToString("F1");
					double y = basePoint.Y;
					empty = string.Concat(str, ", ", y.ToString("F1"));
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
						this._page.BasePoint = new Point(num, num1);
						this.RaisePropertyChanged("BasePoint");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					colorSetName = this._page.ColorSetName;
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
					if (this._page.ColorSetName != value)
					{
						this._page.ColorSetName = value;
						this.RaisePropertyChanged("ColorSetName");
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					foreach (string name in this._page.ParentalSub.ColorSetCatalog.Names)
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
				string str;
				try
				{
					str = this._page.DistanceToNextLine.ToString("F1");
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					str = string.Empty;
				}
				return str;
			}
			set
			{
				double num;
				try
				{
					if (double.TryParse(value, out num) && this._page.DistanceToNextLine != num)
					{
						this._page.DistanceToNextLine = num;
						this.RaisePropertyChanged("DistanceToNextLine");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					double? distanceToRuby = this._page.DistanceToRuby;
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
						double? distanceToRuby = this._page.DistanceToRuby;
						if (((double)distanceToRuby.GetValueOrDefault() != num ? true : !distanceToRuby.HasValue))
						{
							this._page.DistanceToRuby = new double?(num);
							this.RaisePropertyChanged("DistanceToRuby");
							this._page.Arrange();
							this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					fontSetName = this._page.FontSetName;
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
					if (this._page.FontSetName != value)
					{
						this._page.FontSetName = value;
						this.RaisePropertyChanged("FontSetName");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					foreach (string name in this._page.ParentalSub.FontSetCatalog.Names)
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

		public bool IsCenteringEnabled
		{
			get
			{
				bool isCenteringEnabled;
				try
				{
					isCenteringEnabled = this._page.IsCenteringEnabled;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isCenteringEnabled = false;
				}
				return isCenteringEnabled;
			}
			set
			{
				try
				{
					if (this._page.IsCenteringEnabled != value)
					{
						this._page.IsCenteringEnabled = value;
						this.RaisePropertyChanged("IsCenteringEnabled");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					isLikeUgaWord = this._page.IsLikeUgaWord;
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
					bool? isLikeUgaWord = this._page.IsLikeUgaWord;
					bool? nullable = value;
					if ((isLikeUgaWord.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isLikeUgaWord.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._page.IsLikeUgaWord = value;
						this.RaisePropertyChanged("IsLikeUgaWord");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					isSpacingEnabled = this._page.IsSpacingEnabled;
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
					bool? isSpacingEnabled = this._page.IsSpacingEnabled;
					bool? nullable = value;
					if ((isSpacingEnabled.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isSpacingEnabled.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._page.IsSpacingEnabled = value;
						this.RaisePropertyChanged("IsSpacingEnabled");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
					isWithoutSing = this._page.IsWithoutSing;
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
					bool? isWithoutSing = this._page.IsWithoutSing;
					bool? nullable = value;
					if ((isWithoutSing.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isWithoutSing.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._page.IsWithoutSing = value;
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
				string str;
				try
				{
					str = this._page.MinOverlapping.ToString("F1");
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					str = string.Empty;
				}
				return str;
			}
			set
			{
				double num;
				try
				{
					if (double.TryParse(value, out num) && this._page.MinOverlapping != num)
					{
						this._page.MinOverlapping = num;
						this.RaisePropertyChanged("MinOverlapping");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public Kasuga.Page Page
		{
			get
			{
				Kasuga.Page page;
				try
				{
					page = this._page;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					page = null;
				}
				return page;
			}
		}

		public string TimeTaggedText
		{
			get
			{
				string timeTaggedText;
				try
				{
					timeTaggedText = this._page.TimeTaggedText;
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
					if (this._page.TimeTaggedText != str)
					{
						this._page.TimeTaggedText = str;
						this.RaisePropertyChanged("TimeTaggedText");
						this._page.Arrange();
						this._page.ParentalPart.PutSingTimes();
						foreach (Word word in this._page.Words)
						{
							word.PutRubySingTime();
						}
						this._page.ParentalPart.PutViewTimes();
						this._parentalViewModel.UpdatePartsGrid();
						this._parentalViewModel.UpdateLinesGrid();
						this._parentalViewModel.UpdateWordsGrid();
						this._parentalViewModel.UpdateCharactorsGrid();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
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
				string str;
				try
				{
					str = this._page.UsableWidth.ToString("F1");
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					str = string.Empty;
				}
				return str;
			}
			set
			{
				double num;
				try
				{
					if (double.TryParse(value, out num) && this._page.UsableWidth != num)
					{
						this._page.UsableWidth = num;
						this.RaisePropertyChanged("UsableWidth");
						this._page.Arrange();
						this._parentalViewModel.ArrangeTextFromPagesGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public PageViewModel(Kasuga.Page page, MainViewModel parentalViewModel)
		{
			try
			{
				this._page = page;
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