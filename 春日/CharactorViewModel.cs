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
	public class CharactorViewModel : INotifyPropertyChanged
	{
		protected Kasuga.Charactor _charactor;

		protected MainViewModel _parentalViewModel;

		public string Angle
		{
			get
			{
				string str;
				try
				{
					str = this._charactor.Angle.ToString("F1");
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
					if (double.TryParse(value, out num) && this._charactor.Angle != num)
					{
						this._charactor.Angle = num;
						this.RaisePropertyChanged("Angle");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public char Char
		{
			get
			{
				char chr;
				try
				{
					chr = this._charactor.Char;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					chr = '\0';
				}
				return chr;
			}
		}

		public Kasuga.Charactor Charactor
		{
			get
			{
				Kasuga.Charactor charactor;
				try
				{
					charactor = this._charactor;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					charactor = null;
				}
				return charactor;
			}
		}

		public string ColorSetName
		{
			get
			{
				string colorSetName;
				try
				{
					colorSetName = this._charactor.ColorSetName;
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
					if (this._charactor.ColorSetName != value)
					{
						this._charactor.ColorSetName = value;
						this.RaisePropertyChanged("ColorSetName");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
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
					foreach (string name in this._charactor.ParentalSub.ColorSetCatalog.Names)
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

		public string FontSetName
		{
			get
			{
				string fontSetName;
				try
				{
					fontSetName = this._charactor.FontSetName;
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
					if (this._charactor.FontSetName != value)
					{
						this._charactor.FontSetName = value;
						this.RaisePropertyChanged("FontSetName");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
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
					foreach (string name in this._charactor.ParentalSub.FontSetCatalog.Names)
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

		public bool IsSolidSingEnd
		{
			get
			{
				bool isSolidSingEnd;
				try
				{
					isSolidSingEnd = this._charactor.IsSolidSingEnd;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isSolidSingEnd = false;
				}
				return isSolidSingEnd;
			}
			set
			{
				try
				{
					if (this._charactor.IsSolidSingEnd != value)
					{
						this._charactor.IsSolidSingEnd = value;
						this.RaisePropertyChanged("IsSolidSingEnd");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsSolidSingStart
		{
			get
			{
				bool isSolidSingStart;
				try
				{
					isSolidSingStart = this._charactor.IsSolidSingStart;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isSolidSingStart = false;
				}
				return isSolidSingStart;
			}
			set
			{
				try
				{
					if (this._charactor.IsSolidSingStart != value)
					{
						this._charactor.IsSolidSingStart = value;
						this.RaisePropertyChanged("IsSolidSingStart");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool IsWithoutSing
		{
			get
			{
				bool isWithoutSing;
				try
				{
					isWithoutSing = this._charactor.IsWithoutSing;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					isWithoutSing = false;
				}
				return isWithoutSing;
			}
			set
			{
				try
				{
					if (this._charactor.IsWithoutSing != value)
					{
						this._charactor.IsWithoutSing = value;
						this.RaisePropertyChanged("IsWithoutSing");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string Kind
		{
			get
			{
				string empty;
				try
				{
					CharactorKind kind = this._charactor.Kind;
					if (kind != CharactorKind.Text)
					{
						empty = (kind != CharactorKind.Ruby ? string.Empty : "ルビ");
					}
					else
					{
						empty = "本文";
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

		public string LeftBottom
		{
			get
			{
				string empty;
				try
				{
					Point leftBottom = this._charactor.LeftBottom;
					string str = leftBottom.X.ToString("F1");
					double y = leftBottom.Y;
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
						this._charactor.LeftBottom = new Point(num, num1);
						this.RaisePropertyChanged("LeftBottom");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string LeftTop
		{
			get
			{
				string empty;
				try
				{
					Point leftTop = this._charactor.LeftTop;
					string str = leftTop.X.ToString("F1");
					double y = leftTop.Y;
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
						this._charactor.LeftTop = new Point(num, num1);
						this.RaisePropertyChanged("LeftTop");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string RightBottom
		{
			get
			{
				string empty;
				try
				{
					Point rightBottom = this._charactor.RightBottom;
					string str = rightBottom.X.ToString("F1");
					double y = rightBottom.Y;
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
						this._charactor.RightBottom = new Point(num, num1);
						this.RaisePropertyChanged("RightBottom");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string RightTop
		{
			get
			{
				string empty;
				try
				{
					Point rightTop = this._charactor.RightTop;
					string str = rightTop.X.ToString("F1");
					double y = rightTop.Y;
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
						this._charactor.RightTop = new Point(num, num1);
						this.RaisePropertyChanged("RightTop");
						this._parentalViewModel.ArrangeTextFromCharactorsGrid();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string SingDuration
		{
			get
			{
				string empty;
				try
				{
					PlayTimeSpan singDuration = this._charactor.SingDuration;
					empty = (!singDuration.IsEmpty ? ((double)singDuration.Seconds.Value).ToString("F2") : string.Empty);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public string SingEnd
		{
			get
			{
				string timeTag;
				try
				{
					timeTag = this._charactor.SingEnd.TimeTag;
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
					if (this._charactor.SingEnd != playTime)
					{
						this._charactor.SingEnd = playTime;
						this.RaisePropertyChanged("SingEnd");
						if (!playTime.IsEmpty)
						{
							this.IsSolidSingEnd = true;
						}
						else
						{
							this.IsSolidSingEnd = false;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string SingStart
		{
			get
			{
				string timeTag;
				try
				{
					timeTag = this._charactor.SingStart.TimeTag;
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
					if (this._charactor.SingStart != playTime)
					{
						this._charactor.SingStart = playTime;
						this.RaisePropertyChanged("SingStart");
						if (!playTime.IsEmpty)
						{
							this.IsSolidSingStart = true;
						}
						else
						{
							this.IsSolidSingStart = false;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public string ViewDuration
		{
			get
			{
				string empty;
				try
				{
					PlayTimeSpan viewDuration = this._charactor.ViewDuration;
					empty = (!viewDuration.IsEmpty ? ((double)viewDuration.Seconds.Value).ToString("F2") : string.Empty);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public string ViewEnd
		{
			get
			{
				string timeTag;
				try
				{
					timeTag = this._charactor.ViewEnd.TimeTag;
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
					if (this._charactor.ViewEnd != playTime)
					{
						this._charactor.ViewEnd = playTime;
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
					timeTag = this._charactor.ViewStart.TimeTag;
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
					if (this._charactor.ViewStart != playTime)
					{
						this._charactor.ViewStart = playTime;
						this.RaisePropertyChanged("ViewStart");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public CharactorViewModel(Kasuga.Charactor charactor, MainViewModel parentalViewModel)
		{
			try
			{
				this._charactor = charactor;
				this._parentalViewModel = parentalViewModel;
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
				this._charactor.Move(x, y);
				this.RaisePropertyChanged("LeftTop");
				this.RaisePropertyChanged("RightTop");
				this.RaisePropertyChanged("RightBottom");
				this.RaisePropertyChanged("LeftBottom");
				this._parentalViewModel.ArrangeTextFromCharactorsGrid();
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