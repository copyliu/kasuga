using Kasuga;
using System;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace 春日
{
	public class LeadEffectSetViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private LeadEffectViewModel _leadIn;

		private LeadEffectViewModel _leadOut;

		private LeadEffectSetWindow _dialog;

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

		public bool HasLeadInError
		{
			get
			{
				bool hasError;
				try
				{
					hasError = this.LeadIn.HasError;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasError = false;
				}
				return hasError;
			}
		}

		public bool HasLeadOutError
		{
			get
			{
				bool hasError;
				try
				{
					hasError = this.LeadOut.HasError;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasError = false;
				}
				return hasError;
			}
		}

		public LeadEffectViewModel LeadIn
		{
			get
			{
				LeadEffectViewModel leadEffectViewModel;
				try
				{
					leadEffectViewModel = this._leadIn;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					leadEffectViewModel = null;
				}
				return leadEffectViewModel;
			}
		}

		public LeadEffect LeadInEffect
		{
			get
			{
				LeadEffect leadEffect;
				try
				{
					leadEffect = this.LeadIn.LeadEffect;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					leadEffect = null;
				}
				return leadEffect;
			}
		}

		public LeadEffectViewModel LeadOut
		{
			get
			{
				LeadEffectViewModel leadEffectViewModel;
				try
				{
					leadEffectViewModel = this._leadOut;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					leadEffectViewModel = null;
				}
				return leadEffectViewModel;
			}
		}

		public LeadEffect LeadOutEffect
		{
			get
			{
				LeadEffect leadEffect;
				try
				{
					leadEffect = this.LeadOut.LeadEffect;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					leadEffect = null;
				}
				return leadEffect;
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

		public LeadEffectSetViewModel(LeadEffect leadIn, LeadEffect leadOut)
		{
			try
			{
				this._leadIn = new LeadEffectViewModel(leadIn, this);
				this._leadOut = new LeadEffectViewModel(leadOut, this);
				this._dialog = new LeadEffectSetWindow(this);
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
				flag = (this.HasLeadInError ? false : !this.HasLeadOutError);
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