using Kasuga;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows.Input;

namespace 春日
{
	public class ColorExItemViewModel : INotifyPropertyChanged
	{
		private string _typeName;

		private Kasuga.ColorAlpha _colorAlpha;

		private string _widthRatio;

		private IDialogViewModel _parentalViewModel;

		protected ICommand _changeColorAlphaCommand;

		public ICommand ChangeColorAlphaCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._changeColorAlphaCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.ChangeColorAlphaCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.ChangeColorAlphaCommandCanExecute)
						};
						this._changeColorAlphaCommand = delegateCommand;
					}
					command = this._changeColorAlphaCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public Kasuga.ColorAlpha ColorAlpha
		{
			get
			{
				Kasuga.ColorAlpha minValue;
				try
				{
					minValue = this._colorAlpha;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					minValue = Kasuga.ColorAlpha.MinValue;
				}
				return minValue;
			}
			set
			{
				try
				{
					if (this._colorAlpha != value)
					{
						this._colorAlpha = value;
						this.RaisePropertyChanged("ColorAlpha");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public BasicColorExItem ColorExItem
		{
			get
			{
				BasicColorExItem solidColorItem;
				try
				{
					if (this._typeName == SolidColor.TypeName)
					{
						solidColorItem = new SolidColorItem(this.ColorAlpha);
					}
					else if (this._typeName != SplitColor.TypeName)
					{
						solidColorItem = null;
					}
					else
					{
						solidColorItem = new SplitColorItem(this.ColorAlpha, double.Parse(this.WidthRatio));
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					solidColorItem = null;
				}
				return solidColorItem;
			}
		}

		public bool HasError
		{
			get
			{
				bool hasWidthRatioError;
				try
				{
					hasWidthRatioError = this.HasWidthRatioError;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasWidthRatioError = false;
				}
				return hasWidthRatioError;
			}
		}

		public bool HasWidthRatioError
		{
			get
			{
				bool flag;
				try
				{
					flag = (this._typeName != SplitColor.TypeName ? false : !Validations.DoubleValidate(this.WidthRatio, false, false));
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public string WidthRatio
		{
			get
			{
				string empty;
				try
				{
					empty = this._widthRatio;
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
					if (this._widthRatio != value)
					{
						this._widthRatio = value;
						this.RaisePropertyChanged("WidthRatio");
						this.RaisePropertyChanged("HasWidthRatioError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ColorExItemViewModel(BasicColorExItem item, IDialogViewModel parentalViewModel)
		{
			try
			{
				this._colorAlpha = item.ColorAlpha;
				this._parentalViewModel = parentalViewModel;
				if (item.GetType() == typeof(SolidColorItem))
				{
					this._typeName = SolidColor.TypeName;
					this._widthRatio = string.Empty;
				}
				else if (item.GetType() != typeof(SplitColorItem))
				{
					this._typeName = string.Empty;
					this._widthRatio = string.Empty;
				}
				else
				{
					this._typeName = SplitColor.TypeName;
					this._widthRatio = ((SplitColorItem)item).WidthRatio.ToString();
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		protected bool ChangeColorAlphaCommandCanExecute(object parameter)
		{
			bool flag;
			try
			{
				flag = true;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		protected void ChangeColorAlphaCommandExecute(object parameter)
		{
			try
			{
				ColorAlphaViewModel colorAlphaViewModel = new ColorAlphaViewModel(this.ColorAlpha);
				bool? nullable = colorAlphaViewModel.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					this.ColorAlpha = colorAlphaViewModel.ColorAlpha;
				}
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