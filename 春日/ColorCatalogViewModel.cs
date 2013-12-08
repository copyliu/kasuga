using Kasuga;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace 春日
{
	public class ColorCatalogViewModel : ICatalogViewModel, INotifyPropertyChanged
	{
		protected Catalog<ColorSet> _catalog;

		protected CatalogWindow _dialog;

		private ICommand _closeCommand;

		private ICommand _newCommand;

		private ICommand _editCommand;

		private ICommand _copyCommand;

		private ICommand _deleteCommand;

		public Catalog<ColorSet> Catalog
		{
			get
			{
				Catalog<ColorSet> catalog;
				try
				{
					catalog = this._catalog;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					catalog = null;
				}
				return catalog;
			}
		}

		public ICommand CloseCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._closeCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.CloseCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.CloseCommandCanExecute)
						};
						this._closeCommand = delegateCommand;
					}
					command = this._closeCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand CopyCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._copyCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.CopyCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.CopyCommandCanExecute)
						};
						this._copyCommand = delegateCommand;
					}
					command = this._copyCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand DeleteCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._deleteCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.DeleteCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.DeleteCommandCanExecute)
						};
						this._deleteCommand = delegateCommand;
					}
					command = this._deleteCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand EditCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._editCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.EditCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.EditCommandCanExecute)
						};
						this._editCommand = delegateCommand;
					}
					command = this._editCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public ICommand NewCommand
		{
			get
			{
				ICommand command;
				try
				{
					if (this._newCommand == null)
					{
						DelegateCommand delegateCommand = new DelegateCommand()
						{
							ExecuteHandler = new Action<object>(this.NewCommandExecute),
							CanExecuteHandler = new Func<object, bool>(this.NewCommandCanExecute)
						};
						this._newCommand = delegateCommand;
					}
					command = this._newCommand;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					command = null;
				}
				return command;
			}
		}

		public string WindowTitle
		{
			get
			{
				string empty;
				try
				{
					empty = "色マネージャー";
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					empty = string.Empty;
				}
				return empty;
			}
		}

		public ColorCatalogViewModel(Catalog<ColorSet> catalog)
		{
			try
			{
				this._catalog = catalog;
				this._dialog = new CatalogWindow(this);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool CloseCommandCanExecute(object parameter)
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

		private void CloseCommandExecute(object parameter)
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

		private bool CopyCommandCanExecute(object parameter)
		{
			bool selectedItem;
			try
			{
				selectedItem = this._dialog.listBox.SelectedItem != null;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				selectedItem = false;
			}
			return selectedItem;
		}

		private void CopyCommandExecute(object parameter)
		{
			try
			{
				ColorSet item = this.Catalog.GetItem((string)this._dialog.listBox.SelectedItem);
				if (item != null)
				{
					ColorSetViewModel colorSetViewModel = new ColorSetViewModel(this.Catalog, item, false);
					bool? nullable = colorSetViewModel.ShowDialog();
					if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
					{
						this.Catalog.Add(colorSetViewModel.ColorSet);
						this.RaisePropertyChanged("Catalog");
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool DeleteCommandCanExecute(object parameter)
		{
			bool flag;
			try
			{
				flag = (this._dialog.listBox.SelectedItem == null ? false : this._dialog.listBox.Items.Count > 1);
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				flag = false;
			}
			return flag;
		}

		private void DeleteCommandExecute(object parameter)
		{
			try
			{
				ColorSet item = this.Catalog.GetItem((string)this._dialog.listBox.SelectedItem);
				if (item != null)
				{
					this.Catalog.Remove(item);
					this.RaisePropertyChanged("Catalog");
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool EditCommandCanExecute(object parameter)
		{
			bool selectedItem;
			try
			{
				selectedItem = this._dialog.listBox.SelectedItem != null;
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				selectedItem = false;
			}
			return selectedItem;
		}

		private void EditCommandExecute(object parameter)
		{
			try
			{
				ColorSet item = this.Catalog.GetItem((string)this._dialog.listBox.SelectedItem);
				if (item != null)
				{
					ColorSetViewModel colorSetViewModel = new ColorSetViewModel(this.Catalog, item, true);
					bool? nullable = colorSetViewModel.ShowDialog();
					if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
					{
						this.Catalog.Insert(this.Catalog.IndexOf(item), colorSetViewModel.ColorSet);
						this.Catalog.Remove(item);
						this.RaisePropertyChanged("Catalog");
					}
				}
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		private bool NewCommandCanExecute(object parameter)
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

		private void NewCommandExecute(object parameter)
		{
			try
			{
				ColorSetViewModel colorSetViewModel = new ColorSetViewModel(this.Catalog, null, false);
				bool? nullable = colorSetViewModel.ShowDialog();
				if ((!nullable.GetValueOrDefault() ? false : nullable.HasValue))
				{
					this.Catalog.Add(colorSetViewModel.ColorSet);
					this.RaisePropertyChanged("Catalog");
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

		public void UpdateButtons()
		{
			try
			{
				((DelegateCommand)this.EditCommand).RaiseCanExecuteChanged();
				((DelegateCommand)this.CopyCommand).RaiseCanExecuteChanged();
				((DelegateCommand)this.DeleteCommand).RaiseCanExecuteChanged();
			}
			catch (Exception exception)
			{
				ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
			}
		}

		public event PropertyChangedEventHandler PropertyChanged;
	}
}