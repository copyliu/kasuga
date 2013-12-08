using Kasuga;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace 春日
{
	public class ColorSetViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private Catalog<Kasuga.ColorSet> _colorCatalog;

		private string _name;

		private ColorExViewModel _innerBefore;

		private ColorExViewModel _innerAfter;

		private ColorExViewModel _borderBefore;

		private ColorExViewModel _borderAfter;

		private ColorExViewModel _shadow;

		private ObservableCollection<string> _colorExNames;

		private bool _isEdit;

		private ColorSetWindow _dialog;

		private ICommand _okCommand;

		private ICommand _cancelCommand;

		public ColorExViewModel BorderAfter
		{
			get
			{
				ColorExViewModel colorExViewModel;
				try
				{
					colorExViewModel = this._borderAfter;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorExViewModel = null;
				}
				return colorExViewModel;
			}
		}

		public ColorExViewModel BorderBefore
		{
			get
			{
				ColorExViewModel colorExViewModel;
				try
				{
					colorExViewModel = this._borderBefore;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorExViewModel = null;
				}
				return colorExViewModel;
			}
		}

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

		public Kasuga.ColorSet ColorSet
		{
			get
			{
				Kasuga.ColorSet colorSet;
				try
				{
					colorSet = new Kasuga.ColorSet(this.Name, this.InnerBefore.ColorEx, this.InnerAfter.ColorEx, this.BorderBefore.ColorEx, this.BorderAfter.ColorEx, this.Shadow.ColorEx);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorSet = null;
				}
				return colorSet;
			}
		}

		public bool HasNameError
		{
			get
			{
				bool flag;
				try
				{
					flag = (this._isEdit || !this._colorCatalog.IsExist(this.Name) ? this.Name == string.Empty : true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public ColorExViewModel InnerAfter
		{
			get
			{
				ColorExViewModel colorExViewModel;
				try
				{
					colorExViewModel = this._innerAfter;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorExViewModel = null;
				}
				return colorExViewModel;
			}
		}

		public ColorExViewModel InnerBefore
		{
			get
			{
				ColorExViewModel colorExViewModel;
				try
				{
					colorExViewModel = this._innerBefore;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorExViewModel = null;
				}
				return colorExViewModel;
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

		public ColorExViewModel Shadow
		{
			get
			{
				ColorExViewModel colorExViewModel;
				try
				{
					colorExViewModel = this._shadow;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					colorExViewModel = null;
				}
				return colorExViewModel;
			}
		}

		public ObservableCollection<string> TypeNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._colorExNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public ColorSetViewModel(Catalog<Kasuga.ColorSet> colorCatalog, Kasuga.ColorSet colorSet, bool isEdit)
		{
			try
			{
				this._colorCatalog = colorCatalog;
				if (colorSet != null)
				{
					this._name = colorSet.Name;
				}
				else
				{
					this._name = string.Empty;
					colorSet = Kasuga.ColorSet.Default;
				}
				this._innerBefore = new ColorExViewModel(colorSet.InnerBeforeColor, this);
				this._innerAfter = new ColorExViewModel(colorSet.InnerAfterColor, this);
				this._borderBefore = new ColorExViewModel(colorSet.BorderBeforeColor, this);
				this._borderAfter = new ColorExViewModel(colorSet.BorderAfterColor, this);
				this._shadow = new ColorExViewModel(colorSet.ShadowColor, this);
				this._colorExNames = new ObservableCollection<string>()
				{
					SolidColor.TypeName,
					SplitColor.TypeName
				};
				this._isEdit = isEdit;
				this._dialog = new ColorSetWindow(this);
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
				flag = (this.HasNameError || this.InnerBefore.HasError || this.InnerAfter.HasError || this.BorderBefore.HasError || this.BorderAfter.HasError ? false : !this.Shadow.HasError);
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