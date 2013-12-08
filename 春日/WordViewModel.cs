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
	public class WordViewModel : INotifyPropertyChanged
	{
		protected Kasuga.Word _word;

		protected MainViewModel _parentalViewModel;

		public string Angle
		{
			get
			{
				string empty;
				try
				{
					double? angle = this._word.Angle;
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
						double? angle = this._word.Angle;
						if (((double)angle.GetValueOrDefault() != num ? true : !angle.HasValue))
						{
							this._word.Angle = new double?(num);
							this.RaisePropertyChanged("Angle");
							this._parentalViewModel.ArrangeTextFromWordsGrid();
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
					colorSetName = this._word.ColorSetName;
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
					if (this._word.ColorSetName != value)
					{
						this._word.ColorSetName = value;
						this.RaisePropertyChanged("ColorSetName");
						this._parentalViewModel.ArrangeTextFromWordsGrid();
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
					foreach (string name in this._word.ParentalSub.ColorSetCatalog.Names)
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
				string str;
				try
				{
					str = this._word.DistanceToRuby.ToString("F1");
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
					if (double.TryParse(value, out num) && this._word.DistanceToRuby != num)
					{
						this._word.DistanceToRuby = num;
						this.RaisePropertyChanged("DistanceToRuby");
						this._word.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromWordsGrid();
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
					fontSetName = this._word.FontSetName;
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
					if (this._word.FontSetName != value)
					{
						this._word.FontSetName = value;
						this.RaisePropertyChanged("FontSetName");
						this._word.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromWordsGrid();
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
					foreach (string name in this._word.ParentalSub.FontSetCatalog.Names)
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

		public bool IsLikeUgaWord
		{
			get
			{
				bool isLikeUgaWord;
				try
				{
					isLikeUgaWord = this._word.IsLikeUgaWord;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isLikeUgaWord = false;
				}
				return isLikeUgaWord;
			}
			set
			{
				try
				{
					if (this._word.IsLikeUgaWord != value)
					{
						this._word.IsLikeUgaWord = value;
						this.RaisePropertyChanged("IsLikeUgaWord");
						this._word.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromWordsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsSpacingEnabled
		{
			get
			{
				bool isSpacingEnabled;
				try
				{
					isSpacingEnabled = this._word.IsSpacingEnabled;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isSpacingEnabled = false;
				}
				return isSpacingEnabled;
			}
			set
			{
				try
				{
					if (this._word.IsSpacingEnabled != value)
					{
						this._word.IsSpacingEnabled = value;
						this.RaisePropertyChanged("IsSpacingEnabled");
						this._word.ParentalPage.Arrange();
						this._parentalViewModel.ArrangeTextFromWordsGrid();
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
					isWithoutSing = this._word.IsWithoutSing;
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
					bool? isWithoutSing = this._word.IsWithoutSing;
					bool? nullable = value;
					if ((isWithoutSing.GetValueOrDefault() != nullable.GetValueOrDefault() ? true : isWithoutSing.HasValue != nullable.HasValue) && value.HasValue)
					{
						this._word.IsWithoutSing = value;
						this.RaisePropertyChanged("IsLikeUgaWord");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string TimeTaggedRuby
		{
			get
			{
				string timeTaggedRuby;
				try
				{
					timeTaggedRuby = this._word.TimeTaggedRuby;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					timeTaggedRuby = string.Empty;
				}
				return timeTaggedRuby;
			}
			set
			{
				try
				{
					if (!PlayTime.HeadTimeTagRegex.IsMatch(value))
					{
						PlayTime firstSingStart = this._word.FirstSingStart;
						value = string.Concat(firstSingStart.TimeTag, value);
					}
					if (!PlayTime.FootTimeTagRegex.IsMatch(value))
					{
						PlayTime lastSingEnd = this._word.LastSingEnd;
						value = string.Concat(value, lastSingEnd.TimeTag);
					}
					if (this._word.TimeTaggedRuby != value)
					{
						this._word.TimeTaggedRuby = value;
						this.RaisePropertyChanged("TimeTaggedRuby");
						this._word.ParentalPage.Arrange();
						this._word.PutRubySingTime();
						this._word.ParentalPart.PutViewTimes();
						this._parentalViewModel.UpdateCharactorsGrid();
						this._parentalViewModel.ArrangeTextFromWordsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string TimeTaggedText
		{
			get
			{
				string timeTaggedText;
				try
				{
					timeTaggedText = this._word.TimeTaggedText;
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
						PlayTime firstSingStart = this._word.FirstSingStart;
						value = string.Concat(firstSingStart.TimeTag, value);
					}
					if (!PlayTime.FootTimeTagRegex.IsMatch(value))
					{
						PlayTime lastSingEnd = this._word.LastSingEnd;
						value = string.Concat(value, lastSingEnd.TimeTag);
					}
					if (this._word.TimeTaggedText != value)
					{
						this._word.TimeTaggedText = value;
						this.RaisePropertyChanged("TimeTaggedText");
						this._word.ParentalPage.Arrange();
						this._word.ParentalPart.PutSingTimes();
						this._word.ParentalPart.PutViewTimes();
						this._parentalViewModel.UpdatePartsGrid();
						this._parentalViewModel.UpdatePagesGrid();
						this._parentalViewModel.UpdateLinesGrid();
						this._parentalViewModel.UpdateCharactorsGrid();
						this._parentalViewModel.ArrangeTextFromWordsGrid();
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
					timeTag = this._word.ViewEnd.TimeTag;
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
					if (this._word.ViewEnd != playTime)
					{
						this._word.ViewEnd = playTime;
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
					timeTag = this._word.ViewStart.TimeTag;
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
					if (this._word.ViewStart != playTime)
					{
						this._word.ViewStart = playTime;
						this.RaisePropertyChanged("ViewStart");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public Kasuga.Word Word
		{
			get
			{
				Kasuga.Word word;
				try
				{
					word = this._word;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					word = null;
				}
				return word;
			}
		}

		public WordViewModel(Kasuga.Word word, MainViewModel parentalViewModel)
		{
			try
			{
				this._word = word;
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