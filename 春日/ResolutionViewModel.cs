using Kasuga;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace 春日
{
	public class ResolutionViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private string _width;

		private string _height;

		private ResolutionWindow _dialog;

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

		public bool HasHeightError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.IntegerValidate(this.Height, false, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasWidthError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.IntegerValidate(this.Width, false, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public string Height
		{
			get
			{
				string empty;
				try
				{
					empty = this._height;
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
					if (this._height != value)
					{
						this._height = value;
						this.RaisePropertyChanged("Height");
						this.RaisePropertyChanged("HasHeightError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
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

		public Size Resolution
		{
			get
			{
				Size size;
				try
				{
					size = new Size((double)int.Parse(this.Width), (double)int.Parse(this.Height));
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					size = Size.Empty;
				}
				return size;
			}
		}

		public string Width
		{
			get
			{
				string empty;
				try
				{
					empty = this._width;
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
					if (this._width != value)
					{
						this._width = value;
						this.RaisePropertyChanged("Width");
						this.RaisePropertyChanged("HasWidthError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ResolutionViewModel(Size resolution)
		{
			try
			{
				this._width = resolution.Width.ToString();
				this._height = resolution.Height.ToString();
				this._dialog = new ResolutionWindow(this);
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
			bool flag;
			try
			{
				flag = (this.HasWidthError ? false : !this.HasHeightError);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
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