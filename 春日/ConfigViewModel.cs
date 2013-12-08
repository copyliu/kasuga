using Kasuga;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace 春日
{
	public class ConfigViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private string _viewRatio;

		private bool _doesShowBeforeColor;

		private ConfigWindow _dialog;

		private ICommand _okCommand;

		private ICommand _cancelCommand;

		public ICommand CancelCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._cancelCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.CancelCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.CancelCommandCanExecute)
						};
						this._cancelCommand = delegateCommand;
					}
					command = this._cancelCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public 春日.Config Config
		{
			get
			{
				春日.Config config;
				try
				{
					config = new 春日.Config(double.Parse(this.ViewRatio), this.DoesShowBeforeColor);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					config = null;
				}
				return config;
			}
		}

		public bool DoesShowAfterColor
		{
			get
			{
				bool flag;
				try
				{
					flag = !this._doesShowBeforeColor;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
			set
			{
				try
				{
					if (this._doesShowBeforeColor != !value)
					{
						this._doesShowBeforeColor = !value;
						this.RaisePropertyChanged("DoesShowBeforeColor");
						this.RaisePropertyChanged("DoesShowAfterColor");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool DoesShowBeforeColor
		{
			get
			{
				bool flag;
				try
				{
					flag = this._doesShowBeforeColor;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
			set
			{
				try
				{
					if (this._doesShowBeforeColor != value)
					{
						this._doesShowBeforeColor = value;
						this.RaisePropertyChanged("DoesShowBeforeColor");
						this.RaisePropertyChanged("DoesShowAfterColor");
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool HasViewRatioError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.DoubleValidate(this.ViewRatio, false, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public ICommand OkCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._okCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.OkCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.OkCommandCanExecute)
						};
						this._okCommand = delegateCommand;
					}
					command = this._okCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public string ViewRatio
		{
			get
			{
				string empty;
				try
				{
					empty = this._viewRatio;
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
					if (this._viewRatio != value)
					{
						this._viewRatio = value;
						this.RaisePropertyChanged("ViewRatio");
						this.RaisePropertyChanged("HasViewRatioError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ConfigViewModel(春日.Config config)
		{
			try
			{
				this._viewRatio = config.ViewRatio.ToString();
				this._doesShowBeforeColor = config.DoesShowBeforeColor;
				this._dialog = new ConfigWindow(this);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool CancelCommandCanExecute(object parameter)
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

		private void CancelCommandExecute(object parameter)
		{
			try
			{
				this._dialog.DialogResult = new bool?(false);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool OkCommandCanExecute(object parameter)
		{
			bool hasViewRatioError;
			try
			{
				hasViewRatioError = !this.HasViewRatioError;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				hasViewRatioError = false;
			}
			return hasViewRatioError;
		}

		private void OkCommandExecute(object parameter)
		{
			try
			{
				this._dialog.DialogResult = new bool?(true);
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

		public bool? ShowDialog()
		{
			bool? nullable;
			try
			{
				nullable = this._dialog.ShowDialog();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				nullable = new bool?(false);
			}
			return nullable;
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}