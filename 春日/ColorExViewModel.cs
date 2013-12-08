using Kasuga;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Threading;

namespace 春日
{
	public class ColorExViewModel : INotifyPropertyChanged
	{
		private string _typeName;

		private string _colorNum;

		private ObservableCollection<ColorExItemViewModel> _items;

		private IDialogViewModel _parentalViewModel;

		public BasicColorEx ColorEx
		{
			get
			{
				BasicColorEx solidColor;
				try
				{
					if (this.TypeName == SolidColor.TypeName)
					{
						solidColor = new SolidColor()
						{
							this.Items[0].ColorExItem
						};
					}
					else if (this.TypeName != SplitColor.TypeName)
					{
						solidColor = null;
					}
					else
					{
						SplitColor splitColor = new SplitColor();
						foreach (ColorExItemViewModel item in this.Items)
						{
							splitColor.Add(item.ColorExItem);
						}
						solidColor = splitColor;
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					solidColor = null;
				}
				return solidColor;
			}
		}

		public string ColorNum
		{
			get
			{
				string empty;
				try
				{
					empty = this._colorNum;
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
				BasicColorExItem solidColorItem;
				try
				{
					if (this._colorNum != value)
					{
						this._colorNum = value;
						this.RaisePropertyChanged("ColorNum");
						this.RaisePropertyChanged("HasColorNumError");
						((DelegateCommand)this._parentalViewModel.OkCommand).RaiseCanExecuteChanged();
						if (!this.HasColorNumError)
						{
							ObservableCollection<ColorExItemViewModel> observableCollection = new ObservableCollection<ColorExItemViewModel>();
							for (int i = 0; i < int.Parse(value); i++)
							{
								if (i >= this.Items.Count)
								{
									if (this.TypeName == SolidColor.TypeName)
									{
										solidColorItem = new SolidColorItem();
									}
									else if (this.TypeName != SplitColor.TypeName)
									{
										solidColorItem = null;
									}
									else
									{
										solidColorItem = new SplitColorItem();
									}
									observableCollection.Add(new ColorExItemViewModel(solidColorItem, this._parentalViewModel));
								}
								else
								{
									observableCollection.Add(this.Items[i]);
								}
							}
							this.Items = observableCollection;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public bool HasColorNumError
		{
			get
			{
				bool flag;
				try
				{
					flag = !Validations.IntegerValidate(this.ColorNum, false, false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public bool HasError
		{
			get
			{
				bool hasColorNumError;
				try
				{
					foreach (ColorExItemViewModel item in this.Items)
					{
						if (!item.HasError)
						{
							continue;
						}
						hasColorNumError = true;
						return hasColorNumError;
					}
					hasColorNumError = this.HasColorNumError;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					hasColorNumError = false;
				}
				return hasColorNumError;
			}
		}

		public IList<string> HiddenColumns
		{
			get
			{
				IList<string> strs;
				try
				{
					IList<string> strs1 = new List<string>();
					if (this._typeName == SolidColor.TypeName)
					{
						strs1.Add("幅の比");
					}
					strs = strs1;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					strs = null;
				}
				return strs;
			}
		}

		public bool IsColorNumEnabled
		{
			get
			{
				bool flag;
				try
				{
					flag = (this.TypeName != SolidColor.TypeName ? true : false);
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					flag = false;
				}
				return flag;
			}
		}

		public ObservableCollection<ColorExItemViewModel> Items
		{
			get
			{
				ObservableCollection<ColorExItemViewModel> observableCollection;
				try
				{
					observableCollection = this._items;
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
					observableCollection = null;
				}
				return observableCollection;
			}
			set
			{
				try
				{
					if (this._items != value)
					{
						this._items.Clear();
						foreach (ColorExItemViewModel colorExItemViewModel in value)
						{
							this._items.Add(colorExItemViewModel);
						}
						this.RaisePropertyChanged("Items");
						this.ColorNum = value.Count.ToString();
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
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
						this.RaisePropertyChanged("IsColorNumEnabled");
						this.RaisePropertyChanged("HiddenColumns");
						if (!this.HasColorNumError)
						{
							ObservableCollection<ColorExItemViewModel> observableCollection = new ObservableCollection<ColorExItemViewModel>();
							if (value == SolidColor.TypeName)
							{
								observableCollection.Add(new ColorExItemViewModel(new SolidColorItem(this.Items[0].ColorAlpha), this._parentalViewModel));
							}
							else if (value == SplitColor.TypeName)
							{
								observableCollection.Add(new ColorExItemViewModel(new SplitColorItem(this.Items[0].ColorAlpha), this._parentalViewModel));
								observableCollection.Add(new ColorExItemViewModel(new SplitColorItem(), this._parentalViewModel));
							}
							this.Items = observableCollection;
						}
					}
				}
				catch (Exception exception)
				{
					ErrorMessage.Show(exception, Assembly.GetExecutingAssembly(), MethodBase.GetCurrentMethod());
				}
			}
		}

		public ColorExViewModel(BasicColorEx colorEx, IDialogViewModel parentalViewModel)
		{
			try
			{
				if (colorEx.GetType() == typeof(SolidColor))
				{
					this._typeName = SolidColor.TypeName;
				}
				else if (colorEx.GetType() != typeof(SplitColor))
				{
					this._typeName = string.Empty;
				}
				else
				{
					this._typeName = SplitColor.TypeName;
				}
				this._colorNum = colorEx.Count.ToString();
				this._parentalViewModel = parentalViewModel;
				this._items = new ObservableCollection<ColorExItemViewModel>();
				foreach (BasicColorExItem basicColorExItem in colorEx)
				{
					this._items.Add(new ColorExItemViewModel(basicColorExItem, this._parentalViewModel));
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