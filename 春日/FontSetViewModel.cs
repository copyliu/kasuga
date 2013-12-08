using Kasuga;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace 春日
{
	public class FontSetViewModel : IDialogViewModel, INotifyPropertyChanged
	{
		private Catalog<Kasuga.FontSet> _fontCatalog;

		private string _name;

		private FontExViewModel _text;

		private FontExViewModel _ruby;

		private ObservableCollection<string> _familyNames;

		private bool _isEdit;

		private FontSetWindow _dialog;

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

		public ObservableCollection<string> FamilyNames
		{
			get
			{
				ObservableCollection<string> observableCollection;
				try
				{
					observableCollection = this._familyNames;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
		}

		public Kasuga.FontSet FontSet
		{
			get
			{
				Kasuga.FontSet fontSet;
				try
				{
					fontSet = new Kasuga.FontSet(this.Name, this.Text.FontEx, this.Ruby.FontEx);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					fontSet = null;
				}
				return fontSet;
			}
		}

		public bool HasNameError
		{
			get
			{
				bool flag;
				try
				{
					flag = (this._isEdit || !this._fontCatalog.IsExist(this.Name) ? this.Name == string.Empty : true);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasRubyError
		{
			get
			{
				bool hasError;
				try
				{
					hasError = this.Ruby.HasError;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasError = false;
				}
				return hasError;
			}
		}

		public bool HasTextError
		{
			get
			{
				bool hasError;
				try
				{
					hasError = this.Text.HasError;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasError = false;
				}
				return hasError;
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

		public FontExViewModel Ruby
		{
			get
			{
				FontExViewModel fontExViewModel;
				try
				{
					fontExViewModel = this._ruby;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					fontExViewModel = null;
				}
				return fontExViewModel;
			}
		}

		public FontExViewModel Text
		{
			get
			{
				FontExViewModel fontExViewModel;
				try
				{
					fontExViewModel = this._text;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					fontExViewModel = null;
				}
				return fontExViewModel;
			}
		}

		public FontSetViewModel(Catalog<Kasuga.FontSet> fontCatalog, Kasuga.FontSet fontSet, bool isEdit)
		{
			string str;
			try
			{
				this._fontCatalog = fontCatalog;
				if (fontSet != null)
				{
					this._name = fontSet.Name;
				}
				else
				{
					this._name = string.Empty;
					fontSet = Kasuga.FontSet.Default;
				}
				this._text = new FontExViewModel(fontSet.Text, this);
				this._ruby = new FontExViewModel(fontSet.Ruby, this);
				this._familyNames = new ObservableCollection<string>();
				foreach (FontFamily systemFontFamily in Fonts.SystemFontFamilies)
				{
					if (!systemFontFamily.FamilyNames.TryGetValue(XmlLanguage.GetLanguage("ja-JP"), out str))
					{
						this._familyNames.Add(systemFontFamily.Source);
					}
					else
					{
						this._familyNames.Add(str);
					}
				}
				this._isEdit = isEdit;
				this._dialog = new FontSetWindow(this);
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
				flag = (this.HasNameError || this.HasTextError ? false : !this.HasRubyError);
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