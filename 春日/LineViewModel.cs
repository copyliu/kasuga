using Kasuga;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;

namespace 春日
{
	public class LineViewModel
	{
		protected Kasuga.Line _line;

		protected MainViewModel _parentalViewModel;

		public string Angle
		{
			get
			{
				string empty;
				try
				{
					double? angle = this._line.Angle;
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
						double? angle = this._line.Angle;
						if (((double)angle.GetValueOrDefault() != num ? true : !angle.HasValue))
						{
							this._line.Angle = new double?(num);
							this.RaisePropertyChanged("Angle");
							this._parentalViewModel.ArrangeTextFromLinesGrid();
						}
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
					colorSetName = this._line.ColorSetName;
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
					if (this._line.ColorSetName != value)
					{
						this._line.ColorSetName = value;
						this.RaisePropertyChanged("ColorSetName");
						this._parentalViewModel.ArrangeTextFromLinesGrid();
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
					foreach (string name in this._line.ParentalSub.ColorSetCatalog.Names)
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

		public string DistanceToRuby
		{
			get
			{
				string empty;
				try
				{
					double? distanceToRuby = this._line.DistanceToRuby;
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
						double? distanceToRuby = this._line.DistanceToRuby;
						if (((double)distanceToRuby.GetValueOrDefault() != num ? true : !distanceToRuby.HasValue))
						{
							this._line.DistanceToRuby = new double?(num);
							this.RaisePropertyChanged("DistanceToRuby");
							this._line.ParentalPage.Arrange();
							this._parentalViewModel.ArrangeTextFromLinesGrid();
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
					fontSetName = this._line.FontSetName;
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
					if (this._line.FontSetName != value)
					{
						this._line.FontSetName = value;
						this.RaisePropertyChanged("FontSetName");
						this._line.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromLinesGrid();
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
					foreach (string name in this._line.ParentalSub.FontSetCatalog.Names)
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

		public bool? IsLikeUgaWord
		{
			get
			{
				bool? isLikeUgaWord;
				try
				{
					isLikeUgaWord = this._line.IsLikeUgaWord;
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
					bool? isLikeUgaWord = this._line.IsLikeUgaWord;
					bool? nullable = value;
					if ((isLikeUgaWord.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isLikeUgaWord.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._line.IsLikeUgaWord = value;
						this.RaisePropertyChanged("IsLikeUgaWord");
						this._line.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromLinesGrid();
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
					isSpacingEnabled = this._line.IsSpacingEnabled;
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
					bool? isSpacingEnabled = this._line.IsSpacingEnabled;
					bool? nullable = value;
					if ((isSpacingEnabled.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isSpacingEnabled.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._line.IsSpacingEnabled = value;
						this.RaisePropertyChanged("IsSpacingEnabled");
						this._line.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromLinesGrid();
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
					isWithoutSing = this._line.IsWithoutSing;
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
					bool? isWithoutSing = this._line.IsWithoutSing;
					bool? nullable = value;
					if ((isWithoutSing.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isWithoutSing.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._line.IsWithoutSing = value;
						this.RaisePropertyChanged("IsWithoutSing");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public Kasuga.Line Line
		{
			get
			{
				Kasuga.Line line;
				try
				{
					line = this._line;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					line = null;
				}
				return line;
			}
		}

		public string TimeTaggedText
		{
			get
			{
				string timeTaggedText;
				try
				{
					timeTaggedText = this._line.TimeTaggedText;
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
					if (!PlayTime.HeadTimeTagRegex.IsMatch(value))
					{
						PlayTime firstSingStart = this._line.FirstSingStart;
						value = string.Concat(firstSingStart.TimeTag, value);
					}
					if (!PlayTime.FootTimeTagRegex.IsMatch(value))
					{
						PlayTime lastSingEnd = this._line.LastSingEnd;
						value = string.Concat(value, lastSingEnd.TimeTag);
					}
					if (this._line.TimeTaggedText != value)
					{
						this._line.TimeTaggedText = value;
						this.RaisePropertyChanged("TimeTaggedText");
						this._line.ParentalPage.Arrange();
						this._line.ParentalPart.PutSingTimes();
						foreach (Word word in this._line.Words)
						{
							word.PutRubySingTime();
						}
						this._line.ParentalPart.PutViewTimes();
						this._parentalViewModel.UpdatePartsGrid();
						this._parentalViewModel.UpdatePagesGrid();
						this._parentalViewModel.UpdateWordsGrid();
						this._parentalViewModel.UpdateCharactorsGrid();
						this._parentalViewModel.ArrangeTextFromLinesGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ViewEnd
		{
			get
			{
				string timeTag;
				try
				{
					timeTag = this._line.ViewEnd.TimeTag;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					timeTag = string.Empty;
				}
				return timeTag;
			}
			set
			{
				try
				{
					PlayTime playTime = PlayTime.FromTimeTag(value);
					if (this._line.ViewEnd != playTime)
					{
						this._line.ViewEnd = playTime;
						this.RaisePropertyChanged("ViewEnd");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ViewStart
		{
			get
			{
				string timeTag;
				try
				{
					timeTag = this._line.ViewStart.TimeTag;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					timeTag = string.Empty;
				}
				return timeTag;
			}
			set
			{
				try
				{
					PlayTime playTime = PlayTime.FromTimeTag(value);
					if (this._line.ViewStart != playTime)
					{
						this._line.ViewStart = playTime;
						this.RaisePropertyChanged("ViewStart");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public LineViewModel(Kasuga.Line line, MainViewModel parentalViewModel)
		{
			try
			{
				this._line = line;
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