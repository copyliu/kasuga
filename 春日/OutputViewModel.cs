using Kasuga;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace 春日
{
	public class OutputViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private Catalog<BasicOutput> _outputCatalog;

		private string _name;

		private string _typeName;

		private object _detail;

		private ObservableCollection<string> _typeNames;

		private bool _isEdit;

		private OutputWindow _dialog;

		private ICommand _okCommand;

		private ICommand _cancelCommand;

		private ICommand _detailCommand;

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

		public object Detail
		{
			get
			{
				object obj;
				try
				{
					obj = this._detail;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					obj = null;
				}
				return obj;
			}
			set
			{
				try
				{
					if (this._detail != value)
					{
						this._detail = value;
						this.RaisePropertyChanged("Detail");
						this.RaisePropertyChanged("HasDetailError");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ICommand DetailCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._detailCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.DetailCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.DetailCommandCanExecute)
						};
						this._detailCommand = delegateCommand;
					}
					command = this._detailCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public bool HasDetailError
		{
			get
			{
				bool flag;
				bool flag1;
				try
				{
					if (this.TypeName != (new BorderWipeWithLeadOutput()).TypeName)
					{
						flag1 = false;
					}
					else
					{
						flag1 = (this.Detail == null ? true : this.Detail.GetType() != typeof(List<LeadEffect>));
					}
					flag = flag1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasNameError
		{
			get
			{
				bool flag;
				try
				{
					flag = (this._isEdit || !this._outputCatalog.IsExist(this.Name) ? this.Name == string.Empty : true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public string Name
		{
			get
			{
				string empty;
				try
				{
					empty = this._name;
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
					if (this._name != value)
					{
						this._name = value;
						this.RaisePropertyChanged("Name");
						this.RaisePropertyChanged("HasNameError");
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

		public BasicOutput Output
		{
			get
			{
				BasicOutput borderWipeOutput;
				try
				{
					if (this._typeName == (new BorderWipeOutput()).TypeName)
					{
						borderWipeOutput = new BorderWipeOutput(this.Name);
					}
					else if (this._typeName != (new BorderWipeWithLeadOutput()).TypeName)
					{
						borderWipeOutput = null;
					}
					else
					{
						LeadEffect item = ((List<LeadEffect>)this.Detail)[0];
						LeadEffect leadEffect = ((List<LeadEffect>)this.Detail)[1];
						borderWipeOutput = new BorderWipeWithLeadOutput(this.Name, item, leadEffect);
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					borderWipeOutput = null;
				}
				return borderWipeOutput;
			}
		}

		public string TypeName
		{
			get
			{
				string empty;
				try
				{
					empty = this._typeName;
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
					if (this._typeName != value)
					{
						this._typeName = value;
						this.RaisePropertyChanged("TypeName");
						((DelegateCommand)this.OkCommand).RaiseCanExecuteChanged();
						((DelegateCommand)this.DetailCommand).RaiseCanExecuteChanged();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ObservableCollection<string> TypeNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._typeNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public OutputViewModel(Catalog<BasicOutput> outputCatalog, BasicOutput output, bool isEdit)
		{
			try
			{
				this._outputCatalog = outputCatalog;
				if (output != null)
				{
					this._name = output.Name;
				}
				else
				{
					this._name = string.Empty;
					output = BasicOutput.Default;
				}
				this._typeName = output.TypeName;
				this._detail = output.Detail;
				this._typeNames = new ObservableCollection<string>()
				{
					(new BorderWipeOutput()).TypeName,
					(new BorderWipeWithLeadOutput()).TypeName
				};
				this._isEdit = isEdit;
				this._dialog = new OutputWindow(this);
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

		private bool DetailCommandCanExecute(object parameter)
		{
			bool typeName;
			try
			{
				typeName = this.TypeName != (new BorderWipeOutput()).TypeName;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				typeName = false;
			}
			return typeName;
		}

		private void DetailCommandExecute(object parameter)
		{
			LeadEffect slideLeadIn;
			LeadEffect slideLeadOut;
			try
			{
				if (this.TypeName == (new BorderWipeWithLeadOutput()).TypeName)
				{
					if (this.Detail == null || !(this.Detail.GetType() == typeof(List<LeadEffect>)))
					{
						slideLeadIn = LeadEffect.SlideLeadIn;
						slideLeadOut = LeadEffect.SlideLeadOut;
					}
					else
					{
						slideLeadIn = ((List<LeadEffect>)this.Detail)[0];
						slideLeadOut = ((List<LeadEffect>)this.Detail)[1];
					}
					LeadEffectSetViewModel leadEffectSetViewModel = new LeadEffectSetViewModel(slideLeadIn, slideLeadOut);
					bool? nullable = leadEffectSetViewModel.ShowDialog();
					if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
					{
						this.Detail = new List<LeadEffect>()
						{
							leadEffectSetViewModel.LeadInEffect,
							leadEffectSetViewModel.LeadOutEffect
						};
					}
				}
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
				flag = (this.HasNameError ? false : !this.HasDetailError);
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